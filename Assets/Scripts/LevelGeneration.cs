using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EggRunner.Lara
{
    public class LevelGeneration : MonoBehaviour
    {
        //When player reaches a point down the hill, 
        //the level will instantiate and the track behind 
        //will disappear

        [SerializeField]
        private List<GameObject> hillPrefabs = new List<GameObject>();

        //Where the next hill will spawn
        public Transform spawnNextPlatform; 

        public GameObject player; //Ref to player object

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        // OnCollisionEnter is called when this collider/rigidbody has begun touching another rigidbody/collider
        private void OnCollisionEnter(Collision collision)
        {
            //If player hits collider, wait for a few seconds to 
            //disable/destory the previous platform

            if(collision.gameObject.name == "Sphere")
            {
                print("Collider hit");
                Instantiate(hillPrefabs[0], spawnNextPlatform);
            }
        }



    }
}

