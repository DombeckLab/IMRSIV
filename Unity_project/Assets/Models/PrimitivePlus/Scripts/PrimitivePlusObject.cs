using UnityEngine;
using System.Collections;

namespace PrimitivePlus
{
	public static class PrimitivePlusObject
	{
		public static GameObject CreatePrimitivePlus(PrimitivePlusType type)
		{
			string typeString = type.ToString();

			GameObject gameObject = new GameObject(typeString);

			MeshFilter mesh = gameObject.AddComponent<MeshFilter>();
			mesh.sharedMesh = PrimitivePlusMeshes.GetMeshType(type);
			mesh.sharedMesh.name = typeString;

			#if UNITY_5
			Material material = new Material(Shader.Find("Standard"));
			#else
			Material material = new Material(Shader.Find("Diffuse"));
			#endif
			gameObject.AddComponent<MeshRenderer>().sharedMaterial = material;
			if(typeString == "Cube")
				gameObject.AddComponent<BoxCollider>();
			else if(typeString == "Sphere" || typeString == "Heart")
				gameObject.AddComponent<SphereCollider>();
			else if(mesh.sharedMesh.triangles.Length/3 < 255)
				gameObject.AddComponent<MeshCollider>();
			gameObject.AddComponent<PrimitivePlusMaterial>();

			return gameObject;
		}
	}
}
