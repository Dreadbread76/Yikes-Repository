using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TempPlayer : MonoBehaviour
{
    [SerializeField] private int health = 100;
    [SerializeField] private int damage = 5;
    public TMP_Text tempHealth;

    [SerializeField] private int scoreCount;
    public TMP_Text scoreText;

    // Update is called once per frame
    void Update()
    {
        tempHealth.text = "Health: " + health.ToString();
    }

    // OnCollisionEnter is called when this collider/rigidbody has begun touching another rigidbody/collider
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Boulder"))
        {
            Debug.Log("Player Hit");
            //Injure player
            TempDamage();
            Destroy(collision.gameObject);
        }
    }

    public void TempDamage()
    {
        health -= damage;
    }


}
