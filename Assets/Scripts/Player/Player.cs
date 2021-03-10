using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    #region Variables 
    Rigidbody rigi;
    public GameObject dood;

    [Header("Markers")]
    public int lane;
    public GameObject laneParent;
    public GameObject[] laneMarkers = new GameObject[3];
    public float minDistanceToMarker;
    

    [Header("Stats")]
    public int score = 0;
    public float shiftSpeed = 1;
    public int health;
    public int maxHealth = 3;
    public bool isGrounded;
    public float jumpHeight = 12;
    bool isDead;

    [Header("Player UI")]
    public Text scoreText;
  //  public Text healthText;
    public GameObject[] healthBar;
    public GameObject deathScreen;
    [SerializeField] private int distance;
    public Text distanceText;

    [Header("Music")]
    public AudioSource deathSound; //set
    public AudioSource jumpSound; //set
    public AudioSource backgroundMusic; //set
    public AudioSource collideRock; //
    public AudioSource collectableSound; //
    public AudioSource volcanoBoom; //
    #endregion
    #region Start
    void Start()
    {
        
        rigi = GetComponent<Rigidbody>();
        lane = 1;
        health = maxHealth - 1;
        isDead = false;
        deathScreen.gameObject.SetActive(false);
        score = 0;
      //  healthText.text = "Health: " + health;


        scoreText.text = "Score: " + score;

        
        rigi.AddForce(new Vector3(-30, -30, 0) * 1, ForceMode.Impulse); //Yay sphere goes diagonally down

    }
    #endregion
    #region Update
    void Update()
    {
        #region Measure Distance
        distanceText.text = "Distance: " + distance.ToString(); //Display distance travelled
        distance = (int)-transform.position.x;
        #endregion

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
                    jumpSound.Play();
                }
            }
            #endregion
            #region Death
            // Die when your health hits zero
            if (health < 0 || Input.GetKeyDown(KeyCode.X))
            {
                Dead();
            }
            #endregion
            
        }
        // lane markers and player 
        laneParent.transform.position = new Vector3(transform.position.x, transform.position.y);
        dood.transform.position = new Vector3(transform.position.x, transform.position.y + 4.5f, transform.position.z);
        #region Test Kill
        /*Testing Purposes
         if(Input.GetKey(KeyCode.X))
         {
             Dead();

         }
           */
        #endregion
    }
    #endregion
    #region Collisions
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            HealthDown();
            // healthText.text = "Health: " + health;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Tim Tam"))
        {
            HealthUp();
          //  healthText.text = "Health: " + health;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Box"))
        {
            health = maxHealth;
           // healthText.text = "Health: " + health;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Meat"))
        {
            score++;
            scoreText.text = "Score: " + score;
            Destroy(other.gameObject);
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
        deathSound.Play();
        // Bring up the death screen when dead
        Debug.Log("RIP Caveman");
        isDead = true;
        deathScreen.gameObject.SetActive(true);
        Time.timeScale = 0;

    }
    #endregion
    #region Restart
    public void Restart()
    {
        // Get the current scene and reload
        Scene currentScene = SceneManager.GetActiveScene();
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(currentScene.name);
        }
        
    }
    #endregion

    #region Health
    public void HealthUp()
    {
        health++;
        GameObject healthMeat = healthBar[health];
        healthMeat.SetActive(true);
    }
    public void HealthDown()
    {
        GameObject healthMeat = healthBar[health];
        healthMeat.SetActive(false);

        health--;
    }
    #endregion

}
