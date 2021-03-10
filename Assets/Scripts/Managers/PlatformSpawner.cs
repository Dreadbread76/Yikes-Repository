using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EggRunner.Lara
{
    public class PlatformSpawner : MonoBehaviour
    {
        #region Platform
        public GameObject platformPrefab;
        public GameObject currentPlatform;
        public Player player; //Ref to player object for setting platforms to its position
        public int lane;
        public List<GameObject> spawnables = new List<GameObject>();
        #endregion

        //public GameObject timTamGO;

        //IT WORKS!
        public void EndlessPlatforms()
        {
            Vector3 position = player.transform.position;
            Quaternion rotation = Quaternion.Euler(0, 0, 20);


            if(currentPlatform != null)
            {
                // We have already spawned a platform

                // Align new platform to previous
                rotation = currentPlatform.transform.rotation;

                // Move platform to front of other one
                Platform platform = currentPlatform.GetComponent<Platform>();
                position = currentPlatform.transform.position - (currentPlatform.transform.right * (platform.bounds.size.x * currentPlatform.transform.localScale.x));
            }
            lane = Random.Range(0, 3);
            currentPlatform = Instantiate(platformPrefab, position, rotation);
            
            //TimTam tam = timTamGO.GetComponent<TimTam>();
            Quaternion newRot = Quaternion.Euler(90, 90, 0); //Rotation works
            Vector3 newPos = position - new Vector3(0, -3, player.laneMarkers[lane].transform.position.z);
            Debug.Log(lane);
            Instantiate(SpawnObject(Random.Range(0,100)), newPos, newRot);
        }
        public void SpawnObject(int num)
        {
            switch(num)
            {
                case (0 - 60):
                default:
                    spawnables[0];
                    break;
                        cas
                    
            }

                
        }
    }
   
}

