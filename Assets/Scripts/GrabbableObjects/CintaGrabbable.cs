using UnityEngine;
using Oculus.Interaction;
using System;
using Meta.XR.MRUtilityKit;
using System.Collections;

public class CintaGrabbable : MonoBehaviour
{
    
    public GameObject TrozoEsparatrapo;

    private Grabbable grabbable;
    public Rigidbody rb;
    private bool SoloUnUso = false;
    private MeshRenderer meshRenderer;
    private Transform Spawn;
    [SerializeField] private Collider myCollider;

    void Awake()
    {
        grabbable = GetComponent<Grabbable>();
        grabbable.Agarrado = false;
        meshRenderer = transform.Find("Visuals/EsparadrapoMesh/Mesh")?.GetComponent<MeshRenderer>();
        meshRenderer.enabled = false;
        GetComponent<Rigidbody>().isKinematic = false;
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

    IEnumerator SafeDestroy()
    {
        grabbable.enabled = false;
        myCollider.enabled = false;
        meshRenderer.enabled = false;
        gameObject.SetActive(false);

        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
            StartCoroutine(SafeDestroy());
    }
}