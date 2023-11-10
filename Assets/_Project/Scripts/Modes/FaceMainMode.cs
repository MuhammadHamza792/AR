using UnityEngine;
using UnityEngine.XR.ARFoundation;

namespace _Project.Scripts.Modes
{
    public class FaceMainMode : MonoBehaviour
    {
        [SerializeField] ARFaceManager faceManager;

        private void OnEnable() => UIController.ShowUI("Main");

        public void ChangePosePrefab(GameObject prefab)
        {
            foreach (var face in faceManager.trackables)
            {
                var changeable = 
                    face.GetComponent<ChangeableFace>();
                if (changeable != null)
                {
                    changeable.SetPosePrefab(prefab);
                }
            }
        }
        
        public void ChangeMaterial(Material mat)
        {
            foreach (ARFace face in faceManager.trackables)
            {
                ChangeableFace changeable = 
                    face.GetComponent<ChangeableFace>();
                if (changeable != null)
                {
                    changeable.SetMeshMaterial(mat);
                }
            }
        }
        
        public void AddAccessory(GameObject prefab)
        {
            foreach (ARFace face in faceManager.trackables)
            {
                ChangeableFace changeable = 
                    face.GetComponent<ChangeableFace>();
                if (changeable != null)
                {
                    changeable.AddAccessory(prefab);
                }
            }
        }
        
        public void ResetFace()
        {
            foreach (var face in faceManager.trackables)
            {
                var changeable = 
                    face.GetComponent<ChangeableFace>();
                if (changeable == null) continue;
                changeable.SetPosePrefab(null);
                changeable.ResetAccessories();
                changeable.SetMeshMaterial(null);
            }
        }
        
    }
}
