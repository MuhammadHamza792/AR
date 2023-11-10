using System;
using UnityEngine;

namespace _Project.Scripts.Modes
{
    public class NonARMode : MonoBehaviour
    {
        private void OnEnable() => UIController.ShowUI("NonAR");
    }
}
