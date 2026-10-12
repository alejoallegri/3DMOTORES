
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public float velocidad = 20f;
    public float fuerzaSalto = 7f;
    public float aceleracionFrenado = 10f;

    private Rigidbody rb;
    private bool isGrounded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 movimiento = new Vector3(horizontal, 0f, vertical).normalized;

        Vector3 velocidadActual = new Vector3(
            rb.linearVelocity.x, 0f, rb.linearVelocity.z
        );

        Vector3 velocidadDeseada = movimiento * velocidad;

        Vector3 cambio = velocidadDeseada - velocidadActual;
        cambio = Vector3.ClampMagnitude(cambio, aceleracionFrenado * Time.fixedDeltaTime);

        rb.AddForce(cambio, ForceMode.VelocityChange);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = false;
    }
}
