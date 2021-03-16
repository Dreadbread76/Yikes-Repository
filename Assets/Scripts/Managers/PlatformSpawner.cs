using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EggRunner.Lara
{
    public class PlatformSpawner : MonoBehaviour
    {
        #region Spawn Variables
        public GameObject platformPrefab;
        public GameObject currentPlatform;
        public Player player; //Ref to player object for setting platforms to its position
        public int lane;
        //public List<GameObject> spawnables = new List<GameObject>();
        //public Transform[] spawnPoints;
        #endregion

        //IT WORKS!
        public void SpawnMaster()
        {
            #region Endless Platforms
            Vector3 position = player.transform.position;
            Quaternion rotation = Quaternion.Euler(0, 0, 20);

            if (currentPlatform != null)
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
            #endregion

            #region Spawn Obstacles
            /*Quaternion newRot = Quaternion.Euler(90, 90, 0);
            Vector3 newPos = position - new Vector3(0, -3, player.laneMarkers[lane].transform.position.z);
            Debug.Log(lane);*/

            #region Original Object Spawning
            /*  if (spawnables != null)
              {
                  Instantiate(spawnables[Random.Range(0, spawnables.Count)], spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position, newRot);
              }
              */
            #endregion
            #region Object Pool Test
            /* Vector3 timTamOffset = new Vector3(15f, 5f, 0); //Push forward and separates the spawnables
            Vector3 boulderOffset = new Vector3(25f, 5f, 0);
            Vector3 meatOffset = new Vector3(35f, 5f, 0);*/

            //This will request a GO to become active and set pos and rot of that GO
            //Only aquires a GO that is pre-instantiated and only gets set active or inactive when needed
            /*GameObject timTam = SpawnablesPool.Instance.GetPooledObject("Tim Tam"); //Testing purposes using Tim Tams first
            if(timTam != null)
            {
                timTam.transform.position = newPos;
                timTam.transform.rotation = newRot;
                timTam.SetActive(true);
            }*/

            /* GameObject boulder = SpawnablesPool.Instance.GetPooledObject("Obstacle"); 
             if (boulder != null)
             {
                 boulder.transform.position = newPos;
                 boulder.transform.rotation = newRot;
                 boulder.SetActive(true);
             }


             GameObject meat = SpawnablesPool.Instance.GetPooledObject("Meat"); 
             if (meat != null)
             {
                 meat.transform.position = newPos;
                 meat.transform.rotation = newRot;
                 meat.SetActive(true);
             }*/
            #endregion

            #endregion
        }
    }
}

