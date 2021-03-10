using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace EggRunner.Lara
{
    public class CollectableManager : MonoBehaviour
    {
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

        
    }
}
