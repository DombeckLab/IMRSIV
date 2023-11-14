using UnityEngine;
using System.Collections;

namespace PrimitivePlus
{
	[ExecuteInEditMode]
	[RequireComponent(typeof(MeshRenderer))]
	public class PrimitivePlusMaterial : MonoBehaviour 
	{
		private MeshRenderer m_Renderer = null;
		private Material m_Material = null;

		private void Awake ()
		{
			m_Renderer = GetComponent<MeshRenderer>();
		}

		private void OnDestroy()
		{
			m_Material = null;
			m_Renderer = null;
		}

		public void SetNewMaterial()
		{
			m_Material = new Material(m_Renderer.sharedMaterial);
			m_Renderer.sharedMaterial = m_Material;
			m_Material.name = "New Material";
		}

		public void SetSharedMaterial(Material material)
		{
			m_Material = material;
			m_Renderer.sharedMaterial = m_Material;
		}
	}
}