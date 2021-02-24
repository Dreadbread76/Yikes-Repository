using System.Collections.Generic;
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
            tempTrack.transform.position = new Vector3(-15, -4, 0); //Reposition the temp track 
            platforms.Add(tempTrack);
            /*
                        //BLOODY HELL JUST GONNA INSTANTIATE!
                        GameObject tempTrack = platforms[0];
                        platforms.Remove(tempTrack);
                        tempTrack.transform.position = new Vector3();
                        tempTrack = Instantiate(tempTrack, spawnPlatform);*/
        }
    }
}

