using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EggRunner.Lara
{
    public class ObstacleManager : MonoBehaviour
    {
        #region Spawning Obstacles
        public List<GameObject> obstacleList = new List<GameObject>();
        public Transform spawnLocation;
        public GameObject worldParent;
        public GameObject lastObGO; //Obstacle prefab
        private Obstacle lastObstacle; //Script for bounds
        #endregion

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}
