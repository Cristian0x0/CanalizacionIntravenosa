using UnityEngine;

public class ColliderHijo : MonoBehaviour
{
    public string triggerID; // Por ejemplo: "A" o "B"
    public ColliderManager manager; // Referencia al padre

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pincho"))
        {
            manager.RegisterTriggerEnter(triggerID, other.gameObject);
            manager.canulaReference = other.transform.parent.parent.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Pincho"))
        {
            manager.RegisterTriggerExit(triggerID, other.gameObject);
        }
    }
}
