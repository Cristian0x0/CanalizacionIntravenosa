using Oculus.Interaction;
using UnityEngine;

public class ArrowBehaviour : MonoBehaviour
{
    private float velocidadRotacion = 45f; // grados por segundo
    [SerializeField] private Grabbable myGrab;
    [SerializeField] private Grabbable optionalGrab;

    void Update()
    {
        transform.Rotate(Vector3.forward, velocidadRotacion * Time.deltaTime, Space.Self);
        if(myGrab.Agarrado) gameObject.SetActive(false);

        if (optionalGrab != null && optionalGrab.Agarrado)
        {
            gameObject.SetActive(false);
        }
    }
}
