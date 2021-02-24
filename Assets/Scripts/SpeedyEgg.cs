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
        [SerializeField] protected float acceleration = 5f;
        [SerializeField] private float maxSpeed = 150f;
        [SerializeField] private float currentSpeed = 50f;
        #endregion

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            currentSpeed = maxSpeed;
        }

        private void FixedUpdate()
        {
            //currentSpeed = maxSpeed * acceleration * Time.deltaTime;
            rb.AddForce(new Vector3(-30, -30, 0) * 1); //Yay sphere goes diagonally down

            if (currentSpeed < maxSpeed)
            {
                currentSpeed += acceleration;
            }

        }
    }
}
