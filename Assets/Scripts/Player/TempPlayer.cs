using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace EggRunner.Lara
{
    public class TempPlayer : MonoBehaviour
    {
        [SerializeField] private int health = 100;
        [SerializeField] private int damage = 25;
        public TMP_Text tempHealthText;

        [SerializeField] private int distance;
        public TMP_Text distanceText;

        // Update is called once per frame
        void Update()
        {
            tempHealthText.text = "Health: " + health.ToString(); //Display temp health

            #region Measure Distance
            distanceText.text = "Distance: " + distance.ToString(); //Display distance travelled
            distance = (int)transform.position.x;
            #endregion
        }

        // OnTriggerEnter is called when the Collider other enters the trigger
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Obstacle"))
            {
                //Debug.Log("Player Hit");
                TempDamage(); //Injure player
                Destroy(other.gameObject);
            }

            if (other.gameObject.CompareTag("Meat"))
            {
                CollectableManager.collectableMan.UpdateScore(1); //Update score
                Destroy(other.gameObject);
            }
        }

        public void TempDamage()
        {
            health -= damage;
        }

        public void TempDeath()
        {
            if(health <= 0)
            {
                Debug.Log("Player Killed!");
                Time.timeScale = 0; //Stop time
            }
        }
    }
}
