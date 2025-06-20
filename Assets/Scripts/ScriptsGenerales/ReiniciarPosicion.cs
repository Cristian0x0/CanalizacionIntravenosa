using UnityEngine;

public class ReiniciarPosicion : MonoBehaviour
{

    private Vector3 posicionInicial;
    private Quaternion rotacionInicial;

    [Tooltip("Opcional, para objetos conectados a otros, como es el caso del sistema de suero.")]
    [SerializeField] private Transform segundoObjetoOpcional;
    [SerializeField] private AudioSource FloorContactSound;
    private Vector3 segundaPosicionInicial;
    private Quaternion segundaRotacionInicial;

    private Rigidbody rb;
    private Rigidbody rbOpcional;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        posicionInicial = transform.position;
        rotacionInicial = transform.rotation;

        if (segundoObjetoOpcional != null)
        {
            segundaPosicionInicial = segundoObjetoOpcional.position;
            segundaRotacionInicial = segundoObjetoOpcional.rotation;
            rbOpcional = segundoObjetoOpcional.GetComponent<Rigidbody>();
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Suelo")
        {
            if (FloorContactSound != null)
            {
                FloorContactSound.Play();
            }
            if (GameManager.controladorAplicacion.modoJuego == gameMode.Expert)
            {
                GameManager.controladorAplicacion.FailedSimulation();
            }
            else
            {
                resetPosition();
            }
            GameManager.controladorAplicacion.ObjetosCaidos = true;
        }
    }

    public void resetPosition()
    {
        transform.position = posicionInicial;
        transform.rotation = rotacionInicial;

        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        if (segundoObjetoOpcional != null)
        {

            segundoObjetoOpcional.position = segundaPosicionInicial;
            segundoObjetoOpcional.rotation = segundaRotacionInicial;

            if (rbOpcional != null)
            {
                rbOpcional.linearVelocity = Vector3.zero;
                rbOpcional.angularVelocity = Vector3.zero;
            }
        }
    }
}
