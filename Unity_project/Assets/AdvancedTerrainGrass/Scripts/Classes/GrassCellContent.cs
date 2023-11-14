using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;


namespace AdvancedTerrainGrass {

	[Serializable] 
	public class GrassCellContent  {

		public int index;
		public int Layer;

		public int[] SoftlyMergedLayers;

		public int state = 0; // 0 -> not initialized; 1 -> queued; 2 -> readyToInitialize; 3 -> initialized

		public Mesh v_mesh;
		public Material v_mat;
		public Material d_mat;

        public int GrassMatrixBufferPID;

		public ShadowCastingMode ShadowCastingMode = ShadowCastingMode.Off;

		public int Instances;
		public Vector3 Center;	// center in world space
		public Vector3 Pivot; 	// lower left corner in local terrain space
		
		public Matrix4x4[] v_matrices;
		
		public int PatchOffsetX;
		public int PatchOffsetZ;

        [System.NonSerialized]
        public ComputeBuffer matrixBuffer;
        [System.NonSerialized]
        public ComputeBuffer argsBuffer;
        [System.NonSerialized]
        public uint[] args = new uint[5] { 0, 0, 0, 0, 0 };

		private Bounds bounds = new Bounds();

		#if !UNITY_5_6_0 && !UNITY_5_6_1 && !UNITY_5_6_2
			public MaterialPropertyBlock block;
		#endif

	//	Function used to release a complete cellcontent – as on disable.	
		public void ReleaseCompleteCellContent() {
			state = 0;
			v_matrices = null;
			block.Clear();
			if(matrixBuffer != null) {
				matrixBuffer.Release();
			}
			if(argsBuffer != null) {
				argsBuffer.Release();
			}
		}

	//	Function used to release a cellcontent when it gets out of cache distance – this one only releases the memory heavy matrixbuffer.
		public void ReleaseCellContent() {
			state = 0;
			v_matrices = null;
			block.Clear();
			if(matrixBuffer != null) {
				matrixBuffer.Release();
			}
		}


		public void InitCellContent_Delegated(bool UseCompute, bool usingSinglePassInstanced) {

		//	Safe guard - needed in some rare cases i could not reproduce... checking state == 3 did not work out?!
			if (v_matrices == null) {
				return;
			}

        //  Update number of Instances as it is used by Compute
            Instances = v_matrices.Length;

            UnityEngine.Profiling.Profiler.BeginSample("Create Matrix Buffer");
                if(Instances == 0) {
                    state = 0;
                    return;
                }
				matrixBuffer = new ComputeBuffer(Instances, 64);
				matrixBuffer.SetData(v_matrices);
			UnityEngine.Profiling.Profiler.EndSample();
        
        //  No need to keep the matrix array
            v_matrices = null;

            if (!UseCompute) {
                #if UNITY_5_6_0 || UNITY_5_6_1 || UNITY_5_6_2
            	    v_mat.SetBuffer(GrassMatrixBufferPID, matrixBuffer);
                #else
                    UnityEngine.Profiling.Profiler.BeginSample("Set MaterialPropertyBlock");
                    block.Clear();
                    block.SetBuffer(GrassMatrixBufferPID, matrixBuffer);
                    UnityEngine.Profiling.Profiler.EndSample();
                #endif

                UnityEngine.Profiling.Profiler.BeginSample("Set Args Buffer");
                uint numIndices = (v_mesh != null) ? (uint)v_mesh.GetIndexCount(0) : 0;
             
                args[0] = numIndices;
			//  When using single pass instanced stereo rendering we have to double the number of instances?!
                if (usingSinglePassInstanced) {
                	args[1] = (uint)(Instances * 2);
                }
                else {
                	args[1] = (uint)Instances;
                }


                argsBuffer.SetData(args);
                UnityEngine.Profiling.Profiler.EndSample();

                bounds.center = Center;
            //	Mind order to get proper Extent :) (otherwise point lights might get lost)
                var Extent = (Pivot.x - Center.x) * 2.0f;
                bounds.extents = new Vector3(Extent, Extent, Extent);
            }
        //	Now we are ready to go.
        	state = 3;
	    }


		public void DrawCellContent_Delegated(Camera CameraInWichGrassWillBeDrawn, int CameraLayer, Vector3 TerrainShift, LightProbeProxyVolume lppv, bool useLppv) {

            var t_bounds = bounds;
            var pos = t_bounds.center;
            pos.x -= TerrainShift.x;
            pos.y -= TerrainShift.y;
            pos.z -= TerrainShift.z;
            t_bounds.center = pos;
            
            if(useLppv) {
	            Graphics.DrawMeshInstancedIndirect(
					v_mesh,
					0, 
					v_mat,
					t_bounds,
					argsBuffer,
					0,
	                block,
	                ShadowCastingMode,
					true,
					CameraLayer,
					CameraInWichGrassWillBeDrawn,
					LightProbeUsage.UseProxyVolume,
                    lppv
				);
			}
			
			else {
				Graphics.DrawMeshInstancedIndirect(
					v_mesh,
					0, 
					v_mat,
					t_bounds,
					argsBuffer,
					0,
					#if UNITY_5_6_0 || UNITY_5_6_1 || UNITY_5_6_2
	                	null,
					#else
	                	block,
					#endif
	                ShadowCastingMode,
					true,
					CameraLayer,
					CameraInWichGrassWillBeDrawn
				);	
			}
		}
	}
}
