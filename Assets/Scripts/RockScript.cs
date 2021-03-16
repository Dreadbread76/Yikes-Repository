using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockScript : MonoBehaviour
{
    
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Meat") || other.gameObject.CompareTag("Tim Tam"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
