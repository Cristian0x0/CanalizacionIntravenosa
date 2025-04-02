using UnityEngine;

public class ReiniciarPosicion : MonoBehaviour
{

    private Transform posicionInicial;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        posicionInicial = this.transform;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Suelo")
        {
            this.transform.position = posicionInicial.position;
            this.transform.rotation = posicionInicial.rotation;
        }
    }
}
