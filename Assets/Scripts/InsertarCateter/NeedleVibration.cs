using Oculus.Haptics;
using System.Collections.Generic;
using UnityEngine;

public class NeedleVibration : MonoBehaviour
{
    //Este script viene controlado por el GameManager, solo se activa en en paso oportuno.

    public HapticSource hapticSource; // Asigna desde el Inspector

    [HideInInspector] public bool hapticPlaying = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pincho") && !hapticPlaying && hapticSource != null)
        {
            hapticSource.Play();
            hapticPlaying = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Pincho") && hapticSource != null)
        {
            hapticSource.Stop();
            hapticPlaying = false;
        }
    }
}
