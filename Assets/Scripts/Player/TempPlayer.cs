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
        public TMP_Text tempHealth;

        // Update is called once per frame
        void Update()
        {
            tempHealth.text = "Health: " + health.ToString();
        }

        // OnTriggerEnter is called when the Collider other enters the trigger
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Boulder"))
            {
                Debug.Log("Player Hit");
                //Injure player
                TempDamage();
                Destroy(other.gameObject);
            }

            if (other.gameObject.CompareTag("Meat"))
            {
                CollectableManager.collectableMan.UpdateScore(5); //Update score
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
