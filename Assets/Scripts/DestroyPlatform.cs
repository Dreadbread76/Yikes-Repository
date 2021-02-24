using UnityEngine;

namespace EggRunner.Lara
{
    public class DestroyPlatform : MonoBehaviour
    {
        private void Start()
        {
            Destroy(gameObject, 3.5f); //Destroy level track after 2.5 seconds
        }
    }
}
