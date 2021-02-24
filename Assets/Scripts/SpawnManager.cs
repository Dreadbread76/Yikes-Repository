using System.Collections;
using System.Collections.Generic;
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

        public void SpawnTriggerEnt()
        {
            trackSpawner.MoveTrack();
        }
    }
}
