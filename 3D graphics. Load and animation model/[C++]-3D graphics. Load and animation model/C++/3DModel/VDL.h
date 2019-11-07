#include "stdafx.h"
#include "Form1.h"
#include "CountS.h"

#pragma package(smart_init)
#	pragma pack( push, packing )
#	pragma pack( 1 )
#	define PACK_STRUCT

typedef unsigned char byte;
typedef unsigned short word;

struct fileHeandler{

	char Name[15];
        int VersionNum;

};

 struct files{
         int NumEvents;
         char EventsName [40][20];
         char path [100][100];
         int EnentNum[40];

}file_Struct ;

 // Vertex information
struct VDLVertex
{
	byte m_flags;
	float m_vertex[3];
	char m_boneID;
	byte m_refCount;
} PACK_STRUCT;

// Triangle information
struct VDLTriangle
{
	word m_flags;
	word m_vertexIndices[3];
	float m_vertexNormals[3][3];
	float m_s[3], m_t[3];
	byte m_smoothingGroup;
	byte m_groupIndex;
} PACK_STRUCT;

// Material information
struct VDLMaterial
{
    char m_name[32];
    float m_ambient[4];
    float m_diffuse[4];
    float m_specular[4];
    float m_emissive[4];
    float m_shininess;	// 0.0f - 128.0f
    float m_transparency;	// 0.0f - 1.0f
    byte m_mode;	// 0, 1, 2 is unused now
    char m_texture[128];
    char m_alphamap[128];
} PACK_STRUCT;

//	Joint information
struct VDLJoint
{
	byte m_flags;
        int parentIndex;
	char m_name[32];
	char m_parentName[32];
	float m_rotation[3];
	float m_translation[3];
	word m_numRotationKeyframes;
	word m_numTranslationKeyframes;
} PACK_STRUCT;

// Keyframe data
struct VDLKeyframe
{
	float m_time;
	float m_parameter[3];
} PACK_STRUCT;


