using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace _Project.Scripts
{
    public class PlaceObjectMode : MonoBehaviour
    {
        [SerializeField] ARRaycastManager raycaster;
        GameObject placedPrefab;
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        
        void OnEnable()
        {
            UIController.ShowUI("PlaceObject");
        }
        
        public void SetPlacedPrefab(GameObject prefab)
        {
            placedPrefab = prefab;
        }

        public void Update()
        {
            if (!Input.GetMouseButtonDown(0)) return;
            PlaceObject(Input.mousePosition);
        }

        private void PlaceObject(Vector2 touchPosition)
        {
            if (raycaster.Raycast(touchPosition, hits,
                    TrackableType.PlaneWithinPolygon))
            {
                Pose hitPose = hits[0].pose;
                Instantiate(placedPrefab, hitPose.position,
                    hitPose.rotation);
                InteractionController.EnableMode("Main");
            }
        }
    }
}
