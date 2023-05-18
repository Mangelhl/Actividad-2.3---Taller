using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Bullet : MoveEP
{
    private void Awake()
    {
        Destroy(gameObject, 4);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        rb.velocity = (GameObject.FindGameObjectWithTag("Player").transform.position - transform.position).normalized * moveSpeed;
    }
}

