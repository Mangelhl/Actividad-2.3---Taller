using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaEnemy4 : MonoBehaviour
{
    public float velocidadMovimiento;
    public float tiempoMovimiento = 2f;
    public float tiempoPausa = 1f;

    private Vector3 direccionInicial;
    private bool enMovimiento = true;

    private void Start()
    {
        direccionInicial = (GameObject.FindGameObjectWithTag("Player").transform.position - transform.position).normalized;
        StartCoroutine(MoverHaciaDireccionInicial());
    }

    private void Update()
    {
        if (enMovimiento)
        {
            transform.position += direccionInicial * velocidadMovimiento * Time.deltaTime;
        }
    }

    private IEnumerator MoverHaciaDireccionInicial()
    {
        while (enMovimiento)
        {
            yield return new WaitForSeconds(tiempoMovimiento);
            enMovimiento = false;
            yield return new WaitForSeconds(tiempoPausa);
            enMovimiento = true;
        }
    }
}