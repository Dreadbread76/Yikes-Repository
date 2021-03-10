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
        #endregion


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

            currentPlatform = Instantiate(platformPrefab, position, rotation);
        }

        
    }
}

