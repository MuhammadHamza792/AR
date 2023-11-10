using UnityEngine;

namespace _Project.Scripts
{
    public class FramedPhoto : MonoBehaviour
    {
        [SerializeField] Transform scalerObject;
        [SerializeField] GameObject imageObject;
        
        ImageInfo _imageInfo;
        
        public void SetImage(ImageInfo image)
        {
            _imageInfo = image;
            var renderer = 
                imageObject.GetComponent<Renderer>();
            var material = renderer.material;
            material.SetTexture("_MainTex", _imageInfo.texture);
        }
    }
}
