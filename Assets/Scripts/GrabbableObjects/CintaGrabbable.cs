using UnityEngine;
using Oculus.Interaction;

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
        else if (!grabbable.Agarrado && SoloUnUso)
        {
            GetComponent<Rigidbody>().isKinematic = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
            gameObject.SetActive(false);
    }
}