using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4 : MonoBehaviour
{
    public float cadenciaDeDisparo;
    public float distancia;
    public Transform jugador;
    public GameObject bala;
    private bool puedeDisparar = true;

    // Update is called once per frame
    void Update()
    {
        distancia = Vector3.Distance(transform.position, jugador.position);

        if (distancia < 6f && puedeDisparar)
        {
            Disparar();
            StartCoroutine(EsperarCadencia());
        }
    }

    void Disparar()
    {
        Instantiate(bala, transform.position, transform.rotation);
        puedeDisparar = false;
    }

    IEnumerator EsperarCadencia()
    {
        yield return new WaitForSeconds(cadenciaDeDisparo);
        puedeDisparar = true;
    }
}
