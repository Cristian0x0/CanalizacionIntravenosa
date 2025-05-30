using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CambioGuantes : MonoBehaviour
{

    public Material nuevoMaterial;
    [SerializeField] private Renderer PrimerObjeto;
    [SerializeField] private Renderer SegundoObjeto;
    private Material materialDefault;
    private Renderer objectRenderer;
    private bool ScriptActivo = false;
    private bool stepDone = false;

    private void Awake()
    {
        GameManager.EnEstadoJuegoCambiado += ComprobarActivacion;
    }

    private void ComprobarActivacion(GameState state)
    {
        if (state == GameState.PonerseGuantes || state == GameState.RetirarGuantes)
        {
            stepDone = false;
            ScriptActivo = true;
        }
        else
        {
            ScriptActivo = false;
        }
    }
    void Start()
    {
        objectRenderer = PrimerObjeto.GetComponent<Renderer>();
        materialDefault = objectRenderer.sharedMaterial;
    }

    public void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Guantes") && ScriptActivo && !stepDone)
        {
            if (objectRenderer != null)
            {
                bool esDefault = objectRenderer.sharedMaterial == materialDefault;

                objectRenderer.sharedMaterial = esDefault ? nuevoMaterial : materialDefault;

                if (SegundoObjeto != null)
                {
                    SegundoObjeto.sharedMaterial = esDefault ? nuevoMaterial : materialDefault;
                }
                stepDone = true;
            }
        }
    }
}
