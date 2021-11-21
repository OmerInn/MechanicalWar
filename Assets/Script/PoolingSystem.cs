using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingSystem : MonoBehaviour
{
     [System.Serializable] public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;
    public GameObject Bulletproductionpoint;

    public static PoolingSystem instance;
    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                obj.transform.parent = this.transform;

                objectPool.Enqueue(obj);

            }
            poolDictionary.Add(pool.tag, objectPool);
        }
      //  SpawFromPool("Bullet", Vector3.zero, Quaternion.Euler(Vector3.zero));
    }
    public void Update()
    {
      //  SpawFromPool("Bullet", Vector3.zero, Quaternion.Euler(Vector3.zero));
    }
    public void SpawFromPool(string tag, Vector3 position, Quaternion rotation) //havuz içerisinden tagi verilen nesneleri istediðimiz pozisyon ve rotasyonda görünür hale getirenfonksiyon.
    {

            if (!poolDictionary.ContainsKey(tag))
            {
                Debug.LogWarning("Pool warning tag" + tag + "doesn't excist.");

            }

            GameObject objectToSpawn = poolDictionary[tag].Dequeue();

            objectToSpawn.SetActive(true);
            objectToSpawn.transform.parent = Bulletproductionpoint.transform;
            objectToSpawn.transform.localPosition = Vector3.zero;
            objectToSpawn.transform.localRotation = rotation;

            poolDictionary[tag].Enqueue(objectToSpawn);


    }


}
