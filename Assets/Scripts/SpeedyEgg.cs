using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EggRunner.Lara
{
    [RequireComponent(typeof(Rigidbody))]
    public class SpeedyEgg : MonoBehaviour
    {
        //To make egg roll down hill faster
        public GameObject player;
        public Rigidbody rb;

        #region Speedy Variables
        [SerializeField, Tooltip("Force added to egg")] protected float acceleration = 1f; 
        [SerializeField, Tooltip("Maximum speed that egg can go")] private float maxSpeed = 150f;
        [SerializeField, Tooltip("Current speed of egg")] private float currentSpeed = 50f;
        #endregion

        public SpawnManager spawnManager;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            currentSpeed = maxSpeed;
        }

        private void FixedUpdate()
        {
            //AddForce to make egg travel diagonally 
            rb.AddForce(new Vector3(-30, -30, 0) * acceleration); 

            //If current speed is greater than max speed, then limit speed by making current speed = max speed
            if (currentSpeed < maxSpeed)
            {
                currentSpeed = maxSpeed;
            }

        }

        // OnTriggerEnter is called when the Collider other enters the trigger
        private void OnTriggerEnter(Collider other)
        {
            spawnManager.SpawnTriggerEnt();
        }


    }
}
