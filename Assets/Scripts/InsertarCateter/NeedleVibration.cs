using Oculus.Haptics;
using System.Collections.Generic;
using UnityEngine;

public class NeedleVibration : MonoBehaviour
{
    //Este script viene controlado por el GameManager, solo se activa en en paso oportuno.

    public HapticSource hapticSource; // Asigna desde el Inspector

    [HideInInspector] public bool hapticPlaying = false;

    [HideInInspector] public bool canVibrate = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pincho") && !hapticPlaying && hapticSource != null && canVibrate)
        {
            hapticSource.Play();
            hapticPlaying = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Pincho") && hapticSource != null && canVibrate)
        {
            StopHapticFeedback();
        }
    }

    public void StopHapticFeedback()
    {
        if (hapticSource != null)
        {
            hapticSource.Stop();
            hapticPlaying = false;
        }
    }
}
