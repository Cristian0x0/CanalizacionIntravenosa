using Oculus.Haptics;
using Oculus.Interaction.Editor;
using System.Collections.Generic;
using UnityEngine;

public class RightZone : MonoBehaviour
{
    public float TimeUntilDone = 5f;

    private List<Transform> handsInside = new List<Transform>();
    private float stayTimer = 0f;
    private bool timerActive = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hands") && !handsInside.Contains(other.transform))
        {
            handsInside.Add(other.transform);

            if(!timerActive)
            {
                timerActive = true;
                stayTimer = 0f;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hands"))
        {
            handsInside.Remove(other.transform);
        }

        if (handsInside.Count == 0)
        {
            timerActive = false;
            stayTimer = 0f;
        }
    }

    private void Update()
    {
        if (timerActive)
        {
            stayTimer += Time.deltaTime;

            if (stayTimer >= TimeUntilDone)
            {
                Debug.Log("Timer Done");
            }
        }
    }
}
