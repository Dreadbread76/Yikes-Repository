using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    #region Variables 
    Rigidbody rigi;
    Renderer rend;
    public GameObject dood;
    public GameObject testImage;
    public struct Highscore
    {
        public int Score { get; set; }
        public string Name { get; set; }
    }

    [Header("Markers")]
    public int lane;
    public GameObject laneParent;
    public GameObject[] laneMarkers = new GameObject[3];
    public float minDistanceToMarker;


    [Header("Stats")]
    public int score = 0;
    public int timTams = 0;
    public float shiftSpeed = 1;
    public int health;
    public int maxHealth = 3;
    public bool isGrounded;
    public float jumpHeight = 12;
    public bool isDead = false;
    public Highscore[] highscores = new Highscore[3];
    public Material[] eggMaterials = new Material[3];

    [Header("Player UI")]
    public Text scoreText;
    public GameObject[] healthBar;
    public GameObject deathScreen;
    public Text highscoreName1Text;
    public Text highscoreScore1Text;
    public Text highscoreName2Text;
    public Text highscoreScore2Text;
    public Text highscoreName3Text;
    public Text highscoreScore3Text;
    public GameObject enterNameScreen;
    public InputField nameInput;
    [SerializeField] private int distance;
    public Text distanceText;
    public Text timTamText;

    [Header("Music")]
    public AudioSource deathSound; //set
    public AudioSource jumpSound; //set
    public AudioSource dinosaur; //wait
    public AudioSource pain; //set
    public AudioSource collectableSound; //set
    public AudioSource volcanoBoom; //wait
    public AudioSource timTamSound;

    [Header("Animation")]
    public Animation run;
    #endregion
    #region Awake
    private void Awake()
    {
        for (int i=0; i<highscores.Length; i++)
        {
            highscores[i].Score = PlayerPrefs.GetInt("Highscore" + i, 0);
            highscores[i].Name = PlayerPrefs.GetString("HighscoreName" + i, "");
        }
    }

    #endregion
    #region Start
    void OnEnable()
    {
        rigi = GetComponent<Rigidbody>();
        lane = 1;
        health = maxHealth - 1;
        rend = this.gameObject.GetComponent<Renderer>();
        rend.material = eggMaterials[health];
        isDead = false;
        deathScreen.gameObject.SetActive(false);
        enterNameScreen.SetActive(false);
        score = 0;
        timTams = 0;
        scoreText.text = score.ToString();


        scoreText.text = score.ToString();
        StartCoroutine(PlayOnRepeat(dinosaur, 15f));
        StartCoroutine(PlayOnRepeat(volcanoBoom, 20f));
        rigi.AddForce(new Vector3(-30, -30, 0) * 1, ForceMode.Impulse); //Yay sphere goes diagonally down

        highscoreName1Text.text = highscores[0].Name;
        highscoreScore1Text.text = highscores[0].Score.ToString();
        highscoreName2Text.text = highscores[1].Name;
        highscoreScore2Text.text = highscores[1].Score.ToString();
        highscoreName3Text.text = highscores[2].Name;
        highscoreScore3Text.text = highscores[2].Score.ToString();

    }
    #endregion
    #region Update
    void Update()
    {
        #region Measure Distance
        distanceText.text = distance.ToString(); //Display distance travelled
        distance = (int)-transform.position.x;
        if (distance%1000 == 1)
        {
            StartCoroutine(JumpScare(testImage, 0.5f));
        }
        #endregion

        score = distance + (timTams * 10);
        scoreText.text = score.ToString();

        if (!isDead)
        {
            #region Movement
            if (isGrounded)
            {
                //Play Animation NOPE DONT WORK
                //run.Play();

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
            if (health < 0 )
            {
                isDead = true;
                Time.timeScale = 0;

                // if the current score is higher then the 3rd place you have to set a new highscore
                if (score > highscores[2].Score)
                    enterNameScreen.SetActive(true);
                else
                    Dead();
            }
            #endregion
            
        }
        laneParent.transform.position = new Vector3(transform.position.x, transform.position.y);
        dood.transform.position = new Vector3(transform.position.x, transform.position.y + 2.5f, transform.position.z);
        #region Test Kill
        // Testing Purposes
        /* if(Input.GetKey(KeyCode.X))
         {
            isDead = true;
            Time.timeScale = 0;

            if (distance > highscores[0].Score)
                enterNameScreen.SetActive(true);
            else
                Dead();
            
            //Dead();

        }*/
           
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
            other.gameObject.SetActive(false);
            //Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Tim Tam"))
        {
            timTamSound.Play();
            //score++;
            timTams++;
            scoreText.text = score.ToString();
            timTamText.text = timTams.ToString();
            other.gameObject.SetActive(false);
            //Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Box"))
        {
            health = maxHealth;
           // healthText.text = "Health: " + health;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Meat"))
        {
            collectableSound.Play();
            HealthUp();
            //  healthText.text = "Health: " + health;
            //Destroy(other.gameObject);
            other.gameObject.SetActive(false);
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
        pain.Stop();
        // Bring up the death screen when dead
        //Debug.Log("RIP Caveman");
        isDead = true;
        Time.timeScale = 0;

        deathScreen.gameObject.SetActive(true);
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
        if(health < 2)
        {
            health++;

            GameObject healthMeat = healthBar[health];
            rend.material = eggMaterials[health];
            healthMeat.SetActive(true);
        }
       
    }
    public void HealthDown()
    {
        if(health > -1)
        {
            GameObject healthMeat = healthBar[health];
            healthMeat.SetActive(false);
            if (health > 0)
            {
                rend.material = eggMaterials[health - 1];
            }
            
            health--;
            

            if (!isDead)
            {
                pain.Play();
            }
        }
        
    }
    #endregion
    #region Sound
    public IEnumerator PlayOnRepeat(AudioSource audio, float soundDelay)
    {
        Debug.Log("Barney");
        yield return new WaitForSeconds(soundDelay);

        audio.Play();
        StartCoroutine(PlayOnRepeat(audio,soundDelay));

       
    }
    #endregion

    #region highscore
    public void OnEndInputName()
    {
        // check the hghscore position
        int highscorePos = CheckTheHighscorePosition();

        // update the positions and the UI
        switch (highscorePos)
        {
            case 3: // 3rd place, replace only the 3rd
                highscores[2].Name = nameInput.text;
                highscoreName3Text.text = highscores[2].Name;
                PlayerPrefs.SetString("HighscoreName2", highscores[2].Name);
                highscores[2].Score = score;
                highscoreScore3Text.text = highscores[2].Score.ToString();
                PlayerPrefs.SetInt("Highscore2", highscores[2].Score);

                break;
            case 2: // 2nd place, shift the 2nd to 3rd and replace
                highscores[2].Name = highscores[1].Name;
                highscoreName3Text.text = highscores[2].Name;
                PlayerPrefs.SetString("HighscoreName2", highscores[2].Name);
                highscores[2].Score = highscores[1].Score;
                highscoreScore3Text.text = highscores[2].Score.ToString();
                PlayerPrefs.SetInt("Highscore2", highscores[2].Score);

                highscores[1].Name = nameInput.text;
                highscoreName2Text.text = highscores[1].Name;
                PlayerPrefs.SetString("HighscoreName1", highscores[1].Name);
                highscores[1].Score = score;
                highscoreScore2Text.text = highscores[1].Score.ToString();
                PlayerPrefs.SetInt("Highscore1", highscores[1].Score);

                break;
            case 1: // 1st place, shift 1st and 2nd pos and replace
                highscores[2].Name = highscores[1].Name;
                highscoreName3Text.text = highscores[2].Name;
                PlayerPrefs.SetString("HighscoreName2", highscores[2].Name);
                highscores[2].Score = highscores[1].Score;
                highscoreScore3Text.text = highscores[2].Score.ToString();
                PlayerPrefs.SetInt("Highscore2", highscores[2].Score);

                highscores[1].Name = highscores[0].Name;
                highscoreName2Text.text = highscores[1].Name;
                PlayerPrefs.SetString("HighscoreName1", highscores[1].Name);
                highscores[1].Score = highscores[0].Score;
                highscoreScore2Text.text = highscores[1].Score.ToString();
                PlayerPrefs.SetInt("Highscore1", highscores[1].Score);

                highscores[0].Name = nameInput.text;
                highscoreName1Text.text = highscores[0].Name;
                PlayerPrefs.SetString("HighscoreName0", highscores[0].Name);
                highscores[0].Score = score;
                highscoreScore1Text.text = highscores[0].Score.ToString();
                PlayerPrefs.SetInt("Highscore0", highscores[0].Score);

                break;
        }

        enterNameScreen.SetActive(false);
        Dead();
    }

    public int CheckTheHighscorePosition()
    {
        if (score < highscores[1].Score)
        {
            // im in the 3rd place
            return 3;
        }
        else if (score < highscores[0].Score)
        {
            // im at the 2nd place
            return 2;
        }
        else
        {
            // higher than the 1st, so 1st place
            return 1;
        }
    }
    #endregion

    IEnumerator JumpScare(GameObject go, float delay)
    {
        go.SetActive(true);
        yield return new WaitForSeconds(delay);
        go.SetActive(false);
    }

}
