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
    private AudioSource PickSound;

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
        PickSound = transform.parent?.Find("EsparadrapoSFX").GetComponent<AudioSource>();
    }

    void Update()
    {
        if (grabbable.Agarrado && !SoloUnUso)
        {
            if (PickSound != null)
            {
                PickSound.Play();
            }
            SoloUnUso = true;
            meshRenderer.enabled = true;
            GameObject nuevoTrozo = Instantiate(TrozoEsparatrapo, Spawn.position, Quaternion.identity);
            nuevoTrozo.transform.SetParent(transform.parent);
        }
        else if (!grabbable.Agarrado && SoloUnUso)
        {
            grabbable.enabled = false;
            GetComponent<Rigidbody>().isKinematic = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
            gameObject.SetActive(false);
    }
}