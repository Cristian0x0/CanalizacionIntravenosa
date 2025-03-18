using Oculus.Interaction;
using System;
using UnityEngine;

public class ColisionSueroSoporte : MonoBehaviour
{
    public Transform[] puntosColocacion; // Lista de puntos de colocación
    private GameObject boteEnZona;
    private Rigidbody rb;

    private bool ScriptActivo = false;

    private void Awake()
    {
        GameManager.EnEstadoJuegoCambiado += ComprobarActivacion;
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
        if (other.CompareTag("Suero") && ScriptActivo)
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
        }
    }

    public void SoltarBote()
    {
        if (boteEnZona != null && ScriptActivo)
        {
            boteEnZona.GetComponent<SueroGrabbable>().enabled = false;

            Transform puntoMasCercano = ObtenerPuntoMasCercano(boteEnZona.transform.position);
            
            boteEnZona.transform.parent = puntoMasCercano;
            boteEnZona.transform.localPosition = Vector3.zero;

            boteEnZona.transform.rotation = puntoMasCercano.rotation;

            boteEnZona.GetComponent<SueroGrabbable>().enabled = true;
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