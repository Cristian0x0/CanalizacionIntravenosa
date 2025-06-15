using Oculus.Interaction;
using UnityEngine;

public class CarritoBehaviour : MonoBehaviour
{
    [SerializeField ]private Grabbable myGrab;

    // Update is called once per frame
    void Update()
    {
        if (myGrab.Agarrado)
        {
            Physics.IgnoreLayerCollision(gameObject.layer, 6, true);
        }
        else
        {
            Physics.IgnoreLayerCollision(gameObject.layer, 6, false);
        }
    }
}
