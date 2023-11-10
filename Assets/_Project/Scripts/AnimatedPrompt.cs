using UnityEngine;

namespace _Project.Scripts
{
    public enum InstructionUI
    {
        CrossPlatformFindAPlane,
        FindAFace,
        FindABody,
        FindAnImage,
        FindAnObject,
        ARKitCoachingOverlay,
        TapToPlace,
        None
    }

    public class AnimatedPrompt : MonoBehaviour
    {
        [SerializeField] private InstructionUI _instructionUI;
        [SerializeField] private ARUXAnimationManager _animationManager;

        private bool _isStarted;

        private void OnEnable()
        {
            if(_isStarted)
                ShowInstructions();
        }

        private void OnDisable()
        {
            _animationManager.FadeOffCurrentUI();
        }

        private void Start()
        {
            ShowInstructions();
            _isStarted = true;
        }

        private void ShowInstructions()
        {
            switch (_instructionUI)
            {
                case InstructionUI.CrossPlatformFindAPlane:
                    _animationManager.ShowCrossPlatformFindAPlane();
                    break;
                case InstructionUI.FindAFace:
                    _animationManager.ShowFindFace();
                    break;
                case InstructionUI.FindABody:
                    _animationManager.ShowFindBody();
                    break;
                case InstructionUI.FindAnImage:
                    _animationManager.ShowFindImage();
                    break;
                case InstructionUI.FindAnObject:
                    _animationManager.ShowFindObject();
                    break;
                case InstructionUI.TapToPlace:
                    _animationManager.ShowTapToPlace();
                    break;
                default:
                    Debug.LogError("instruction switch missing, " +
                                   "please edit AnimatedPrompt.cs " + _instructionUI);
                    break;
            }
        }
    }
}
