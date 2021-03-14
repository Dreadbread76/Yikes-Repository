using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField]
    public GameObject optionsScreen;
    [SerializeField]
    public GameObject pauseScreen;
    [SerializeField]
    public GameObject gameOverScreen;
    [SerializeField]
    public string mainMenuScene;
    [SerializeField]
    public GameObject loadingScreen; 
    [SerializeField]
    public GameObject loadingIcon;
    [SerializeField]
    public Text loadingText;
    [SerializeField]
    public Text scoreText;
    [SerializeField]
    public Text distanceText;
    [SerializeField]
    public Text collectibleText;
    [SerializeField]
    public List<GameObject> healthPoints;

    private bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnpause();
        }
    }

    public void PauseUnpause()
    {
        if (!isPaused)
        {
            pauseScreen.SetActive(true);
            isPaused = true;
            Time.timeScale = 0f;
        }
        else if (!optionsScreen.activeSelf)
        {
            pauseScreen.SetActive(false);
            isPaused = false;
            Time.timeScale = 1f;
        }
    }

    public void OpenOptions()
    {
        optionsScreen.SetActive(true);
    }

    public void CloseOptions()
    {
        optionsScreen.SetActive(false);
    }

    public void QuitToMainMenu()
    {
        // SceneManager.LoadScene(mainMenuScene);
        // Time.timeScale = 1f;
        gameOverScreen.SetActive(false);
        StartCoroutine(LoadMainMenu());
    }

    public IEnumerator LoadMainMenu()
    {
        loadingScreen.SetActive(true);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(mainMenuScene);
        asyncLoad.allowSceneActivation = false;
        while (!asyncLoad.isDone)
        {
            if (asyncLoad.progress >= .9f)
            {
                loadingText.text = "Press any key to continue...";
                loadingIcon.SetActive(false);

                if (Input.anyKeyDown)
                {
                    asyncLoad.allowSceneActivation = true;
                    Time.timeScale = 1f;
                }
            }

            yield return null;
        }
    }
}
