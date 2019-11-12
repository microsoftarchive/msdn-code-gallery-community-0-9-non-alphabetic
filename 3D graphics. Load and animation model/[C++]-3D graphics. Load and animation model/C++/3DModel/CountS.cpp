#include "CountS.h"


//typedef unsigned short word;
 int zcount=-1;
float num[2];

GLuint	texture[10];

void CountS::Sdraw(CountS* SSjoints, float time) 
{
/////
	int i = 0;
	// Update joints
	GLboolean texEnabled = glIsEnabled( GL_TEXTURE_2D );

	for( i = 0; i < SnumJoints; i++ ) {//We calculate matrixes (final) transformations / rotations
		joint &jnt = SSjoints->Sjoints[i] ;

dfx::matrix<> transform;

		if( jnt.numRotationKeyFrames == 0 && jnt.numTranslationKeyFrames == 0 ) {
			jnt.final = jnt.absolute;//If anything is not present simply we draw a static picture
			continue;
		}// end if

		// Calc rotation
		
		int rotFrame = 0;// 

		while( rotFrame < jnt.numRotationKeyFrames && jnt.rotationKeyFrames[ rotFrame ].time < time )
			rotFrame++;// Cycle with a condition up to the end (quantity of turns and time) in general(common) check for a while

		//--------------------------------------------------------------------------------------------	

		if( rotFrame == 0 )
			transform.setRotationRadians( jnt.rotationKeyFrames[ 0 ].rotation );
		// если 0 то устанавливаем матрицу вращения (x,y,z) для прервого (0) элемента


		else if( rotFrame == jnt.numRotationKeyFrames )//
			transform.setRotationRadians( jnt.rotationKeyFrames[ rotFrame - 1 ].rotation );
		// если уже конец то устанавливаем матрицу вращения (x,y,z) для последнего элемента
		
		else {
			// а вот здесь крутимся!
			
			const rotationKeyFrame &curFrame = jnt.rotationKeyFrames[ rotFrame ];
			// инициализируем указатель текущим поворотом

			const rotationKeyFrame &prevFrame = jnt.rotationKeyFrames[ rotFrame - 1 ];
			// инициализируем указатель предыдущим поворотом
			
			float timeDelta = curFrame.time - prevFrame.time; // дельта времени
			float t = ( float )(( time - prevFrame.time ) / timeDelta );// скорость аннимации

			dfx::quaternion<> rotation;

			rotation.slerp( dfx::quaternion<>( prevFrame.rotation ), dfx::quaternion<>( curFrame.rotation ), t );

			transform = rotation.toMatrix();// а вот здесь загадка:)
		}// end else

		// Calc translation
		dfx::vector<> translation;
		int transFrame = 0;
		
		while( transFrame < jnt.numTranslationKeyFrames && jnt.translationKeyFrames[ transFrame ].time < time )
			transFrame++;

		if( transFrame == 0 )
			translation = jnt.translationKeyFrames[ 0 ].translation;
		else if( transFrame == jnt.numTranslationKeyFrames )
			translation = jnt.translationKeyFrames[ transFrame - 1 ].translation;
		else {
			const translationKeyFrame &curFrame = jnt.translationKeyFrames[ transFrame ];
			const translationKeyFrame &prevFrame = jnt.translationKeyFrames[ transFrame - 1 ];

float timeDelta = curFrame.time - prevFrame.time;
			float t = ( float )(( time - prevFrame.time ) / timeDelta );

			translation.lerp( prevFrame.translation, curFrame.translation, t ); 
		}// end else
		
		transform.setTranslation( translation);

		dfx::matrix<> relativeFinal = jnt.relative * transform;

		if( jnt.parentIndex == -1 )
			jnt.final = relativeFinal;
		else
			jnt.final = SSjoints->Sjoints[ jnt.parentIndex ].final * relativeFinal;
	}// end for


	
	
	
	
	
	// Draw by group
	for ( int h = 0; h < Sm_numMeshes; h++ )
	{
		int materialIndex = Sm_pMeshes[h].m_materialIndex;
		if ( materialIndex >= 0 )
		{
			glMaterialfv( GL_FRONT, GL_AMBIENT, Sm_pMaterials[materialIndex].m_ambient );
			glMaterialfv( GL_FRONT, GL_DIFFUSE, Sm_pMaterials[materialIndex].m_diffuse );
			glMaterialfv( GL_FRONT, GL_SPECULAR, Sm_pMaterials[materialIndex].m_specular );
			glMaterialfv( GL_FRONT, GL_EMISSION, Sm_pMaterials[materialIndex].m_emissive );
			glMaterialf( GL_FRONT, GL_SHININESS, Sm_pMaterials[materialIndex].m_shininess );

			if ( Sm_pMaterials[materialIndex].m_texture > 0 )
			{
				glBindTexture( GL_TEXTURE_2D, Sm_pMaterials[materialIndex].m_texture );
				glEnable( GL_TEXTURE_2D );
			}
			else
				glDisable( GL_TEXTURE_2D );
		}
		else
		{
			// Material properties?
			glDisable( GL_TEXTURE_2D );
		}

		glBegin( GL_TRIANGLES );
		
			for ( int j = 0; j < Sm_pMeshes[h].m_numTriangles; j++ )
			{
				int triangleIndex = Sm_pMeshes[h].m_pTriangleIndices[j];
				const Triangle* pTri = &Sm_pTriangles[triangleIndex];
				
				
				
				for ( int k = 0; k < 3; k++ )
				{
					int index = pTri->m_vertexIndices[k];

					if( Sm_pVertices[ index ].m_boneID  == -1 )
					{
					glNormal3fv( pTri->m_vertexNormals[k] );
					glTexCoord2f( pTri->m_s[k], pTri->m_t[k] );
					
					

					glVertex3fv( Sm_pVertices[index].m_location1);
					}
					else
					{
				const dfx::matrix<> final = SSjoints->Sjoints[  Sm_pVertices[ index ].m_boneID ].final;

						glTexCoord2f( pTri->m_s[ k ], pTri->m_t[ k ] );

						dfx::vector<> normal = final.rotate( pTri->m_vertexNormals[ k ] );
						normal.normalize();

						glNormal3fv( normal.v );
						
						
						dfx::vector<> vert = final* Sm_pVertices[ index ].m_location ;
						
						
						glVertex3fv( vert.v );

					}

				}
			}
		
		glEnd();
	}

	if ( texEnabled )
		glEnable( GL_TEXTURE_2D );
	else
		glDisable( GL_TEXTURE_2D );

}

void CountS::SreloadTextures()
{
	GLuint texture = 0;
	for ( int t = 0; t < Sm_numMaterials; t++ )
		if ( strlen( Sm_pMaterials[t].m_pTextureFilename ) > 0 )
		{
	
 

HDC    hdcTemp;                        // DC для растра
HBITMAP    hbmpTemp;            // иногда храним в ней растр
IPicture  *pPicture;            // интерфейс IPicture 
OLECHAR    wszPath[MAX_PATH+1]; // полный путь до картинки (WCHAR)
char    szPath[MAX_PATH+1];     // полный путь до картинки
long    lWidth;                  // ширина в логических единицах
long    lHeight;                // высота в логических единицах
long    lWidthPixels;           // ширина в пикселях
long    lHeightPixels;          // высота в пикселях
GLint    glMaxTexDim ;          // максимальный размер текстуры




HGLOBAL hGlobal = GlobalAlloc(GMEM_MOVEABLE, Sm_pMaterials[t].imageSize);
LPSTREAM pstm = NULL;
	// create IStream* from global memory
	LPVOID pvData = NULL;
	pvData = GlobalLock(hGlobal);

	memcpy(pvData,Sm_pMaterials[t].byf ,sizeof(byte)*Sm_pMaterials[t].imageSize );
	
	GlobalUnlock(hGlobal);
	
	HRESULT hr = CreateStreamOnHGlobal(hGlobal, TRUE, &pstm);
	_ASSERTE(SUCCEEDED(hr) && pstm);

	
 
 hr = OleLoadPicture( pstm,Sm_pMaterials[t].imageSize,TRUE,IID_IPicture,(void**)&pPicture);  

	GlobalFree(hGlobal);
    //delete [] Sm_pMaterials[t].byf;


 hdcTemp = CreateCompatibleDC(GetDC(0)); // создать совместимый с устройством Windows контекст 

  if(!hdcTemp)            // ну что, создали?

  {                       // не-а… :(

    pPicture->Release();  // уменьшение счетчика ссылок на IPicture 

  }

// получить максимально возможное разрешение изображения

  glGetIntegerv(GL_MAX_TEXTURE_SIZE, &glMaxTexDim);
	
  pPicture->get_Width(&lWidth); // получить ширину изображения

  lWidthPixels  = MulDiv(lWidth, GetDeviceCaps(hdcTemp, LOGPIXELSX), 2540);

  pPicture->get_Height(&lHeight); // получить высоту изображения

  lHeightPixels  = MulDiv(lHeight, GetDeviceCaps(hdcTemp, LOGPIXELSY), 2540);

 // преобразовать изображение к ближайшей степени двойки

  if (lWidthPixels <= glMaxTexDim)

  // если ширина изображения меньше либо равна максимально-допустимому пределу карточки

    lWidthPixels = 1 << (int)floor((log((double)lWidthPixels)/log(2.0f)) + 0.5f); 

  else

    // иначе установить размер равный максимальной степени двойки,

    // которую поддерживает карточка

    lWidthPixels = glMaxTexDim;

  // то же самое повторяется для высоты

  if (lHeightPixels <= glMaxTexDim)

    lHeightPixels = 1 << (int)floor((log((double)lHeightPixels)/log(2.0f)) + 0.5f);

  else

    lHeightPixels = glMaxTexDim;

 // создать временный растр

  BITMAPINFO  bi = {0}; // нужный нам тип растра

  DWORD    *pBits = 0;  // указатель на биты растра

bi.bmiHeader.biSize     = sizeof(BITMAPINFOHEADER); // размер структуры

  bi.bmiHeader.biBitCount = 32; // 32 бита

  bi.bmiHeader.biWidth    = lWidthPixels;  // ширина кратная степени двойки

  // Сделаем изображение расположенным вверх (положительное направление оси Y)

  bi.bmiHeader.biHeight   = lHeightPixels;

  bi.bmiHeader.biCompression  = BI_RGB;    // RGB формат

  bi.bmiHeader.biPlanes    = 1;            // 1 битовая плоскость 

// создавая растр, таким образом, мы можем установить глубину цвета,

  // а также получить прямой доступ к битам.

  hbmpTemp = CreateDIBSection (hdcTemp, &bi, DIB_RGB_COLORS, (void**)&pBits, 0, 0);


  if(!hbmpTemp)        // создали?

  {                    // сам вижу что нет

   DeleteDC(hdcTemp);  // убить контекст устройства

  pPicture->Release(); // уменьшить счетчик количества интерфейсов IPicture 

   // return FALSE;      // вернуть ЛОЖЬ

  }

  // есть растр!

  SelectObject(hdcTemp, hbmpTemp); // загрузить описатель временного растра

                                   // в описатель временного контекста устройства 

// отрисовка IPicture в растр

  pPicture->Render(hdcTemp, 0, 0, lWidthPixels, lHeightPixels, 0, lHeight, lWidth, -lHeight, 0);

// преобразовать из BGR в RGB формат и устанавливаем значение 

  // Alpha = 255

  for(long i = 0; i < lWidthPixels * lHeightPixels; i++) // Цикл по всем пикселям

  {

    BYTE* pPixel  = (BYTE*)(&pBits[i]); // берем текущий пиксель

    BYTE  temp  = pPixel[0];            // сохраняем первый цвет в  переменной

   pPixel[0]  = pPixel[2];             // ставим  Красный на место (в первую позицию)

    pPixel[2]  = temp;                  // ставим значение Temp в третий параметр (3rd)

    pPixel[3]  = 255;                   // установить значение alpha =255

  }

	glGenTextures(1, &texture);											// Create The Texture

	// Typical Texture Generation Using Data From The Bitmap
	glBindTexture(GL_TEXTURE_2D, texture);								// Bind To The Texture ID
	glTexParameteri(GL_TEXTURE_2D,GL_TEXTURE_MIN_FILTER,GL_LINEAR);		// (Modify This For The Type Of Filtering You Want)
	glTexParameteri(GL_TEXTURE_2D,GL_TEXTURE_MAG_FILTER,GL_LINEAR);     // (Modify This For The Type Of Filtering You Want)

	// (Modify This If You Want Mipmaps)
	glTexImage2D(GL_TEXTURE_2D, 0, 3, lWidthPixels, lHeightPixels, 0, GL_RGBA, GL_UNSIGNED_BYTE, pBits);

	DeleteObject(hbmpTemp);												// Delete The Object
	DeleteDC(hdcTemp);													// Delete The Device Context

	pPicture->Release();		
		
	Sm_pMaterials[t].m_texture= texture;	
		
		}
			
			//Sm_pMaterials[i].m_texture = LoadGLTexture( Sm_pMaterials[i].byf );
		else
			Sm_pMaterials[t].m_texture = 0;
}


void CountS::SsetupModel ()

{
int i = 0;
// преобразование координат, первичная установка модели перед аннимацией
	// Calculate bone matrices
	for( i = 0; i < SnumJoints; i++ ) {
		joint &jnt = Sjoints[ i ];

		jnt.relative.setRotationRadians( jnt.rotation );
		jnt.relative.setTranslation( jnt.translation );
		// здесь создаем матрицы преобразования
		if( jnt.parentIndex != -1 )
		{
			jnt.absolute = Sjoints[ jnt.parentIndex ].absolute * jnt.relative;
		//здесь перемножаем иатрицы 3х3 (вращения) предыдущая на последущую
		// создаем матрицу преобразования	
			int ttt=0;
		}
		else
			jnt.absolute = jnt.relative;
	}

	// Inverse transform the mesh
	for( i = 0; i < Sm_numVertices; i++ ) {
		Vertex &vert = Sm_pVertices[ i ];

		if( vert.m_boneID  != -1 ) {
			dfx::matrix<> mat = Sjoints[ vert.m_boneID ].absolute;

			vert.m_location  = mat.invTranslate( vert.m_location  );
			vert.m_location  = mat.invRotate( vert.m_location  );
		int rdddd=0;
		}
	}

	// Inverse transform the normals
	for( i = 0; i < Sm_numTriangles; i++ ) {
		Triangle &tri = Sm_pTriangles[ i ];
		for( int j = 0; j < 3; j++ ) {
			const Vertex &vert = Sm_pVertices[ tri.m_vertexIndices[ j ] ];
			if( vert.m_boneID  != -1 ) {
				const dfx::matrix<> &mat = Sjoints[ vert.m_boneID].absolute;
				mat.invRotate( tri.m_vertexNormals [ j ] );
			}
		}

	}

}