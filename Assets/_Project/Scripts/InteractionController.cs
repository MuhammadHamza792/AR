using System;
using System.Collections;
using AYellowpaper.SerializedCollections;
using UnityEngine;

namespace _Project.Scripts
{
    [System.Serializable]
    public class InteractionModeDictionary :
        SerializedDictionary<string , GameObject>{ }

    public class InteractionController : 
        Singleton<InteractionController>
    {
        [SerializeField] private InteractionModeDictionary
            _interactionModeDictionary;

        private GameObject _currentMode;

        protected override void Awake()
        {
            base.Awake();
            ResetAllModes();
        }
        
        void Start()
        {
            _EnableMode("Startup");
        }
        
        public static void EnableMode(string name) => 
            Instance._EnableMode(name);

        private void _EnableMode(string name)
        {
            GameObject modeObject;
            if (_interactionModeDictionary.TryGetValue(name, out
                    modeObject))
            {
                StartCoroutine(ChangeMode(modeObject));
            }
            else
            {
                Debug.LogError("undefined mode named " +
                               name);
            }
        }

        private IEnumerator ChangeMode(GameObject mode)
        {
            if (mode == _currentMode)
                yield break;
            
            if (_currentMode)
            {
                _currentMode.SetActive(false);
                yield return null;
            }
            
            _currentMode = mode;
            mode.SetActive(true);
        }

        private void ResetAllModes()
        {
            foreach (var mode in _interactionModeDictionary.Values)
            {
                mode.gameObject.SetActive(false);
            }    
        }
    }
}
