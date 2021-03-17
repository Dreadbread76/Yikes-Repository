using UnityEngine;

namespace EggRunner.Lara
{
    public class Platform : MonoBehaviour
    {

        [Tooltip("The inactive box collider that represents the size of the platform.")]
        public GameObject track;
        public BoxCollider bounds;
        public ObjectSpawner objectSpawner;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
               
               
                Destroy(track.gameObject);
            }
        }
    }
    
}
