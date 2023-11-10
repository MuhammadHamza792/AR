using System;
using UnityEngine;

namespace _Project.Scripts.Modes
{
    public class MainMode : MonoBehaviour
    {
        private void OnEnable() => UIController.ShowUI("Main");
    }
}
