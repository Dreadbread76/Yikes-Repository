using UnityEngine;

namespace EggRunner.Lara
{
    public class SpawnManager : MonoBehaviour
    {
        PlatformSpawner trackSpawner;
        //ObjectSpawner objectSpawner;

        

        // Start is called before the first frame update
        void Start()
        {
            trackSpawner = GetComponent<PlatformSpawner>();
            //objectSpawner = GetComponent<ObjectSpawner>();
        }

        //When enter trigger, call move track function
        public void SpawnTriggerEnt()
        {
            trackSpawner.SpawnMaster();
            //objectSpawner.SpawnObstacles();
        }

      
    }
}
