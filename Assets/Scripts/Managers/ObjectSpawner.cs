using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public List<GameObject> spawnables = new List<GameObject>();
    public List<GameObject> spawnedEntities;
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
            //int spawnChance = Random.Range(0, spawnables.Count);

            if (spawnables != null)
            {
                GameObject spawnedObject = spawnables[Random.Range(0, spawnables.Count)];
                Instantiate(spawnedObject, trans.transform.position, newRot);
                spawnedEntities.Add(spawnedObject);
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
