using UnityEngine;

namespace EggRunner.Lara
{
    public class PlatformSpawner : MonoBehaviour
    {
        //public List<GameObject> platforms = new List<GameObject>();
        public GameObject platformPrefabs;
        public SpeedyEgg player; //Ref to player object for setting platforms to its position

        public GameObject currentPlatform;

        //When player reaches a point down the hill, 
        //the level will instantiate and the track behind 
        //will move to become the next one

        /// <summary>
        /// This function repositions the track so no instantiating is needed.
        /// </summary>
      /*  public void MoveTrack()
        {
            GameObject tempTrack = platforms[0]; //Create temp variable to store the first platform
            platforms.Remove(tempTrack); //Remove it
            tempTrack.transform.position = new Vector3(-15, -4, 0); //Reposition the temp track 
            platforms.Add(tempTrack);
        }*/

        //Kinda works but not really
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

            currentPlatform = Instantiate(platformPrefabs, position, rotation);
        }

        /*STEPS
         * Get positions and rotation of first platform - z rotation = 20
         * X pos = -100, Y pos = -40, Z pos = 0
         * Scale = 60(x) x 0.1(y) x 30(z)
         * Instantiate prefab at player position and with z rotation of 20
         */
        
    }
}
