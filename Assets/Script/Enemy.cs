using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float distance;

    public Transform target;
    NavMeshAgent nMesh;
    Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        nMesh = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        nMesh.SetDestination(GameObject.FindGameObjectWithTag("Player").transform.position);
        /*
        distance = Vector3.Distance(transform.position, target.position);
        pos = new Vector3(target.position.x, transform.position.y, target.position.z);*/
    }
}
