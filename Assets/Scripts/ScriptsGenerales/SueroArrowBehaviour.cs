using Oculus.Interaction;
using UnityEngine;

public class SueroArrowBehaviour : MonoBehaviour
{
    private float velocidadRotacion = 45f; // grados por segundo
    [SerializeField] private SueroGrabbable myGrab;

    void Update()
    {
        transform.Rotate(Vector3.forward, velocidadRotacion * Time.deltaTime, Space.Self);
        if (myGrab.Agarrado) gameObject.SetActive(false);
    }
}
