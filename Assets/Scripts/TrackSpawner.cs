using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace EggRunner.Lara
{
    public class TrackSpawner : MonoBehaviour
    {
        public List<GameObject> platforms = new List<GameObject>();
        private float offset = 0;

        //Where the next platform will spawn
        public Transform spawnPlatform; 
        public GameObject player; //Ref to player object

        //When player reaches a point down the hill, 
        //the level will instantiate and the track behind 
        //will move to become the next one

        /// <summary>
        /// This function repositions the track so no instantiating is needed.
        /// </summary>
        public void MoveTrack()
        {
            GameObject tempTrack = platforms[0]; //Create temp variable to store the first platform
            platforms.Remove(tempTrack); //Remove it
            tempTrack.transform.position = new Vector3(-15, -4, 0);
            platforms.Add(tempTrack);
        }
    }
}

