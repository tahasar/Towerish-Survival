using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance { get; private set; }

    private Dictionary<string, Queue<Transform>> poolDictionary;
    private Dictionary<string, Transform> poolParents;

    private void Awake()
    {
        Instance = this;
        poolDictionary = new Dictionary<string, Queue<Transform>>();
        poolParents = new Dictionary<string, Transform>();
    }

    public void CreatePool(Transform prefab, int size)
    {
        string key = prefab.name;
        if (!poolDictionary.ContainsKey(key))
        {
            // Create a new parent for this pool
            Transform poolParent = new GameObject("Pool " + key).transform;
            poolParent.parent = SpawnManager.Instance.transform; // Set the parent to the SpawnManager
            poolParents.Add(key, poolParent);

            Queue<Transform> pool = new Queue<Transform>();
            for (int i = 0; i < size; i++)
            {
                Transform obj = Instantiate(prefab, poolParent);
                obj.gameObject.SetActive(false);
                pool.Enqueue(obj);
            }
            poolDictionary.Add(key, pool);
        }
    }

    public Transform GetObjectFromPool(Transform prefab)
    {
        string key = prefab.name;
        if (poolDictionary.ContainsKey(key))
        {
            if (poolDictionary[key].Count == 0)
            {
                // Havuzda alınacak müsait bir obje yoksa, yeni bir obje oluştur ve havuza ekle
                Transform newObj = Instantiate(prefab, poolParents[key]);
                newObj.gameObject.SetActive(false);
                poolDictionary[key].Enqueue(newObj);
            }

            Transform obj = poolDictionary[key].Dequeue();
            obj.gameObject.SetActive(true);
            obj.parent = poolParents[key]; // Set the parent to the pool parent
            return obj;
        }
        else
        {
            Debug.LogWarning("No pool with the key " + key + " exists.");
            return null;
        }
    }

    public void ReturnObjectToPool(string key, Transform obj)
    {
        if (poolDictionary.ContainsKey(key))
        {
            Debug.Log("Object returned to the pool.");
            obj.gameObject.SetActive(false);
            obj.parent = poolParents[key]; // Set the parent to the pool parent
            poolDictionary[key].Enqueue(obj);
        }
        else
        {
            Debug.LogWarning("No pool with the key " + key + " exists.");
        }
    }
}