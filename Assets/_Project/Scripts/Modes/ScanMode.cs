using System;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

namespace _Project.Scripts.Modes
{
    public class ScanMode : MonoBehaviour
    {
        [SerializeField] private ARPlaneManager _planeManager;

        private void OnEnable()
        {
            UIController.ShowUI("Scan");
        }

        private void Update()
        {
            if (_planeManager.trackables.count > 0)
            {
                InteractionController.EnableMode("Main");
            }
        }
    }
}
