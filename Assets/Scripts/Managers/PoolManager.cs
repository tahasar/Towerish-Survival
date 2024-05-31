using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance { get;  set; }

    private Queue<GameObject> pool;

    private Dictionary<GameObject, Queue<GameObject>> poolDictionary;

    private void Awake()
    {
        Instance = this;
        
        poolDictionary = new Dictionary<GameObject, Queue<GameObject>>();
    }

    public void CreatePool(Transform parent, GameObject prefab, int size)
    {
        if (poolDictionary.ContainsKey(prefab))
        {
            Debug.LogWarning("Pool for " + prefab.name + " already exists.");
            return;
        }
        
        Queue<GameObject> pool = new Queue<GameObject>();

        for (int i = 0; i < size; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            obj.transform.SetParent(parent);
            pool.Enqueue(obj);
        }

        poolDictionary.Add(prefab, pool);
    }

    public GameObject Get(Transform parent)
    {
        foreach (var pool in poolDictionary)
        {
            if (pool.Value.Count > 0)
            {
                GameObject obj = pool.Value.Dequeue();
                obj.transform.SetParent(parent);
                return obj;
            }
        }

        return null;
    }

    public void Return(GameObject obj)
    {
        obj.SetActive(false);
        obj.transform.SetParent(transform);
        poolDictionary[obj].Enqueue(obj);
    }
}