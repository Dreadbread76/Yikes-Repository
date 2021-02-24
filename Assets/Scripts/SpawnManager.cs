using UnityEngine;

namespace EggRunner.Lara
{
    public class SpawnManager : MonoBehaviour
    {
        TrackSpawner trackSpawner;

        // Start is called before the first frame update
        void Start()
        {
            trackSpawner = GetComponent<TrackSpawner>();
        }

        //When enter trigger, call move track function
        public void SpawnTriggerEnt()
        {
            trackSpawner.MoveTrack();
        }
    }
}
