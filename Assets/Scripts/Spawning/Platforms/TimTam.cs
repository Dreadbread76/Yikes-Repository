using UnityEngine;

namespace EggRunner.Lara
{
    public class TimTam : MonoBehaviour
    {
        [Tooltip("The inactive box collider that represents the size of the tim tam.")]
        public BoxCollider ttBounds;

        public void OnTriggerStay(Collider other)
        {
            if (other.gameObject.CompareTag("Meat"))
            {
                Destroy(other.gameObject);
            }
        }
    }

  
}
