using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

namespace _Project.Scripts
{
    public class ChangeableFace : MonoBehaviour
    {
        Dictionary<GameObject, GameObject> accessories = new();
        
        GameObject currentPosePrefab;
        GameObject poseObj;
        
        ARFaceMeshVisualizer meshVisualizer;
        MeshRenderer renderer;

        private void Start()
        {
            meshVisualizer =
                GetComponent<ARFaceMeshVisualizer>();
            meshVisualizer.enabled = false;
            renderer = GetComponent<MeshRenderer>();
            renderer.enabled = false;
        }
        
        public void SetMeshMaterial(Material mat)
        {
            if (mat == null)
            {
                meshVisualizer.enabled = false;
                renderer.enabled = false;
                return;
            }
            renderer.material = mat;
            meshVisualizer.enabled = true;
            renderer.enabled = true;
        }
        
        public void AddAccessory(GameObject prefab)
        {
            if (accessories.TryGetValue(prefab, out var obj) &&
                obj.activeInHierarchy)
            {
                obj.SetActive(false);
            }
            else if (obj != null)
            {
                obj.SetActive(true);
            }
            else
            {
                obj = Instantiate(prefab, transform, false);
                accessories.Add(prefab, obj);
            }
        }
        
        public void ResetAccessories()
        {
            foreach (var prefab in accessories.Keys)
            {
                accessories[prefab].SetActive(false);
            }
        }
        
        public void SetPosePrefab(GameObject prefab)
        {
            if (prefab == currentPosePrefab)
                return;
            if (poseObj != null)
                Destroy(poseObj);
            currentPosePrefab = prefab;
            if (prefab != null)
                poseObj = Instantiate(prefab, transform, false);
        }
        
        
    }
}
