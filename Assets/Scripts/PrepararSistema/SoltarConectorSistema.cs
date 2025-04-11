using Oculus.Interaction;
using System.Collections;
using UnityEngine;

public class SoltarConectorSistema : MonoBehaviour
{
    public Transform connectedObject; // Objeto de referencia
    public float maxDistance = 1.5f; // Distancia máxima antes de soltar
    private Grabbable grabbable; // Referencia al Grabbable

    void Start()
    {
        grabbable = GetComponent<Grabbable>();
    }

    void Update()
    {
        // Si no hay un objeto conectado o no está agarrado, no hacemos nada
        if (connectedObject == null || !grabbable.Agarrado) return;

        // Medir la distancia entre los dos objetos
        float distance = Vector3.Distance(transform.position, connectedObject.position);

        // Si la distancia es mayor al límite, soltar el objeto
        if (distance > maxDistance)
        {
            grabbable.enabled = false;
            StartCoroutine(EsperarUnSegundo());
        }
    }

    IEnumerator EsperarUnSegundo()
    {
        // Esperamos 1 segundo
        yield return new WaitForSeconds(1f);

        // Después de 1 segundo, se ejecuta este código
        grabbable.enabled = true;
    }
}