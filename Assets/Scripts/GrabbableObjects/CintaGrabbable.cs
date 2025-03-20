using UnityEngine;
using Oculus.Interaction;
using System;
using Meta.XR.MRUtilityKit;

public class CintaGrabbable : MonoBehaviour
{
    
    public GameObject TrozoEsparatrapo;

    private Grabbable grabbable;
    public Rigidbody rb;
    private bool SoloUnUso = false;
    private MeshRenderer meshRenderer;
    private Transform Spawn;

    void Awake()
    {
        grabbable = GetComponent<Grabbable>();
        grabbable.Agarrado = false;
        meshRenderer = transform.Find("Visuals/EsparadrapoMesh/Mesh")?.GetComponent<MeshRenderer>();
        meshRenderer.enabled = false;

        Debug.Log("Estoy siendo creado");
    }

    private void Start()
    {
        Spawn = transform.parent?.Find("Spawn");
    }

    void Update()
    {
        if (grabbable.Agarrado && !SoloUnUso)
        {
            SoloUnUso = true;
            meshRenderer.enabled = true;
            GameObject nuevoTrozo = Instantiate(TrozoEsparatrapo, Spawn.position, Quaternion.identity);
            nuevoTrozo.transform.SetParent(transform.parent);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            Destroy(gameObject);
        }
    }
}