#include "stdafx.h"
#include "VDL.h"



using namespace My3DModel;


BOOL LoadVdlFile (const char *filename)

{
 FILE *Ptr=fopen(filename,"rb");// Open file from read
 if(Ptr==NULL) {MessageBox::Show( "HL model can't load.","ERROR");return false;}

 rewind(Ptr); //Repositions the file pointer to the beginning of a file.
 byte *v= new byte[1];

 while (!feof (Ptr)){
        fread (v,sizeof (byte),1,Ptr);
        }

delete [] v;
long fsize= ftell(Ptr); // size the file

rewind(Ptr);
byte *pBuffer = new byte[fsize];//allocate memory

fread (pBuffer,sizeof (byte),fsize,Ptr);// read file
const byte *pPtr = pBuffer;
fclose (Ptr );


fileHeandler *p_fileHeandler = (fileHeandler*)pPtr;//File heandler

pPtr += sizeof( fileHeandler ); // Move pointer if size fileHeandler


files *p_fileStruc = (files*)pPtr;


Form1::pCountSS = new CountS [p_fileStruc->NumEvents];

 pPtr += sizeof(files);

int n= p_fileStruc->NumEvents;

//////////////////////////////////////////////////////

  for (int nEven=0; nEven < n; nEven++)
      {

       int nVertices = *( word* )pPtr;//read number vertex
       pPtr += sizeof( word );

        Form1::pCountSS[nEven].Sm_pVertices = new CountS::Vertex  [nVertices];
        Form1::pCountSS[nEven].Sm_numVertices= nVertices;

        for (int i = 0; i < nVertices; i++ )
	      {

          VDLVertex *pVertex = ( VDLVertex* )pPtr;
		  Form1::pCountSS[nEven].Sm_pVertices[i].m_boneID =(int) pVertex->m_boneID;
			  Form1::pCountSS[nEven].Sm_pVertices[i].m_location.set( pVertex->m_vertex );
		memcpy(  Form1::pCountSS[nEven].Sm_pVertices[i].m_location1, pVertex->m_vertex, sizeof( float )*3 );
		float gh =   Form1::pCountSS[nEven].Sm_pVertices[i].m_location1[0];
		pPtr += sizeof( VDLVertex );
			}

		int nTrian = *( word* )pPtr;//read number triangles
		 pPtr += sizeof( word );
		Form1::pCountSS[nEven].Sm_pTriangles  =  new CountS::Triangle [nTrian];
		Form1::pCountSS[nEven].Sm_numTriangles = nTrian;

			for (int i = 0; i < nTrian ; i++ )
			{
				VDLTriangle *pTriangle = ( VDLTriangle* )pPtr;
				int vertexIndices[3] = { pTriangle->m_vertexIndices[0], pTriangle->m_vertexIndices[1], pTriangle->m_vertexIndices[2] };
				memcpy( Form1::pCountSS[nEven].Sm_pTriangles[i].m_vertexNormals, pTriangle->m_vertexNormals, sizeof( float )*3*3 );
				memcpy( Form1::pCountSS[nEven].Sm_pTriangles[i].m_s, pTriangle->m_s, sizeof( float )*3 );
				memcpy( Form1::pCountSS[nEven].Sm_pTriangles[i].m_t,pTriangle->m_t , sizeof( float )*3 );
				memcpy( Form1::pCountSS[nEven].Sm_pTriangles[i].m_vertexIndices, vertexIndices , sizeof( int )*3 );
				pPtr += sizeof( VDLTriangle );
                 }

				int nMech = *( word* )pPtr;//read number mech
				pPtr += sizeof( word );
				Form1::pCountSS[nEven].Sm_pMeshes = new CountS::Mesh[nMech];
				Form1::pCountSS[nEven].Sm_numMeshes= nMech;


				for (int i = 0; i < nMech; i++ )
					{
					word nTriangles = *( word* )pPtr;
         			pPtr += sizeof( word );
					word materialIndex = *( word* )pPtr;
					pPtr += sizeof( word );
					int *pTriangleIndices = new int[nTriangles];

				for ( int j = 0; j < nTriangles; j++ )
					{
					pTriangleIndices[j] = *( word* )pPtr;
					pPtr += sizeof( word );

					}
 
				Form1::pCountSS[nEven].Sm_pMeshes[i].m_materialIndex = materialIndex;
				Form1::pCountSS[nEven].Sm_pMeshes[i].m_numTriangles = nTriangles;
				Form1::pCountSS[nEven].Sm_pMeshes[i].m_pTriangleIndices = pTriangleIndices;

					}
			
				int nMaterials = *( word* )pPtr;//read number materials
				Form1::pCountSS[nEven].Sm_pMaterials = new CountS::Material[nMaterials];
				Form1::pCountSS[nEven].Sm_numMaterials = nMaterials;
				pPtr += sizeof( word );

				for ( int i = 0; i < nMaterials; i++ )
				{
					VDLMaterial *pMaterial = ( VDLMaterial* )pPtr;
					memcpy(  Form1::pCountSS[nEven].Sm_pMaterials[i].m_ambient, pMaterial->m_ambient, sizeof( float )*4 );
					memcpy(  Form1::pCountSS[nEven].Sm_pMaterials[i].m_diffuse, pMaterial->m_diffuse, sizeof( float )*4 );
					memcpy(  Form1::pCountSS[nEven].Sm_pMaterials[i].m_specular, pMaterial->m_specular, sizeof( float )*4 );
					memcpy(  Form1::pCountSS[nEven].Sm_pMaterials[i].m_emissive, pMaterial->m_emissive, sizeof( float )*4 );
					Form1::pCountSS[nEven].Sm_pMaterials[i].m_shininess = pMaterial->m_shininess;
					Form1::pCountSS[nEven].Sm_pMaterials[i].m_pTextureFilename = new char[strlen( pMaterial->m_texture )+1];
					strcpy(  Form1::pCountSS[nEven].Sm_pMaterials[i].m_pTextureFilename, pMaterial->m_texture );
					pPtr += sizeof( VDLMaterial );
				}

				int nJoint = *( word* )pPtr;//read number joint
				pPtr += sizeof( word );
				Form1::pCountSS[nEven].Sjoints = new CountS::joint[ nJoint ];
				Form1::pCountSS[nEven].SnumJoints = nJoint;
				int i,j;

				for( i = 0; i < nJoint; i++ ) {
					VDLJoint *pVDLJoint = ( VDLJoint* )pPtr;
					std::string asd;
					Form1::pCountSS[nEven].Sjoints[i].name =  pVDLJoint->m_parentName;
					asd= Form1::pCountSS[nEven].Sjoints[i].name;
					Form1::pCountSS[nEven].Sjoints[i].parentIndex=  pVDLJoint->parentIndex;
					Form1::pCountSS[nEven].Sjoints[i].numTranslationKeyFrames = pVDLJoint->m_numTranslationKeyframes;
					Form1::pCountSS[nEven].Sjoints[i].numRotationKeyFrames = pVDLJoint->m_numRotationKeyframes ;
					memcpy(Form1::pCountSS[nEven].Sjoints[i].rotation,pVDLJoint->m_rotation,sizeof( float )*3);
					Form1::pCountSS[nEven].Sjoints[i].translation.set(pVDLJoint->m_translation);
					pPtr += sizeof( VDLJoint );

               }

              int numRotationKeyF = *( word* )pPtr;//Rotation Key Frame
			  pPtr += sizeof( word );
			  int translationKeyF = *( word* )pPtr;//translation Key Frame
			  pPtr += sizeof( word );
					
			  for( i = 0; i < nJoint; i++ ) {
					Form1::pCountSS[nEven].Sjoints[ i ].rotationKeyFrames = new CountS::rotationKeyFrame[numRotationKeyF];

					for( j = 0; j < numRotationKeyF; j++ ) {
						VDLKeyframe *key = ( VDLKeyframe * )pPtr;
						Form1::pCountSS[nEven].Sjoints[ i ].rotationKeyFrames[ j ].time = key->m_time ;
						memcpy( Form1::pCountSS[nEven].Sjoints[ i ].rotationKeyFrames[ j ].rotation, key->m_parameter , sizeof( float ) * 3 );
						// annimation data
						pPtr += sizeof( VDLKeyframe );
						}

					}
			  for( i = 0; i < nJoint; i++ ) {

				Form1::pCountSS[nEven].Sjoints[ i ].translationKeyFrames = new CountS::translationKeyFrame[translationKeyF];

             for( j = 0; j < Form1::pCountSS[nEven].Sjoints[ i ].numTranslationKeyFrames; j++ ) {
			
				 VDLKeyframe *key = ( VDLKeyframe * )pPtr;
				 Form1::pCountSS[nEven].Sjoints[ i ].translationKeyFrames[ j ].time = key->m_time ;
				 Form1::pCountSS[nEven].Sjoints[ i ].translationKeyFrames[ j ].translation = key->m_parameter ;
				 pPtr += sizeof( VDLKeyframe );
					}
				}

			if(nMech>0)
			Form1::pCountSS[nEven].SsetupModel();
		}


			int imageSize;

			for (int i=0; i< Form1::pCountSS[0].Sm_numMaterials; i++ )//read textures
			 {

				imageSize= *( DWORD* )pPtr;
				Form1::pCountSS[0].Sm_pMaterials[i].byf = new byte [imageSize];  
				Form1::pCountSS[0].Sm_pMaterials[i].imageSize =imageSize;	
				pPtr += sizeof( DWORD );
					for( int j = 0; j <imageSize ; j++ ) {
						byte bImg  = *( byte* )pPtr;
						Form1::pCountSS[0].Sm_pMaterials[i].byf[j]=bImg;
						pPtr += sizeof( byte );
					}
				}

 delete [] pBuffer;





return true;
}// end LoadVdlFile