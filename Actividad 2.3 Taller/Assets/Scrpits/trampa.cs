using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trampa : MonoBehaviour
{
    [SerializeField] private Rigidbody rb3d;
    public float speed;
    public float moveTimer;
    
    // Start is called before the first frame update
    void Start()
    {

        rb3d = GetComponent<Rigidbody>();
        StartCoroutine(ChangeDirection());
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {

        rb3d.velocity = new Vector3(rb3d.velocity.x, speed);

    }

    IEnumerator ChangeDirection()
    {
        while (true)
        {
            yield return new WaitForSeconds(moveTimer);
            speed *= -1;
        }
    }
    private void OnTriggerEnter3D(Collider collision)
    {
        
    }

}
