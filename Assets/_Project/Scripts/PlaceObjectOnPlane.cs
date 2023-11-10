using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace _Project.Scripts
{
    public class PlaceObjectOnPlane : MonoBehaviour
    {
        [SerializeField] private GameObject _objectToSpawn;
        [SerializeField] private ARRaycastManager _raycaster;

        private List<ARRaycastHit> _hits;
        private GameObject _spawnedObject;
        
        public void Update()
        {
            if(!Input.GetMouseButtonDown(0)) return;
            SpawnOrMoveObject(Input.mousePosition);
        }

        private void SpawnOrMoveObject(Vector2 touchPos)
        {
            _hits ??= new List<ARRaycastHit>();

            if (_hits.Count > 0)
                _hits.Clear();

            if (!_raycaster.Raycast(touchPos, _hits, TrackableType.PlaneWithinPolygon)) return;

            var hit = _hits[0];
            if (!_spawnedObject)
                _spawnedObject = Instantiate(_objectToSpawn, hit.pose.position, hit.pose.rotation);
            else
                _spawnedObject.transform.SetPositionAndRotation(hit.pose.position, hit.pose.rotation);
            
        }
    }
}
