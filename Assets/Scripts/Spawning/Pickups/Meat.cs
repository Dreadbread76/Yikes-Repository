using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EggRunner.Lara
{
    public class Meat : MonoBehaviour
    {
        #region Singleton
        public static Meat instance; //Singleton for use by Collectable Manager

        private void Awake()
        {
            if(instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }
        #endregion

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
