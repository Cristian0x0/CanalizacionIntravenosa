using UnityEngine;

public class ReiniciarPosicion : MonoBehaviour
{

    private Vector3 posicionInicial;
    private Quaternion rotacionInicial;

    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        posicionInicial = transform.position;
        rotacionInicial = transform.rotation;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Suelo")
        {
            transform.position = posicionInicial;
            transform.rotation = rotacionInicial;

            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }
    }
}
