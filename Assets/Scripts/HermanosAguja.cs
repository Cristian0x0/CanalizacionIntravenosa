using UnityEngine;
using System.Collections.Generic;
using Oculus.Interaction;

public class HermanosAguja : MonoBehaviour
{
    public List<Transform> groupMembers = new List<Transform>();

    private Dictionary<Transform, Vector3> lastPositions = new Dictionary<Transform, Vector3>();
    private Dictionary<Transform, Quaternion> lastRotations = new Dictionary<Transform, Quaternion>();

    private Transform currentlyGrabbed = null;
    private bool isUpdating = false;

    void Start()
    {
        foreach (var member in groupMembers)
        {
            if (member != null)
            {
                lastPositions[member] = member.position;
                lastRotations[member] = member.rotation;
            }
        }
    }

    void LateUpdate()
    {
        if (isUpdating) return;
        isUpdating = true;

        // Verificar si alguien está agarrado
        currentlyGrabbed = null;
        foreach (var member in groupMembers)
        {
            var grab = member.GetComponent<Grabbable>();
            if (grab != null && grab.Agarrado)
            {
                currentlyGrabbed = member;
                break;
            }
        }

        // Activar/desactivar isKinematic según corresponda
        foreach (var member in groupMembers)
        {
            Rigidbody rb = member.GetComponent<Rigidbody>();
            if (rb == null) continue;

            if (currentlyGrabbed != null)
            {
                rb.isKinematic = (member != currentlyGrabbed); // Solo el agarrado se queda libre
            }
            else
            {
                rb.isKinematic = false; // Todos libres si nadie está agarrado
            }
        }

        // Aplicar sincronización de movimiento
        foreach (var member in groupMembers)
        {
            if (member == currentlyGrabbed) continue; // el que está siendo agarrado no mueve a los demás

            Vector3 lastPos = lastPositions[member];
            Quaternion lastRot = lastRotations[member];

            Vector3 currentPos = member.position;
            Quaternion currentRot = member.rotation;

            Vector3 deltaPos = currentPos - lastPos;
            Quaternion deltaRot = currentRot * Quaternion.Inverse(lastRot);

            if (deltaPos != Vector3.zero || deltaRot != Quaternion.identity)
            {
                foreach (var other in groupMembers)
                {
                    if (other != member && other != currentlyGrabbed)
                    {
                        other.position += deltaPos;
                        other.rotation = deltaRot * other.rotation;
                    }
                }
                break;
            }
        }

        // Guardar estado final
        foreach (var member in groupMembers)
        {
            lastPositions[member] = member.position;
            lastRotations[member] = member.rotation;
        }

        isUpdating = false;
    }
}
