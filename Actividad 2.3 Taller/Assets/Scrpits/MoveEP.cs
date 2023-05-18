using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MoveEP : MonoBehaviour
{

    [SerializeField] protected float moveSpeed = 5f;
    [SerializeField] private int health = 1;

    protected Rigidbody rb;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public virtual void Move(Vector3 direction)
    {
        rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
    }

    public virtual void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
