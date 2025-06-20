using Oculus.Interaction;
using UnityEngine;

public class ColisionSistemaSuero : MonoBehaviour
{
    public Transform puntoColocacion; // Lista de puntos de colocación
    private GameObject sistema;
    private Rigidbody rb;
    [SerializeField] private Collider colliderSistema;
    [SerializeField] private AudioSource conexionSound;

    public ColisionSueroSoporte sePuedeConectar;
    [HideInInspector] public bool pinchoConectado = false;

    private bool stepDone = false;

    private void Update()
    {
        if (sistema != null && !stepDone)
        {
            if (!sistema.GetComponent<SistemaGrabbable>().Agarrado)
            {
                SoltarPincho();
                stepDone = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SistemaSuero") && sePuedeConectar.boteColocado)
        {
            sistema = other.gameObject; // Guardamos referencia al bote
            rb = sistema.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.LockKinematic();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("SistemaSuero") && sistema == other.gameObject && sePuedeConectar.boteColocado)
        {
            if (rb != null)
            {
                rb.UnlockKinematic();
            }
            sistema = null; // Si el bote sale, lo olvidamos
        }
    }

    public void SoltarPincho()
    {
        if (sistema != null && sePuedeConectar.boteColocado)
        {
            if (conexionSound != null)
            {
                conexionSound.Play();
            }
            sistema.GetComponent<SistemaGrabbable>().enabled = false;


            sistema.transform.parent = puntoColocacion;
            sistema.transform.localPosition = Vector3.zero;

            sistema.transform.rotation = puntoColocacion.rotation;

            sistema.GetComponent<SistemaGrabbable>().enabled = true;

            pinchoConectado = true;
            colliderSistema.enabled = false;
        }
    }
}
