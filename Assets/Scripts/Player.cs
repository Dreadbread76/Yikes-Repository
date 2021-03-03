using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    #region Variables 
    Rigidbody rigi;


    [Header("Markers")]
    public int lane;
    public GameObject[] laneMarkers = new GameObject[3];
    public float minDistanceToMarker;
    

    [Header("Stats")]
    public int score = 0;
    public float shiftSpeed;
    public int health;
    public int maxHealth = 3;
    public bool isGrounded;
    public float jumpHeight = 100;
    bool isDead;

    public GameObject deathScreen;
    #endregion
    #region Start
    void Start()
    {
        rigi = GetComponent<Rigidbody>();
        lane = 1;
        health = maxHealth;
        isDead = false;
        deathScreen.gameObject.SetActive(false);
        
    }
    #endregion
    #region Update
    void Update()
    {

        if (!isDead)
        {
            #region Movement
            if (isGrounded)
            {

                // Change lane with the A or D button (A left, D right)
                if (Input.GetKeyDown(KeyCode.A) && lane > 0)
                {
                    lane--;
                    StartCoroutine(Move());
                }
                if (Input.GetKeyDown(KeyCode.D) && lane < 2)
                {
                    lane++;
                    StartCoroutine(Move());
                }
                // Jump while your feet are grounded 
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    rigi.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
                }
            }
            #endregion
            #region Death
            // Die when your health hits zero
            if (health <= 0 || Input.GetKeyDown(KeyCode.X))
            {
                Dead();
            }
            #endregion
            
        }

    }
    #endregion
    #region Collisions
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            health--;
        }
        if (collision.gameObject.CompareTag("Tim Tam"))
        {
            score++;
        }
        if (collision.gameObject.CompareTag("Box"))
        {
            health = maxHealth;
        }
        if (collision.gameObject.CompareTag("Meat"))
        {
            health++;
        }
       

    }
    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
       

    }
    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    #endregion
    #region Movement
    public IEnumerator Move()
    {
       
        float step = shiftSpeed * Time.deltaTime;

        // Move towards the next lane marker
        while (gameObject.transform.position != laneMarkers[lane].transform.position)
        {
            this.gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, laneMarkers[lane].transform.position, step);

            yield return 0;
        }
            

    }
    #endregion
    #region Death
    public void Dead()
    {
        // Bring up the death screen when dead
        isDead = true;
        deathScreen.gameObject.SetActive(true);
    }
    #endregion
    #region Restart
    public void Restart()
    {
        // Get the current scene and reload
        Scene currentScene = SceneManager.GetActiveScene();
        {
            SceneManager.LoadScene(currentScene.name);
        }
        
    }
    #endregion

}
