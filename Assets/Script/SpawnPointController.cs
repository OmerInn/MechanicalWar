using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointController : MonoBehaviour
{
    public GameObject spawnpoint1;
    public GameObject spawnpoint2;
    public GameObject spawnpoint3;
    public GameObject spawnpoint4;

    public GameObject enemy;
    public bool product;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!product)
        {
            product = true;
            StartCoroutine(EnemySpawn());
        }
    }
    public IEnumerator EnemySpawn()   
    {
        Instantiate(enemy, spawnpoint1.transform);
        Instantiate(enemy, spawnpoint2.transform);
        Instantiate(enemy, spawnpoint3.transform);
        Instantiate(enemy, spawnpoint4.transform);

        yield return new WaitForSeconds(5);
        product = false;
    }
}
