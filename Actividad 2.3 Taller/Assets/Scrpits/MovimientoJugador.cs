using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public float Velocidad;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float MovimientoHorizontal = Input.GetAxis("Horizontal");
        float MovimientoVertical = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(MovimientoHorizontal * Velocidad, 0, MovimientoVertical*Velocidad);
    }
}
