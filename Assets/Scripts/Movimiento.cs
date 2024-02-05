using UnityEngine;

public class MovimientoEsfera : MonoBehaviour
{
    public float velocidad = 5f;
    public float fuerzaSalto = 10f;

    private Rigidbody rb;
    private bool enSuelo = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Mover();

        if (enSuelo && Input.GetButtonDown("Jump"))
        {
            Saltar();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enSuelo = true;
        }

        if (collision.gameObject.CompareTag("Meta"))
        {
            JuegoTerminado();
        }
    }

    void Mover()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(movimientoHorizontal, 0f, movimientoVertical);
        rb.AddForce(movimiento * velocidad);
    }

    void Saltar()
    {
        rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
        enSuelo = false;
    }

    void JuegoTerminado()
    {
        Debug.Log("¡Juego terminado!");
    }
}