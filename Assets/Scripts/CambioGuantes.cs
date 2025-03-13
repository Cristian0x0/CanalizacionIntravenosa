using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioGuantes : MonoBehaviour
{

    public Material nuevoMaterial;
    private Material MaterialDefault;
    private Renderer objectRenderer;

    // Start is called before the first frame update
    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        MaterialDefault = objectRenderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Guantes"))
        {
            Debug.Log(objectRenderer.material);
            if (objectRenderer != null && objectRenderer.material == MaterialDefault)
            {
                
                objectRenderer.material = nuevoMaterial;
                nuevoMaterial = objectRenderer.material;
                
            }
            else if (objectRenderer != null && objectRenderer.material == nuevoMaterial)
            {
 
                objectRenderer.material = MaterialDefault;
                MaterialDefault = objectRenderer.material;

            }
        }
    }
}
