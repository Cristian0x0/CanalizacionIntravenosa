using Oculus.Interaction;
using System;
using UnityEngine;

public class ColisionSueroSoporte : MonoBehaviour
{
    public Transform[] puntosColocacion; // Lista de puntos de colocación
    private GameObject boteEnZona;
    private Rigidbody rb;

    private bool ScriptActivo = false;

    [HideInInspector]
    public bool boteColocado = false;

    [SerializeField] private AudioSource conexionSound;

    private void Start()
    {
        GameManager.EnEstadoJuegoCambiado += ComprobarActivacion;
    }

    private void OnDestroy()
    {
        GameManager.EnEstadoJuegoCambiado -= ComprobarActivacion;
    }

    private void ComprobarActivacion(GameState state)
    {
        if(state == GameState.PrepararSistema)
        {
            ScriptActivo = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Suero") && ScriptActivo && !boteColocado)
        {
            boteEnZona = other.gameObject; // Guardamos referencia al bote
            rb = boteEnZona.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.LockKinematic();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Suero") && boteEnZona == other.gameObject && ScriptActivo)
        {
            if (rb != null)
            {
                rb.UnlockKinematic();
            }
            boteEnZona = null; // Si el bote sale, lo olvidamos
            boteColocado = false;
        }
    }

    public void SoltarBote()
    {
        if (boteEnZona != null && ScriptActivo && !boteColocado)
        {
            if (conexionSound != null)
            {
                conexionSound.Play();
            }
            boteEnZona.GetComponent<SueroGrabbable>().enabled = false;

            Transform puntoMasCercano = ObtenerPuntoMasCercano(boteEnZona.transform.position);

            boteEnZona.transform.parent = puntoMasCercano;
            boteEnZona.transform.localPosition = Vector3.zero;

            boteEnZona.transform.rotation = puntoMasCercano.rotation;

            boteEnZona.GetComponent<SueroGrabbable>().enabled = true;

            boteColocado = true;

            boteEnZona.GetComponent<BoxCollider>().enabled = false;
        }
    }

    private Transform ObtenerPuntoMasCercano(Vector3 posicionBote)
    {
        Transform puntoCercano = puntosColocacion[0];
        float distanciaMinima = Vector3.Distance(posicionBote, puntoCercano.position);

        foreach (Transform punto in puntosColocacion)
        {
            float distancia = Vector3.Distance(posicionBote, punto.position);
            if (distancia < distanciaMinima)
            {
                distanciaMinima = distancia;
                puntoCercano = punto;
            }
        }

        return puntoCercano;
    }
}