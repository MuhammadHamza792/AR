using System;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

namespace _Project.Scripts.Modes
{
    public class StartupMode : MonoBehaviour
    {
        [SerializeField] private string _nextMode = "Scan";

        private void OnEnable() => UIController.ShowUI("Startup");

        private void Update()
        {
            switch (ARSession.state)
            {
                case ARSessionState.Unsupported:
                    InteractionController.EnableMode("NonAR");
                    break;
                case >= ARSessionState.Ready:
                    InteractionController.EnableMode(_nextMode);
                    break;
            }
        }
    }
}
