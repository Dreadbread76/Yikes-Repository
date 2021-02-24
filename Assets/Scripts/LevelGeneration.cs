using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EggRunner.Lara
{
    public class LevelGeneration : MonoBehaviour
    {
        [SerializeField]
        private List<GameObject> platformPrefabs = new List<GameObject>();

        //Where the next platform will spawn
        public Transform spawnPlatform; 

        public GameObject player; //Ref to player object

        //When player reaches a point down the hill, 
        //the level will instantiate and the track behind 
        //will disappear after 3.5 seconds

        private void Awake()
        {
            #region Platform Positions for Spawn
            Vector3 platformOnePos = new Vector3(-67, -28.1f);
            Vector3 platformTwoPos = platformOnePos + new Vector3(-67, -28.1f);
            #endregion

            //Platform
            Instantiate(spawnPlatform, platformTwoPos, Quaternion.Euler(0f, 0f, 26f));
        }

        private void Update()
        {

        }

        public void SpawnLevel(Vector3 spawnPos)
        {
            Instantiate(spawnPlatform, spawnPos, Quaternion.Euler(0f, 0f, 26f));
        }

    }
}

