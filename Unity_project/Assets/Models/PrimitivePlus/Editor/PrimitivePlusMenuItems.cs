using UnityEngine;
using UnityEditor;
using PrimitivePlus;
using System.Collections;

namespace PrimitivePlusEditor
{
	public class PrimitivePlusMenuItems
	{
		#if UNITY_4_5
		[MenuItem("GameObject/Create Other/Primitive Plus/2D Objects/Circle2D", false, -1)]
		#else
		[MenuItem("GameObject/Primitive Plus/2D Objects/Circle2D", false, -1)]
		#endif
		private static void CreateCircle2D(MenuCommand command)
		{
			AddPrimitiveObjectToScene(PrimitivePlusObject.CreatePrimitivePlus(PrimitivePlusType.Circle2D), (GameObject)command.context);
		}
		
		#if UNITY_4_5
		[MenuItem("GameObject/Create Other/Primitive Plus/2D Objects/CircleHalf2D", false, -1)]
		#else
		[MenuItem("GameObject/Primitive Plus/2D Objects/CircleHalf2D", false, -1)]
		#endif
		private static void CreateCircleHalf2D(MenuCommand command)
		{
			AddPrimitiveObjectToScene(PrimitivePlusObject.CreatePrimitivePlus(PrimitivePlusType.CircleHalf2D), (GameObject)command.context);
		}
		
		#if UNITY_4_5
		[MenuItem("GameObject/Create Other/Primitive Plus/Cone", false, -1)]
		#else
		[MenuItem("GameObject/Primitive Plus/Cone", false, -1)]
		#endif
		private static void CreateCone(MenuCommand command)
		{
			AddPrimitiveObjectToScene(PrimitivePlusObject.CreatePrimitivePlus(PrimitivePlusType.Cone), (GameObject)command.context);
		}
		
		#if UNITY_4_5
		[MenuItem("GameObject/Create Other/Primitive Plus/ConeHalf", false, -1)]
		#else
		[MenuItem("GameObject/Primitive Plus/ConeHalf", false, -1)]
		#endif
		private static void CreateConeHalf(MenuCommand command)
		{
			AddPrimitiveObjectToScene(PrimitivePlusObject.CreatePrimitivePlus(PrimitivePlusType.ConeHalf), (GameObject)command.context);
		}
		
		#if UNITY_4_5
		[MenuItem("GameObject/Create Other/Primitive Plus/ConeHexagon", false, -1)]
		#else
		[MenuItem("GameObject/Primitive Plus/ConeHexagon", false, -1)]
		#endif
		private static void CreateConeHexagon(MenuCommand command)
		{
			AddPrimitiveObjectToScene(PrimitivePlusObject.CreatePrimitivePlus(PrimitivePlusType.ConeHexagon), (GameObject)command.context);
		}
		
		#if UNITY_4_5
		[MenuItem("GameObject/Create Other/Primitive Plus/ConePentagon", false, -1)]
		#else
		[MenuItem("GameObject/Primitive Plus/ConePentagon", false, -1)]
		#endif
		private static void CreateConePentagon(MenuCommand command)
		{
			AddPrimitiveObjectToScene(PrimitivePlusObject.CreatePrimitivePlus(PrimitivePlusType.ConePentagon), (GameObject)command.context);
		}
		
		#if UNITY_4_5
		[MenuItem("GameObject/Create Other/Primitive Plus/Cross", false, -1)]
		#else
		[MenuItem("GameObject/Primitive Plus/Cross", false, -1)]
		#endif
		private static void CreateCross(MenuCommand command)
		{
			AddPrimitiveObjectToScene(PrimitivePlusObject.CreatePrimitivePlus(PrimitivePlusType.Cross), (GameObject)command.context);
		}
		
		#if UNITY_4_5
		[MenuItem("GameObject/Create Other/Primitive Plus/2D Objects/Cross2D", false, -1)]
		#else
		[MenuItem("GameObject/Primitive Plus/2D Objects/Cross2D", false, -1)]
		#endif
		private static void CreateCross2D(MenuCommand command)
		{
			AddPrimitiveObjectToScene(PrimitivePlusObject.CreatePrimitivePlus(PrimitivePlusType.Cross2D), (GameObject)command.context);
		}
		
		#if UNITY_4_5
		[MenuItem("GameObject/Create Other/Primitive Plus/Cube", false, -1)]
		#else
		[MenuItem("GameObject/Primitive Plus/Cube", false, -1)]
		#endif
		private static void CreateCube(MenuCommand command)
		{
			AddPrimitiveObjectToScene(PrimitivePlusObject.CreatePrimitivePlus(PrimitivePlusType.Cube), (GameObject)command.context);
		}
		
		#if UNITY_4_5
		[MenuItem("GameObject/Create Other/Primitive Plus/CubeCorner", false, -1)]
		#else
		[MenuItem("GameObject/Primitive Plus/CubeCorner", false, -1)]
		#endif
		private static void CreateCubeCorner(MenuCommand command)
		{
			AddPrimitiveObjectToScene(PrimitivePlusObject.CreatePrimitivePlus(PrimitivePlusType.CubeCorner), (GameObject)command.context);
		}
		
		#if UNITY_4_5
		[MenuItem("GameObject/Create Other/Primitive Plus/CubeCornerThin", false, -1)]
		#else
		[MenuItem("GameObject/Primitive Plus/CubeCornerThin", false, -1)]
		#endif
		private static void CreateCubeCornerThin(MenuCommand command)
		{
			AddPrimitiveObjectToScene(PrimitivePlusObject.CreatePrimitivePlus(PrimitivePlusType.CubeCornerThin), (GameObject)command.context);
		}
		
		#if UNITY_4_5
		[MenuItem("GameObject/Create Other/Primitive Plus/CubeEdgeIn", false, -1)]
		#else
		[MenuItem("GameObject/Primitive Plus/CubeEdgeIn", false, -1)]
		#endif
		private static void CreateCubeEdgeIn(MenuCommand command)
		{
			AddPrimitiveObjectToScene(PrimitivePlusObject.CreatePrimitivePlus(PrimitivePlusType.CubeEdgeIn), (GameObject)command.context);
		}
		
		#if UNITY_4_5
		[MenuItem("GameObject/Create Other/Primitive Plus/CubeEdgeOut", false, -1)]
		#else
		[MenuItem("GameObject/Primitive Plus/CubeEdgeOut", false, -1)]
		#endif
		private static void CreateCubeEdgeOut(MenuCommand command)
		{
			AddPrimitiveObjectToScene(PrimitivePlusObject.CreatePrimitivePlus(PrimitivePlusType.CubeEdgeOut), (GameObject)command.context);
		}
		
		#if UNITY_4_5
		[MenuItem("GameObject/Create Other/Primitive Plus/CubeHollow", false, -1)]
		#else
		[MenuItem("GameObject/Primitive Plus/CubeHollow", false, -1)]
		#endif
		private static void CreateCubeHollow(MenuCommand command)
		{
			AddPrimitiveObjectToScene(PrimitivePlusObject.CreatePrimitivePlus(PrimitivePlusType.CubeHollow), (GameObject)command.context);
		}
		
		#if UNITY_4_5
		[MenuItem("GameObject/Create Other/Primitive Plus/CubeHollowThin", false, -1)]
		#else
		[MenuItem("GameObject/Primitive Plus/CubeHollowThin", false, -1)]
		#endif
		private static void CreateCubeHollowThin(MenuCommand command)
		{
			AddPrimitiveObjectToScene(PrimitivePlusObject.CreatePrimitivePlus(PrimitivePlusType.CubeHollowThin), (GameObject)command.context);
		}
		
		#if UNITY_4_5
		[MenuItem("GameObject/Create Other/Primitive Plus/CubeTube", false, -1)]
		#else
		[MenuItem("GameObject/Primitive Plus/CubeTube", false, -1)]
		#endif
		private static void CreateCubeTube(MenuCommand command)
		{
			AddPrimitiveObjectToScene(PrimitivePlusObject.CreatePrimitivePlus(PrimitivePlusType.CubeTube), (GameObject)command.context);
		}
		
		#if UNITY_4_5
		[MenuItem("GameObject/Create Other/Primitive Plus/Cylinder", false, -1)]
		#else
		[MenuItem("GameObject/Primitive Plus/Cylinder", false, -1)]
		#endif
		private static void CreateCylinder(MenuCommand command)
		{
			AddPrimitiveObjectToScene(PrimitivePlusObject.CreatePrimitivePlus(PrimitivePlusType.Cylinder), (GameObject)command.context);
		}
		
		#if UNITY_4_5
		[MenuItem("GameObject/Create Other/Primitive Plus/CylinderHalf", false, -1)]
		#else
		[MenuItem("GameObject/Primitive Plus/CylinderHalf", false, -1)]
		#endif
		private static void CreateCylinderHalf(MenuCommand command)
		{
			AddPrimitiveObjectToScene(PrimitivePlusObject.CreatePrimitivePlus(PrimitivePlusType.CylinderHalf), (GameObject)command.context);
		}
		
		#if UNITY_4_5
		[MenuItem("GameObject/Create Other/Primitive Plus/CylinderTube", false, -1)]
		#else
		[MenuItem("GameObject/Primitive Plus/CylinderTube", false, -1)]
		#endif
		private static void CreateCylinderTube(MenuCommand command)
		{
			AddPrimitiveObjectToScene(PrimitivePlusObject.CreatePrimitivePlus(PrimitivePlusType.CylinderTube), (GameObject)command.context);
		}
		
		#if UNITY_4_5
		[MenuItem("GameObject/Create Other/Primitive Plus/CylinderTubeThin", false, -1)]
		#else
		[MenuItem("GameObject/Primitive Plus/CylinderTubeThin", false, -1)]
		#endif
		private static void CreateCylinderTubeThin(MenuCommand command)
		{
			AddPrimitiveObjectToScene(PrimitivePlusObject.CreatePrimitivePlus(PrimitivePlusType.CylinderTubeThin), (GameObject)command.context);
		}
		
		#if UNITY_4_5
		[MenuItem("GameObject/Create Other/Primitive Plus/Diamond", false, -1)]
		#else
		[MenuItem("GameObject/Primitive Plus/Diamond", false, -1)]
		#endif
		private static void CreateDiamond(MenuCommand command)
		{
			AddPrimitiveObjectToScene(PrimitivePlusObject.CreatePrimitivePlus(PrimitivePlusType.Diamond), (GameObject)command.context);
		}
		
		#if UNITY_4_5
		[MenuItem("GameObject/Create Other/Primitive Plus/DiamondThick", false, -1)]
		#else
		[MenuItem("GameObject/Primitive Plus/DiamondThick", false, -1)]
		#endif
		private static void CreateDiamondThick(MenuCommand command)
		{
			AddPrimitiveObjectToScene(PrimitivePlusObject.CreatePrimitivePlus(PrimitivePlusType.DiamondThick), (GameObject)command.context);
		}
		
		#if UNITY_4_5
		[MenuItem("GameObject/Create Other/Primitive Plus/Heart", false, -1)]
		#else
		[MenuItem("GameObject/Primitive Plus/Heart", false, -1)]
		#endif
		private static void CreateHeart(MenuCommand command)
		{
			AddPrimitiveObjectToScene(PrimitivePlusObject.CreatePrimitivePlus(PrimitivePlusType.Heart), (GameObject)command.context);
		}
		
		#if UNITY_4_5
		[MenuItem("GameObject/Create Other/Primitive Plus/2D Objects/Heart2D", false, -1)]
		#else
		[MenuItem("GameObject/Primitive Plus/2D Objects/Heart2D", false, -1)]
		#endif
		private static void CreateHeart2D(MenuCommand command)
		{
			AddPrimitiveObjectToScene(PrimitivePlusObject.CreatePrimitivePlus(PrimitivePlusType.Heart2D), (GameObject)command.context);
		}
		
		#if UNITY_4_5
		[MenuItem("GameObject/Create Other/Primitive Plus/2D Objects/Hexagon2D", false, -1)]
		#else
		[MenuItem("GameObject/Primitive Plus/2D Objects/Hexagon2D", false, -1)]
		#endif
		private static void CreateHexagon2D(MenuCommand command)
		{
			AddPrimitiveObjectToScene(PrimitivePlusObject.CreatePrimitivePlus(PrimitivePlusType.Hexagon2D), (GameObject)command.context);
		}
		
		#if UNITY_4_5
		[MenuItem("GameObject/Create Other/Primitive Plus/Icosphere", false, -1)]
		#else
		[MenuItem("GameObject/Primitive Plus/Icosphere", false, -1)]
		#endif
		private static void CreateIcosphere(MenuCommand command)
		{
			AddPrimitiveObjectToScene(PrimitivePlusObject.CreatePrimitivePlus(PrimitivePlusType.Icosphere), (GameObject)command.context);
		}
		
		#if UNITY_4_5
		[MenuItem("GameObject/Create Other/Primitive Plus/IcosphereSmall", false, -1)]
		#else
		[MenuItem("GameObject/Primitive Plus/IcosphereSmall", false, -1)]
		#endif
		private static void CreateIcosphereSmall(MenuCommand command)
		{
			AddPrimitiveObjectToScene(PrimitivePlusObject.CreatePrimitivePlus(PrimitivePlusType.IcosphereSmall), (GameObject)command.context);
		}
		
		#if UNITY_4_5
		[MenuItem("GameObject/Create Other/Primitive Plus/Plane", false, -1)]
		#else
		[MenuItem("GameObject/Primitive Plus/Plane", false, -1)]
		#endif
		private static void CreatePlane(MenuCommand command)
		{
			AddPrimitiveObjectToScene(PrimitivePlusObject.CreatePrimitivePlus(PrimitivePlusType.Plane), (GameObject)command.context);
		}
		
		#if UNITY_4_5
		[MenuItem("GameObject/Create Other/Primitive Plus/PrismHexagon", false, -1)]
		#else
		[MenuItem("GameObject/Primitive Plus/PrismHexagon", false, -1)]
		#endif
		private static void CreatePrismHexagon(MenuCommand command)
		{
			AddPrimitiveObjectToScene(PrimitivePlusObject.CreatePrimitivePlus(PrimitivePlusType.PrismHexagon), (GameObject)command.context);
		}
		
		#if UNITY_4_5
		[MenuItem("GameObject/Create Other/Primitive Plus/PrismOctagon", false, -1)]
		#else
		[MenuItem("GameObject/Primitive Plus/PrismOctagon", false, -1)]
		#endif
		private static void CreatePrismOctagon(MenuCommand command)
		{
			AddPrimitiveObjectToScene(PrimitivePlusObject.CreatePrimitivePlus(PrimitivePlusType.PrismOctagon), (GameObject)command.context);
		}
		
		#if UNITY_4_5
		[MenuItem("GameObject/Create Other/Primitive Plus/PrismPentagon", false, -1)]
		#else
		[MenuItem("GameObject/Primitive Plus/PrismPentagon", false, -1)]
		#endif
		private static void CreatePrismPentagon(MenuCommand command)
		{
			AddPrimitiveObjectToScene(PrimitivePlusObject.CreatePrimitivePlus(PrimitivePlusType.PrismPentagon), (GameObject)command.context);
		}
		
		#if UNITY_4_5
		[MenuItem("GameObject/Create Other/Primitive Plus/PrismTriangle", false, -1)]
		#else
		[MenuItem("GameObject/Primitive Plus/PrismTriangle", false, -1)]
		#endif
		private static void CreatePrismTriangle(MenuCommand command)
		{
			AddPrimitiveObjectToScene(PrimitivePlusObject.CreatePrimitivePlus(PrimitivePlusType.PrismTriangle), (GameObject)command.context);
		}
		
		#if UNITY_4_5
		[MenuItem("GameObject/Create Other/Primitive Plus/Pyramid", false, -1)]
		#else
		[MenuItem("GameObject/Primitive Plus/Pyramid", false, -1)]
		#endif
		private static void CreatePyramid(MenuCommand command)
		{
			AddPrimitiveObjectToScene(PrimitivePlusObject.CreatePrimitivePlus(PrimitivePlusType.Pyramid), (GameObject)command.context);
		}
		
		#if UNITY_4_5
		[MenuItem("GameObject/Create Other/Primitive Plus/PyramidCorner", false, -1)]
		#else
		[MenuItem("GameObject/Primitive Plus/PyramidCorner", false, -1)]
		#endif
		private static void CreatePyramidCorner(MenuCommand command)
		{
			AddPrimitiveObjectToScene(PrimitivePlusObject.CreatePrimitivePlus(PrimitivePlusType.PyramidCorner), (GameObject)command.context);
		}
		
		#if UNITY_4_5
		[MenuItem("GameObject/Create Other/Primitive Plus/PyramidTri", false, -1)]
		#else
		[MenuItem("GameObject/Primitive Plus/PyramidTri", false, -1)]
		#endif
		private static void CreatePyramidTri(MenuCommand command)
		{
			AddPrimitiveObjectToScene(PrimitivePlusObject.CreatePrimitivePlus(PrimitivePlusType.PyramidTri), (GameObject)command.context);
		}
		
		#if UNITY_4_5
		[MenuItem("GameObject/Create Other/Primitive Plus/2D Objects/Rhombus2D", false, -1)]
		#else
		[MenuItem("GameObject/Primitive Plus/2D Objects/Rhombus2D", false, -1)]
		#endif
		private static void CreateRhombus2D(MenuCommand command)
		{
			AddPrimitiveObjectToScene(PrimitivePlusObject.CreatePrimitivePlus(PrimitivePlusType.Rhombus2D), (GameObject)command.context);
		}
		
		#if UNITY_4_5
		[MenuItem("GameObject/Create Other/Primitive Plus/Sphere", false, -1)]
		#else
		[MenuItem("GameObject/Primitive Plus/Sphere", false, -1)]
		#endif
		private static void CreateSphere(MenuCommand command)
		{
			AddPrimitiveObjectToScene(PrimitivePlusObject.CreatePrimitivePlus(PrimitivePlusType.Sphere), (GameObject)command.context);
		}
		
		#if UNITY_4_5
		[MenuItem("GameObject/Create Other/Primitive Plus/SphereHalf", false, -1)]
		#else
		[MenuItem("GameObject/Primitive Plus/SphereHalf", false, -1)]
		#endif
		private static void CreateSphereHalf(MenuCommand command)
		{
			AddPrimitiveObjectToScene(PrimitivePlusObject.CreatePrimitivePlus(PrimitivePlusType.SphereHalf), (GameObject)command.context);
		}
		
		#if UNITY_4_5
		[MenuItem("GameObject/Create Other/Primitive Plus/Star", false, -1)]
		#else
		[MenuItem("GameObject/Primitive Plus/Star", false, -1)]
		#endif
		private static void CreateStar(MenuCommand command)
		{
			AddPrimitiveObjectToScene(PrimitivePlusObject.CreatePrimitivePlus(PrimitivePlusType.Star), (GameObject)command.context);
		}
		
		#if UNITY_4_5
		[MenuItem("GameObject/Create Other/Primitive Plus/2D Objects/Star2D", false, -1)]
		#else
		[MenuItem("GameObject/Primitive Plus/2D Objects/Star2D", false, -1)]
		#endif
		private static void CreateStar2D(MenuCommand command)
		{
			AddPrimitiveObjectToScene(PrimitivePlusObject.CreatePrimitivePlus(PrimitivePlusType.Star2D), (GameObject)command.context);
		}
		
		#if UNITY_4_5
		[MenuItem("GameObject/Create Other/Primitive Plus/Torus", false, -1)]
		#else
		[MenuItem("GameObject/Primitive Plus/Torus", false, -1)]
		#endif
		private static void CreateTorus(MenuCommand command)
		{
			AddPrimitiveObjectToScene(PrimitivePlusObject.CreatePrimitivePlus(PrimitivePlusType.Torus), (GameObject)command.context);
		}
		
		#if UNITY_4_5
		[MenuItem("GameObject/Create Other/Primitive Plus/TorusHalf", false, -1)]
		#else
		[MenuItem("GameObject/Primitive Plus/TorusHalf", false, -1)]
		#endif
		private static void CreateTorusHalf(MenuCommand command)
		{
			AddPrimitiveObjectToScene(PrimitivePlusObject.CreatePrimitivePlus(PrimitivePlusType.TorusHalf), (GameObject)command.context);
		}
		
		#if UNITY_4_5
		[MenuItem("GameObject/Create Other/Primitive Plus/2D Objects/Triangle2D", false, -1)]
		#else
		[MenuItem("GameObject/Primitive Plus/2D Objects/Triangle2D", false, -1)]
		#endif
		private static void CreateTriangle2D(MenuCommand command)
		{
			AddPrimitiveObjectToScene(PrimitivePlusObject.CreatePrimitivePlus(PrimitivePlusType.Triangle2D), (GameObject)command.context);
		}
		
		#if UNITY_4_5
		[MenuItem("GameObject/Create Other/Primitive Plus/Wedge", false, -1)]
		#else
		[MenuItem("GameObject/Primitive Plus/Wedge", false, -1)]
		#endif
		private static void CreateWedge(MenuCommand command)
		{
			AddPrimitiveObjectToScene(PrimitivePlusObject.CreatePrimitivePlus(PrimitivePlusType.Wedge), (GameObject)command.context);
		}
		
		private static void AddPrimitiveObjectToScene(GameObject primitiveObject, GameObject selectedGameObject)
		{
			Vector3 newPosition = Vector3.zero;
			for(int i = 0; i < SceneView.sceneViews.Count; i++)
			{
				if(SceneView.sceneViews[i] != null)
				{
					if(selectedGameObject == null)
						newPosition = ((SceneView)SceneView.sceneViews[i]).pivot;
					break;
				}
			}
			primitiveObject.transform.rotation = Quaternion.identity;
			if(selectedGameObject != null)
				primitiveObject.transform.parent = Selection.activeGameObject.transform;
			primitiveObject.transform.localPosition = newPosition;
			Selection.activeGameObject = primitiveObject;
		}
	}
}
