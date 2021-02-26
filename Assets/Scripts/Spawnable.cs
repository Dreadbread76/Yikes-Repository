using UnityEngine;

namespace EggRunner.Lara
{
    public class Spawnable : MonoBehaviour
    {
        //Set the spawn points to be set 
        private float xPos;
        private float yPos;
        private float zRotation;
        public GameObject player;

        public void SetPositions()
        {
            xPos = player.transform.position.x;
            yPos = player.transform.position.y;
            zRotation = player.transform.rotation.z;
        }
    }
}

