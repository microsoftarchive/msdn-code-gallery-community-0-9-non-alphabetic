#ifndef COUNTS_H
#define COUNTS_H

#include <windows.h>		// Header File For Windows
#include <stdio.h>			// Header File For Standard Input/Output
#include "math.h"
#include <gl\gl.h>			// Header File For The OpenGL32 Library
#include <gl\glu.h>	
#include <string>
#include <olectl.h>
#include <crtdbg.h>

//using namespace std;

class CountS{
public:

 
struct Vertex
		{
			int m_boneID;	// for skeletal animation
			dfx::vector<> m_location;
			float m_location1[3];
		
		};	


struct Triangle
		{
			float m_vertexNormals[3][3];// Normals to each of vertex of a triangle 
			float m_s[3], m_t[3];// Textural coordinates for a triangle
			int m_vertexIndices[3];//3 tops make a triangle 
			
		};


struct Mesh // 
		{
			int m_materialIndex;//It is an index of a material (a structure and factor of illumination) used for a grid.
			int m_numTriangles;// количество треугольников
			int *m_pTriangleIndices;//Quantity of triangles
		};


//Here there are all standard factors of illumination in the same format, as well as in OpenGL:
//environmental, disseminating, reflecting, letting out and brilliant. We as have object of a 
//structure m_texture and a name of a file (dynamically available) structures which can be unloaded 
//if context OpenGL will fall.

struct Material
		{
			float m_ambient[4], m_diffuse[4], m_specular[4], m_emissive[4];
			float m_shininess;
			GLuint m_texture;
			char *m_pTextureFilename;
			byte *byf;
			int imageSize;
		};


// rotationKeyFrame
struct rotationKeyFrame {
		float time;
		float rotation[ 3 ];
		};

// translationKeyFrame
struct translationKeyFrame {
		float time;
		dfx::vector<> translation;
		};

// Structure for groups (skeletal animation)
		
struct joint {
		std::string name;
		int parentIndex;

		float rotation[ 3 ];
		dfx::vector<> translation;

		dfx::matrix<> relative, absolute, final;

		rotationKeyFrame* rotationKeyFrames;
		translationKeyFrame* translationKeyFrames;

		int numRotationKeyFrames;
		int numTranslationKeyFrames;
	};

//	Meshes used
		int Sm_numMeshes;
		Mesh *Sm_pMeshes;

		//	Materials used
		int Sm_numMaterials;
		Material *Sm_pMaterials;

		//	Triangles used
		int Sm_numTriangles;
		Triangle *Sm_pTriangles;

		//	Vertices Used
		int Sm_numVertices;
		Vertex *Sm_pVertices;
		//Vertex *vertices;
	
		//Joint
		int SnumJoints;
		joint *Sjoints;	





void Sdraw(CountS * , float);
void SreloadTextures();
void SsetupModel ();
};

#endif 