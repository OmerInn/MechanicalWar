using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent!=null)
        {
            transform.parent = null;
        }

          rb.AddForce(transform.forward * speed);
       // rb.velocity = transform.forward * speed;
       // this.transform.position += Vector3.forward * Time.deltaTime * speed;
    }
    private void FixedUpdate()
     {
     // 
    }

}
