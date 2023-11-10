using UnityEngine;
using UnityEngine.XR.ARFoundation;

namespace _Project.Scripts.Modes
{
    public class FaceScanMode : MonoBehaviour
    {
        [SerializeField] private ARFaceManager _faceManager;

        private void OnEnable() => UIController.ShowUI("Scan");

        private void Update()
        {
            if (_faceManager.trackables.count > 0)
            {
                InteractionController.EnableMode("Main");
            }
        }
    }
}
