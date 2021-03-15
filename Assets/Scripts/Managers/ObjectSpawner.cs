using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public List<GameObject> spawnables = new List<GameObject>();
    public Transform[] spawnPoints;

    // Update is called once per frame
    public void Start()
    {
        SpawnObstacles();

        // Kills the road part
        // StartCoroutine("KillTimer");
    }
    #region Spawn Obstacles
    public void SpawnObstacles()
    {
        
        Quaternion newRot = Quaternion.Euler(90, 90, 0);

        foreach(Transform trans in spawnPoints)
        {
            int spawnChance = Random.Range(0, 2);

            if (spawnables != null && spawnChance > 0)
            {
                Instantiate(spawnables[Random.Range(0, spawnables.Count)], spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position, newRot);
            }
        }

        
       
    }
   /* IEnumerator KillTimer()
    {
        
        yield return new WaitForSeconds(60f);
        Destroy(this.gameObject);
    }
    */
    #endregion
}