using Oculus.Interaction;
using UnityEngine;

public class KinematicCap : MonoBehaviour
{

    [SerializeField] private Transform parent;

    private Grabbable myGrab;
    private Rigidbody myRigidbody;
    private bool canDisableKinematic = false;
    private bool endScript = false;

    void Start()
    {
        myGrab = GetComponent<Grabbable>();
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(endScript) return;

        if (myGrab.Agarrado)
        {
            canDisableKinematic = true;
            transform.SetParent(parent);
        }
        else
        {
            if (canDisableKinematic)
            {
                endScript = true;
                myRigidbody.isKinematic = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Suelo") && canDisableKinematic)
        {
            gameObject.SetActive(false);
        }
    }
}
