using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioGuantes : MonoBehaviour
{

    public Material nuevoMaterial;
    [SerializeField] private Renderer SegundoObjeto;
    private Material materialDefault;
    private Renderer objectRenderer;

    // Start is called before the first frame update
    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        materialDefault = objectRenderer.sharedMaterial;
    }

    public void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Guantes"))
        {
            Debug.Log("Guanteeeeees");
            if (objectRenderer != null)
            {
                bool esDefault = objectRenderer.sharedMaterial == materialDefault;

                objectRenderer.sharedMaterial = esDefault ? nuevoMaterial : materialDefault;

                if (SegundoObjeto != null)
                {
                    SegundoObjeto.sharedMaterial = esDefault ? nuevoMaterial : materialDefault;
                }
            }
        }
    }
}
