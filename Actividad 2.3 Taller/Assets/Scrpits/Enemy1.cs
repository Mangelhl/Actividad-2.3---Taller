using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MoveEP, IShootable
{
    [SerializeField] private int damage;
    [SerializeField] private int life;
    // Start is called before the first frame update

    //bullet
    public GameObject bulletPrefab, Projectile;

    public float bulletSpeed = 10f;

    private GameObject player;

    //Move
    public float velocidad = 2.0f;
    public bool moveRight = true;
    private GameObject enemigoObject;
    private float limitLeft = -1.0f;
    private float limitRight = 1.0f;

    private IEnumerator retrasado()
    {
        yield return new WaitForSeconds(3);
        Shoot(transform.forward);
        StartCoroutine(retrasado());
    }

    public void Shoot(Vector3 direction)
    {
        GameObject bullet = Instantiate(bulletPrefab, Projectile.transform.position, Projectile.transform.rotation);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.velocity = direction * bulletSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<MoveEP>().TakeDamage(1);
        }
    }

    protected override void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemigoObject = gameObject;


        limitLeft = transform.position.x - 5.0f;
        limitRight = transform.position.x + 5.0f;
        StartCoroutine(retrasado());
    }

    // Update is called once per frame
    void Update()
    {
        if(moveRight)
        {
            enemigoObject.transform.Translate(Vector2.right * velocidad * Time.deltaTime);
            if (enemigoObject.transform.position.x >= limitRight)
            {
                moveRight = false;
            }
        }

        else
        {
            enemigoObject.transform.Translate(Vector2.left * velocidad * Time.deltaTime);
            if (enemigoObject.transform.position.x <= limitLeft)
            {
                moveRight = true;
            }
        }
    }
}
