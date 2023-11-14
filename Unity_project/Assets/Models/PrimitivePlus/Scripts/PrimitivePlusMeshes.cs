using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace PrimitivePlus
{
	public class PrimitivePlusMeshes
	{
		public static Mesh GetMeshType(PrimitivePlusType type)
		{
			switch(type)
			{
			case PrimitivePlusType.Circle2D:
				return (m_Circle2D == null) ? Circle2D() : m_Circle2D;
			case PrimitivePlusType.CircleHalf2D:
				return (m_CircleHalf2D == null) ? CircleHalf2D() : m_CircleHalf2D;
			case PrimitivePlusType.Cone:
				return (m_Cone == null) ? Cone() : m_Cone;
			case PrimitivePlusType.ConeHalf:
				return (m_ConeHalf == null) ? ConeHalf() : m_ConeHalf;
			case PrimitivePlusType.ConeHexagon:
				return (m_ConeHexagon == null) ? ConeHexagon() : m_ConeHexagon;
			case PrimitivePlusType.ConePentagon:
				return (m_ConePentagon == null) ? ConePentagon() : m_ConePentagon;
			case PrimitivePlusType.Cross:
				return (m_Cross == null) ? Cross() : m_Cross;
			case PrimitivePlusType.Cross2D:
				return (m_Cross2D == null) ? Cross2D() : m_Cross2D;
			case PrimitivePlusType.Cube:
				return (m_Cube == null) ? Cube() : m_Cube;
			case PrimitivePlusType.CubeCorner:
				return (m_CubeCorner == null) ? CubeCorner() : m_CubeCorner;
			case PrimitivePlusType.CubeCornerThin:
				return (m_CubeCornerThin == null) ? CubeCornerThin() : m_CubeCornerThin;
			case PrimitivePlusType.CubeEdgeIn:
				return (m_CubeEdgeIn == null) ? CubeEdgeIn() : m_CubeEdgeIn;
			case PrimitivePlusType.CubeEdgeOut:
				return (m_CubeEdgeOut == null) ? CubeEdgeOut() : m_CubeEdgeOut;
			case PrimitivePlusType.CubeHollow:
				return (m_CubeHollow == null) ? CubeHollow() : m_CubeHollow;
			case PrimitivePlusType.CubeHollowThin:
				return (m_CubeHollowThin == null) ? CubeHollowThin() : m_CubeHollowThin;
			case PrimitivePlusType.CubeTube:
				return (m_CubeTube == null) ? CubeTube() : m_CubeTube;
			case PrimitivePlusType.Cylinder:
				return (m_Cylinder == null) ? Cylinder() : m_Cylinder;
			case PrimitivePlusType.CylinderHalf:
				return (m_CylinderHalf == null) ? CylinderHalf() : m_CylinderHalf;
			case PrimitivePlusType.CylinderTube:
				return (m_CylinderTube == null) ? CylinderTube() : m_CylinderTube;
			case PrimitivePlusType.CylinderTubeThin:
				return (m_CylinderTubeThin == null) ? CylinderTubeThin() : m_CylinderTubeThin;
			case PrimitivePlusType.Diamond:
				return (m_Diamond == null) ? Diamond() : m_Diamond;
			case PrimitivePlusType.DiamondThick:
				return (m_DiamondThick == null) ? DiamondThick() : m_DiamondThick;
			case PrimitivePlusType.Heart:
				return (m_Heart == null) ? Heart() : m_Heart;
			case PrimitivePlusType.Heart2D:
				return (m_Heart2D == null) ? Heart2D() : m_Heart2D;
			case PrimitivePlusType.Hexagon2D:
				return (m_Hexagon2D == null) ? Hexagon2D() : m_Hexagon2D;
			case PrimitivePlusType.Icosphere:
				return (m_Icosphere == null) ? Icosphere() : m_Icosphere;
			case PrimitivePlusType.IcosphereSmall:
				return (m_IcosphereSmall == null) ? IcosphereSmall() : m_IcosphereSmall;
			case PrimitivePlusType.Plane:
				return (m_Plane == null) ? Plane() : m_Plane;
			case PrimitivePlusType.PrismHexagon:
				return (m_PrismHexagon == null) ? PrismHexagon() : m_PrismHexagon;
			case PrimitivePlusType.PrismOctagon:
				return (m_PrismOctagon == null) ? PrismOctagon() : m_PrismOctagon;
			case PrimitivePlusType.PrismPentagon:
				return (m_PrismPentagon == null) ? PrismPentagon() : m_PrismPentagon;
			case PrimitivePlusType.PrismTriangle:
				return (m_PrismTriangle == null) ? PrismTriangle() : m_PrismTriangle;
			case PrimitivePlusType.Pyramid:
				return (m_Pyramid == null) ? Pyramid() : m_Pyramid;
			case PrimitivePlusType.PyramidCorner:
				return (m_PyramidCorner == null) ? PyramidCorner() : m_PyramidCorner;
			case PrimitivePlusType.PyramidTri:
				return (m_PyramidTri == null) ? PyramidTri() : m_PyramidTri;
			case PrimitivePlusType.Rhombus2D:
				return (m_Rhombus2D == null) ? Rhombus2D() : m_Rhombus2D;
			case PrimitivePlusType.Sphere:
				return (m_Sphere == null) ? Sphere() : m_Sphere;
			case PrimitivePlusType.SphereHalf:
				return (m_SphereHalf == null) ? SphereHalf() : m_SphereHalf;
			case PrimitivePlusType.Star:
				return (m_Star == null) ? Star() : m_Star;
			case PrimitivePlusType.Star2D:
				return (m_Star2D == null) ? Star2D() : m_Star2D;
			case PrimitivePlusType.Torus:
				return (m_Torus == null) ? Torus() : m_Torus;
			case PrimitivePlusType.TorusHalf:
				return (m_TorusHalf == null) ? TorusHalf() : m_TorusHalf;
			case PrimitivePlusType.Triangle2D:
				return (m_Triangle2D == null) ? Triangle2D() : m_Triangle2D;
			case PrimitivePlusType.Wedge:
				return (m_Wedge == null) ? Wedge() : m_Wedge;
			default:
				return null;
			}
		}
		
		private static Mesh m_Circle2D = null;
		private static Mesh Circle2D()
		{
			m_Circle2D = Resources.Load<Mesh>("Meshes/Circle2D");
			return m_Circle2D;
		}
		private static Mesh m_CircleHalf2D = null;
		private static Mesh CircleHalf2D()
		{
			m_CircleHalf2D = Resources.Load<Mesh>("Meshes/CircleHalf2D");
			return m_CircleHalf2D;
		}
		private static Mesh m_Cone = null;
		private static Mesh Cone()
		{
			m_Cone = Resources.Load<Mesh>("Meshes/Cone");
			return m_Cone;
		}
		private static Mesh m_ConeHalf = null;
		private static Mesh ConeHalf()
		{
			m_ConeHalf = Resources.Load<Mesh>("Meshes/ConeHalf");
			return m_ConeHalf;
		}
		private static Mesh m_ConeHexagon = null;
		private static Mesh ConeHexagon()
		{
			m_ConeHexagon = Resources.Load<Mesh>("Meshes/ConeHexagon");
			return m_ConeHexagon;
		}
		private static Mesh m_ConePentagon = null;
		private static Mesh ConePentagon()
		{
			m_ConePentagon = Resources.Load<Mesh>("Meshes/ConePentagon");
			return m_ConePentagon;
		}
		private static Mesh m_Cross = null;
		private static Mesh Cross()
		{
			m_Cross = Resources.Load<Mesh>("Meshes/Cross");
			return m_Cross;
		}
		private static Mesh m_Cross2D = null;
		private static Mesh Cross2D()
		{
			m_Cross2D = Resources.Load<Mesh>("Meshes/Cross2D");
			return m_Cross2D;
		}
		private static Mesh m_Cube = null;
		private static Mesh Cube()
		{
			m_Cube = Resources.Load<Mesh>("Meshes/Cube");
			return m_Cube;
		}
		private static Mesh m_CubeCorner = null;
		private static Mesh CubeCorner()
		{
			m_CubeCorner = Resources.Load<Mesh>("Meshes/CubeCorner");
			return m_CubeCorner;
		}
		private static Mesh m_CubeCornerThin = null;
		private static Mesh CubeCornerThin()
		{
			m_CubeCornerThin = Resources.Load<Mesh>("Meshes/CubeCornerThin");
			return m_CubeCornerThin;
		}
		private static Mesh m_CubeEdgeIn = null;
		private static Mesh CubeEdgeIn()
		{
			m_CubeEdgeIn = Resources.Load<Mesh>("Meshes/CubeEdgeIn");
			return m_CubeEdgeIn;
		}
		private static Mesh m_CubeEdgeOut = null;
		private static Mesh CubeEdgeOut()
		{
			m_CubeEdgeOut = Resources.Load<Mesh>("Meshes/CubeEdgeOut");
			return m_CubeEdgeOut;
		}
		private static Mesh m_CubeHollow = null;
		private static Mesh CubeHollow()
		{
			m_CubeHollow = Resources.Load<Mesh>("Meshes/CubeHollow");
			return m_CubeHollow;
		}
		private static Mesh m_CubeHollowThin = null;
		private static Mesh CubeHollowThin()
		{
			m_CubeHollowThin = Resources.Load<Mesh>("Meshes/CubeHollowThin");
			return m_CubeHollowThin;
		}
		private static Mesh m_CubeTube = null;
		private static Mesh CubeTube()
		{
			m_CubeTube = Resources.Load<Mesh>("Meshes/CubeTube");
			return m_CubeTube;
		}
		private static Mesh m_Cylinder = null;
		private static Mesh Cylinder()
		{
			m_Cylinder = Resources.Load<Mesh>("Meshes/Cylinder");
			return m_Cylinder;
		}
		private static Mesh m_CylinderHalf = null;
		private static Mesh CylinderHalf()
		{
			m_CylinderHalf = Resources.Load<Mesh>("Meshes/CylinderHalf");
			return m_CylinderHalf;
		}
		private static Mesh m_CylinderTube = null;
		private static Mesh CylinderTube()
		{
			m_CylinderTube = Resources.Load<Mesh>("Meshes/CylinderTube");
			return m_CylinderTube;
		}
		private static Mesh m_CylinderTubeThin = null;
		private static Mesh CylinderTubeThin()
		{
			m_CylinderTubeThin = Resources.Load<Mesh>("Meshes/CylinderTubeThin");
			return m_CylinderTubeThin;
		}
		private static Mesh m_Diamond = null;
		private static Mesh Diamond()
		{
			m_Diamond = Resources.Load<Mesh>("Meshes/Diamond");
			return m_Diamond;
		}
		private static Mesh m_DiamondThick = null;
		private static Mesh DiamondThick()
		{
			m_DiamondThick = Resources.Load<Mesh>("Meshes/DiamondThick");
			return m_DiamondThick;
		}
		private static Mesh m_Heart = null;
		private static Mesh Heart()
		{
			m_Heart = Resources.Load<Mesh>("Meshes/Heart");
			return m_Heart;
		}
		private static Mesh m_Heart2D = null;
		private static Mesh Heart2D()
		{
			m_Heart2D = Resources.Load<Mesh>("Meshes/Heart2D");
			return m_Heart2D;
		}
		private static Mesh m_Hexagon2D = null;
		private static Mesh Hexagon2D()
		{
			m_Hexagon2D = Resources.Load<Mesh>("Meshes/Hexagon2D");
			return m_Hexagon2D;
		}
		private static Mesh m_Icosphere = null;
		private static Mesh Icosphere()
		{
			m_Icosphere = Resources.Load<Mesh>("Meshes/Icosphere");
			return m_Icosphere;
		}
		private static Mesh m_IcosphereSmall = null;
		private static Mesh IcosphereSmall()
		{
			m_IcosphereSmall = Resources.Load<Mesh>("Meshes/IcosphereSmall");
			return m_IcosphereSmall;
		}
		private static Mesh m_Plane = null;
		private static Mesh Plane()
		{
			m_Plane = Resources.Load<Mesh>("Meshes/Plane");
			return m_Plane;
		}
		private static Mesh m_PrismHexagon = null;
		private static Mesh PrismHexagon()
		{
			m_PrismHexagon = Resources.Load<Mesh>("Meshes/PrismHexagon");
			return m_PrismHexagon;
		}
		private static Mesh m_PrismOctagon = null;
		private static Mesh PrismOctagon()
		{
			m_PrismOctagon = Resources.Load<Mesh>("Meshes/PrismOctagon");
			return m_PrismOctagon;
		}
		private static Mesh m_PrismPentagon = null;
		private static Mesh PrismPentagon()
		{
			m_PrismPentagon = Resources.Load<Mesh>("Meshes/PrismPentagon");
			return m_PrismPentagon;
		}
		private static Mesh m_PrismTriangle = null;
		private static Mesh PrismTriangle()
		{
			m_PrismTriangle = Resources.Load<Mesh>("Meshes/PrismTriangle");
			return m_PrismTriangle;
		}
		private static Mesh m_Pyramid = null;
		private static Mesh Pyramid()
		{
			m_Pyramid = Resources.Load<Mesh>("Meshes/Pyramid");
			return m_Pyramid;
		}
		private static Mesh m_PyramidCorner = null;
		private static Mesh PyramidCorner()
		{
			m_PyramidCorner = Resources.Load<Mesh>("Meshes/PyramidCorner");
			return m_PyramidCorner;
		}
		private static Mesh m_PyramidTri = null;
		private static Mesh PyramidTri()
		{
			m_PyramidTri = Resources.Load<Mesh>("Meshes/PyramidTri");
			return m_PyramidTri;
		}
		private static Mesh m_Rhombus2D = null;
		private static Mesh Rhombus2D()
		{
			m_Rhombus2D = Resources.Load<Mesh>("Meshes/Rhombus2D");
			return m_Rhombus2D;
		}
		private static Mesh m_Sphere = null;
		private static Mesh Sphere()
		{
			m_Sphere = Resources.Load<Mesh>("Meshes/Sphere");
			return m_Sphere;
		}
		private static Mesh m_SphereHalf = null;
		private static Mesh SphereHalf()
		{
			m_SphereHalf = Resources.Load<Mesh>("Meshes/SphereHalf");
			return m_SphereHalf;
		}
		private static Mesh m_Star = null;
		private static Mesh Star()
		{
			m_Star = Resources.Load<Mesh>("Meshes/Star");
			return m_Star;
		}
		private static Mesh m_Star2D = null;
		private static Mesh Star2D()
		{
			m_Star2D = Resources.Load<Mesh>("Meshes/Star2D");
			return m_Star2D;
		}
		private static Mesh m_Torus = null;
		private static Mesh Torus()
		{
			m_Torus = Resources.Load<Mesh>("Meshes/Torus");
			return m_Torus;
		}
		private static Mesh m_TorusHalf = null;
		private static Mesh TorusHalf()
		{
			m_TorusHalf = Resources.Load<Mesh>("Meshes/TorusHalf");
			return m_TorusHalf;
		}
		private static Mesh m_Triangle2D = null;
		private static Mesh Triangle2D()
		{
			m_Triangle2D = Resources.Load<Mesh>("Meshes/Triangle2D");
			return m_Triangle2D;
		}
		private static Mesh m_Wedge = null;
		private static Mesh Wedge()
		{
			m_Wedge = Resources.Load<Mesh>("Meshes/Wedge");
			return m_Wedge;
		}
		private static Mesh GetMesh(Vector3[] vertices, Vector3[] normals, Vector2[] uv, int[] triangles)
		{
			Mesh mesh = new Mesh();
			mesh.vertices = vertices;
			mesh.normals = normals;
			mesh.uv = uv;
			mesh.triangles = triangles;
			mesh.RecalculateBounds();
			;
			return mesh;
		}
	}
}
