using Oculus.Interaction;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class CanulaController : MonoBehaviour
{
    private Grabbable myGrab;
    private bool endScript = false;

    void Start()
    {
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Tapones"), LayerMask.NameToLayer("Manos"), true);
        myGrab = GetComponent<Grabbable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (endScript) return;

        if (myGrab.Agarrado)
        {
            Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Tapones"), LayerMask.NameToLayer("Manos"), false);
            endScript = true;
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
