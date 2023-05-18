using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy3Bullet : MoveEP
{
    Enemy3 enemi2;
    int contadorbullet;
    bool P;
    private void Awake()
    {
        enemi2 = FindObjectOfType<Enemy3>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
        }
    }
    private IEnumerator BoomerangBullet()
    {
        if (P == true)
        {
            rb.velocity = (GameObject.FindGameObjectWithTag("Player").transform.position - transform.position).normalized * 5f;
        }
            yield return new WaitForSeconds(3);
        rb.velocity = (enemi2.Projectile.transform.position -transform.position).normalized * 5f;
    }
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, enemi2.Projectile.transform.position) < 1)
        {
            P = true;
            rb.velocity = Vector3.zero;
            if (Vector3.Distance(transform.position, enemi2.Projectile.transform.position) < 1f)
            {
                StartCoroutine(BoomerangBullet());
            }
        }
        if (Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) < 0.5f)
        {
            P = false;
            StartCoroutine(BoomerangBullet());
        }
       // rb.velocity = (GameObject.FindGameObjectWithTag("Player").transform.position - transform.position).normalized * 5f;
    }
}
