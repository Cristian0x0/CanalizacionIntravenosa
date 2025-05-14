using Oculus.Interaction;
using UnityEngine;

public class WastebasketBehaviour : MonoBehaviour
{
    private Grabbable myGrab;
    void Start()
    {
        myGrab = GetComponent<Grabbable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (myGrab.Agarrado)
        {
            Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Papelera"), true);
        }
        else
        {
            Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Papelera"), false);
        }
    }
}
