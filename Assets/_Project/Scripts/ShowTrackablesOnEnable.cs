using System;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

namespace _Project.Scripts
{
    public class ShowTrackablesOnEnable : MonoBehaviour
    {
        [SerializeField] XROrigin sessionOrigin;
        ARPlaneManager planeManager;
        ARPointCloudManager cloudManager;
        
        bool isStarted;

        private void Awake()
        {
            planeManager = sessionOrigin.GetComponent<ARPlaneManager>();
            cloudManager = sessionOrigin.GetComponent<ARPointCloudManager>();
        }

        void OnEnable() => ShowTrackables(true);

        private void Start() => isStarted = true;

        private void ShowTrackables(bool show)
        {
            if (cloudManager)
            {
                cloudManager.SetTrackablesActive(show);
                cloudManager.enabled = show;
            }
            
            if (planeManager)
            {
                planeManager.SetTrackablesActive(show);
                planeManager.enabled = show;
            }
        }
        
        void OnDisable()
        {
            if (isStarted)
            {
                ShowTrackables(false);
            }
        }
    }
}
