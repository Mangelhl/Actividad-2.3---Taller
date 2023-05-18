using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy3 : MoveEP, IShootable
{
    [SerializeField] private int damage;
    [SerializeField] private int life;
    [SerializeField] private int distanciaplayer;
    int c;
    // Start is called before the first frame update

    //bullet
    public GameObject bulletPrefab, Projectile;

    public float bulletSpeed ;

    private GameObject player;

    //Move
    public float velocidad = 2.0f;
    private GameObject enemigoObject;

    protected override void Start()
    {
        c = 0;
        player = GameObject.FindGameObjectWithTag("Player");
        enemigoObject = gameObject;


        StartCoroutine(retrasado());
    }
    private IEnumerator retrasado()
    {
        if (c<1) {
            yield return new WaitForSeconds(3);
            Shoot(player.transform.position);
            c++;
        }
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
        if (Vector3.Distance(enemigoObject.GetComponent<Transform>().position, player.GetComponent<Transform>().position)<  distanciaplayer) 
        { 
            enemigoObject.transform.position += (enemigoObject.transform.position-player.transform.position).normalized * velocidad * Time.deltaTime;
     }
    }
}