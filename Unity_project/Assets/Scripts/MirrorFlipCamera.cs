 using UnityEngine;
 [RequireComponent(typeof(Camera))]
 [ExecuteInEditMode]
 public class MirrorFlipCamera : MonoBehaviour {
     new Camera camera;
     public bool flipHorizontal;
     void Awake () {
         camera = GetComponent<Camera>();
     }
     void OnPreCull() {
         camera.ResetWorldToCameraMatrix();
         camera.ResetProjectionMatrix();
         Vector3 scale = new Vector3(flipHorizontal ? -1 : 1, 1, 1);
         camera.projectionMatrix = camera.projectionMatrix * Matrix4x4.Scale(scale);
     }
     void OnPreRender () {
         GL.invertCulling = flipHorizontal;
     }
     
     void OnPostRender () {
         GL.invertCulling = false;
     }
 }