using UnityEngine;

namespace _Project.Scripts
{
    [System.Serializable]
    public struct ImageInfo
    {
        public Texture texture;
        public int width;
        public int height;
    }
    
    public class ImageData : MonoBehaviour
    {
        public ImageInfo[] images;
        
        
    }
}
