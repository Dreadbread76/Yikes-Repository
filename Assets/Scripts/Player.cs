using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int lane;
    Rigidbody rigi;
    Vector3 moveDirection;

    [Header("Stats")]
    public int score = 0;
    public float speed;
    public int health;
    public int maxHealth = 3;
    public bool isGrounded;
    public float jumpHeight = 5;
    


    // Start is called before the first frame update
    void Start()
    {
        rigi = GetComponent<Rigidbody>();
        lane = 1;
        health = maxHealth;

    }

   
    void Update()
    {
        moveDirection = transform.TransformDirection(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
        moveDirection *= speed;

        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.A) && lane > 0)
            {
                lane--;
                moveDirection.x  = -1;
            }
            if (Input.GetKeyDown(KeyCode.D) && lane < 2)
            {
                lane++;
                moveDirection.x = 1;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rigi.AddForce(0, jumpHeight, 0);
            }
        }



        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (rigi.gameObject.CompareTag("Obstacle"))
        {
            health--;
        }
        if (rigi.gameObject.CompareTag("Tim Tam"))
        {
            health++;
        }
        if (rigi.gameObject.CompareTag("Box"))
        {
            health = maxHealth;
        }
        if (rigi.gameObject.CompareTag("Meat"))
        {
            score++;
        }
        if(rigi.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    public void OnCollisionStay(Collision collision)
    {
        if (rigi.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
