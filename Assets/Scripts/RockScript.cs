using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Meat") || other.gameObject.CompareTag("Tim Tam"))
        {
            Destroy(other.gameObject);
        }
    }
}
