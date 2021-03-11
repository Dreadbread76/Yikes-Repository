using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class will allow for multiple spawnable types
/// so more than one object spawning muahahah
/// </summary>
[System.Serializable]
public class SpawnablePoolItem
{
    public GameObject objectToPool;
    public int amountToPool;
    public bool shouldExpand = true; //For expanding the pool of objects
}

public class SpawnablesPoolTest : MonoBehaviour
{
    public static SpawnablesPoolTest Instance;
    public List<GameObject> pooledSpawnables;
    public List<SpawnablePoolItem> itemsToPool;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        pooledSpawnables = new List<GameObject>();
        //Iterate through all instances of SpawnablePoolItem and add the appropriate objects to the spawn pool.
        foreach (SpawnablePoolItem item in itemsToPool)
        {
            for (int i = 0; i < item.amountToPool; i++)
            {
                GameObject obj = (GameObject)Instantiate(item.objectToPool);
                obj.SetActive(false);
                pooledSpawnables.Add(obj);
            }
        }
    }

    /// <summary>
    /// This will remove the need to redundantly instantiate and destroy objects
    /// Only allows for objects to be active or inactive
    /// </summary>
    /// <returns></returns>
    public GameObject GetPooledObject(string tag)
    {
        for (int i = 0; i < pooledSpawnables.Count; i++)
        {
            if (!pooledSpawnables[i].activeInHierarchy && pooledSpawnables[i].tag == tag) 
            {
                return pooledSpawnables[i];
            }
        }
        //return null;

        //This foreach statement allows for infinte anmounts of objects can be spawned
        //by expanding the objects to pool by adding to the list
        foreach (SpawnablePoolItem item in itemsToPool)
        {
            if(item.objectToPool.tag == tag)
            {
                if(item.shouldExpand)
                {
                    GameObject obj = (GameObject)Instantiate(item.objectToPool);
                    obj.SetActive(false);
                    pooledSpawnables.Add(obj);
                    return obj;
                }
            }
        }
        return null;
    }
    
}
