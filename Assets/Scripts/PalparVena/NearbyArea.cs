using UnityEngine;
using System.Collections.Generic;
using Oculus.Haptics;
public class NearbyArea : MonoBehaviour
{
    private List<Transform> handsInside = new List<Transform>();
    public bool IsHandInside => handsInside.Count > 0;

    public HapticSource hapticSource; // Asigna desde el Inspector
    public float maxDistance = 0.5f;

    [HideInInspector] public bool hapticPlaying = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hands") && !handsInside.Contains(other.transform))
        {
            handsInside.Add(other.transform);

            if (!hapticPlaying && hapticSource != null)
            {
                hapticSource.Play();
                hapticPlaying = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hands"))
        {
            handsInside.Remove(other.transform);

            if (handsInside.Count == 0 && hapticSource != null)
            {
                hapticSource.Stop();
                hapticPlaying = false;
            }
        }
    }

    private void Update()
    {
        if (IsHandInside && hapticSource != null)
        {
            float closestDistance = float.MaxValue;

            foreach (var hand in handsInside)
            {
                float distance = Vector3.Distance(transform.position, hand.position);
                if (distance < closestDistance)
                    closestDistance = distance;
            }

            float normalized = Mathf.Clamp01(1 - (closestDistance / maxDistance));
            normalized = Mathf.Pow(normalized, 2f);
            hapticSource.amplitude = normalized;
        }
    }
}
