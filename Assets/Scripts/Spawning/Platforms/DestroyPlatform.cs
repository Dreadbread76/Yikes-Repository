using UnityEngine;

namespace EggRunner.Lara
{
    public class DestroyPlatform : MonoBehaviour
    {
        private void Start()
        {
            Destroy(gameObject, 50f); //Destroy level track after a while  
        }
    }
}
