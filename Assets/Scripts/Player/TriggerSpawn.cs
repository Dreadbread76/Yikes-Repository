using UnityEngine;

namespace EggRunner.Lara
{
    [RequireComponent(typeof(Rigidbody))]
    public class TriggerSpawn : MonoBehaviour
    {
        public Rigidbody rb;

        public SpawnManager spawnManager;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        // OnTriggerEnter is called when the Collider other enters the trigger
        private void OnTriggerEnter(Collider other)
        {
            spawnManager.SpawnTriggerEnt();
        }
    }
}
