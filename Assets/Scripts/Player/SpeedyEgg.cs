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
        [Header("Acceleration Stats")]
        [SerializeField, Tooltip("Force added to egg")] private float speedMultiplier;
        [SerializeField, Tooltip("Maximum speed that egg can go")] private float maxSpeed = 150f;
        [SerializeField, Tooltip("Current speed of egg")] private float currentSpeed = 100f;
        [SerializeField] private float speedIncreaseDistance;
        [SerializeField] private float speedDistanceCount = 10f; // Every time player reaches the IncreaseDistance, speedDistanceCount will be added onto speedIncreaseDistance 
        [SerializeField] private float jumpForce;
        #endregion

        public SpawnManager spawnManager;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            //Gradually increase speed of player
            if (transform.position.x > speedDistanceCount)
            {
                speedDistanceCount += speedIncreaseDistance;

                speedIncreaseDistance += speedIncreaseDistance + speedMultiplier; //This line of code will make the distance between the currentSpeed increase larger 
                                                                                  // each time so the player does not speed up uncontrollably
                currentSpeed *= speedMultiplier;
            }

          /*  // Jump button
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce); 
            }
            */
        }

        // OnTriggerEnter is called when the Collider other enters the trigger
        private void OnTriggerEnter(Collider other)
        {
            spawnManager.SpawnTriggerEnt();
        }
    }
}
