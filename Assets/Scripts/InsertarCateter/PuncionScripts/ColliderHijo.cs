using UnityEngine;

public class ColliderHijo : MonoBehaviour
{
    public string triggerID; // Por ejemplo: "A" o "B"
    public ColliderManager manager; // Referencia al padre

    private void OnTriggerEnter(Collider other)
    {
        manager.RegisterTriggerEnter(triggerID, other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        manager.RegisterTriggerExit(triggerID, other.gameObject);
    }
}
