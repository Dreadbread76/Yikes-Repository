using UnityEngine;

namespace EggRunner.Lara
{
    public class SpawnManager : MonoBehaviour
    {
        PlatformSpawner trackSpawner;
        

        // Start is called before the first frame update
        void Start()
        {
            trackSpawner = GetComponent<PlatformSpawner>();
        }

        //When enter trigger, call move track function
        public void SpawnTriggerEnt()
        {
           trackSpawner.EndlessPlatforms();
        }

        private void Update()
        {
            
        }
    }
}
