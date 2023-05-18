using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MoveEP, IShootable
{
    [SerializeField] private int damage;
    [SerializeField] private int life;
    [SerializeField] private int DistanciaEnemy2;
    // Start is called before the first frame update

    //bullet
    public GameObject bulletPrefab, Projectile;

    public float bulletSpeed;

    private GameObject player;

    //Move
    public float velocidad = 2.0f;
    public bool moveRight = true;
    private GameObject enemigoObject;

    protected override void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemigoObject = gameObject;


        StartCoroutine(retrasado());
    }
    private IEnumerator retrasado()
    {
        yield return new WaitForSeconds(3);
        Shoot(player.transform.position);
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
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<MoveEP>().TakeDamage(1);
        }
    }



    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(enemigoObject.GetComponent<Transform>().position, player.GetComponent<Transform>().position) > DistanciaEnemy2)
        {
            enemigoObject.transform.position -= (enemigoObject.transform.position - player.transform.position).normalized * velocidad * Time.deltaTime;
        }
    }
}