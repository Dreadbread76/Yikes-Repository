using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace EggRunner.Lara
{
    public class CollectableManager : MonoBehaviour
    {
        [SerializeField] private int scoreCount;
        public TMP_Text scoreText;
        public GameObject meatGO;

        #region Singleton
        public static CollectableManager collectableMan; //Singleton for Collectable Manager

        private void Awake()
        {
            if (collectableMan != null)
            {
                Destroy(gameObject);
            }
            else
            {
                collectableMan = this;
                DontDestroyOnLoad(gameObject);
            }
        }
        #endregion

        public void UpdateScore(int score)
        {
            scoreCount += score;
            scoreText.text = "Score: " + scoreCount;
        }
    }
}
