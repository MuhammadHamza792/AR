using System;
using AYellowpaper.SerializedCollections;
using DG.Tweening;
using UnityEngine;

namespace _Project.Scripts
{
    [Serializable]
    public class UIPanelDictionary : 
        SerializedDictionary<string , CanvasGroup>{}
    
    public class UIController : Singleton<UIController>
    {
        [SerializeField] private UIPanelDictionary _uiPanels;

        private CanvasGroup _currentPanel;

        protected override void Awake()
        {
            base.Awake();
            ResetAllUI();
        }

        private void ResetAllUI()
        {
            foreach (var canvasGroup in _uiPanels.Values)
            {
                canvasGroup.gameObject.SetActive(false);
            }
        }

        public static void ShowUI(string name) => Instance._ShowUI(name);

        private void _ShowUI(string name)
        {
            if (_uiPanels.TryGetValue(name, out _))
            {
                ChangeUI(_uiPanels[name]);
            }
            else
            {
                Debug.LogError("Undefined ui panel " + name);
            }
        }

        private void ChangeUI(CanvasGroup uiPanel)
        {
            if(uiPanel == _currentPanel) return;
            if(_currentPanel) FadeOut(_currentPanel);
            _currentPanel = uiPanel;
            if(uiPanel) FadeIn(uiPanel);
        }

        private void FadeIn(CanvasGroup panel)
        {
            panel.gameObject.SetActive(true);
            panel.DOFade(1f, .5f);
        }
        
        private void FadeOut(CanvasGroup panel)
        {
            panel.gameObject.SetActive(true);
            panel.DOFade(0f, .5f).OnComplete(() =>
                panel.gameObject.SetActive(false));
        }
    }
}
