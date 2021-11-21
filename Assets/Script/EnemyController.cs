using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    NavMeshAgent nMesh;
    public Animator Anim;
    public GameObject gun;
    public bool Death;
    // Start is called before the first frame update
    void Start()
    {
        nMesh = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        nMesh.SetDestination(GameObject.FindGameObjectWithTag("Player").transform.position);
      
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag=="Bullet")
        {
            if (!Death)
            {
                Death = true;
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().scoreText();
                collision.gameObject.SetActive(false);
                gun.SetActive(false);
                nMesh.speed = 0;
                Anim.Play("Death");
                Destroy(this.gameObject, 5);
            }
            
        }
    }
}
