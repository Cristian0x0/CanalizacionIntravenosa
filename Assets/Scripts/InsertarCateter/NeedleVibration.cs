using Oculus.Haptics;
using System.Collections.Generic;
using UnityEngine;

public class NeedleVibration : MonoBehaviour
{
    //Este script viene controlado por el GameManager, solo se activa en en paso oportuno.

    public HapticSource hapticSource; // Asigna desde el Inspector

    [HideInInspector] public bool hapticPlaying = false;

    [HideInInspector] public bool canVibrate = true;

    //Vamos a simular que la canula se llena de sangre al pinchar la vena

    [SerializeField] private float fillVelocity = 2f; // Ritmo de llenado
    [SerializeField] private float startHeight = 0.001f; // Dimensión ocupada por la sangre dentro de la canula al estar completamente llena
    [SerializeField] private float endHeight = 0.021f; // Dimensión ocupada por la sangre dentro de la canula al estar completamente llena

    private float elapsedTime = 0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pincho") && !hapticPlaying && hapticSource != null && canVibrate)
        {
            hapticSource.Play();
            hapticPlaying = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Pincho"))
        {
            GameObject blood = other.transform.GetChild(0).gameObject;

            blood.SetActive(true);


            if (blood == null)
            {
                Debug.LogError("No le has puesto la sangre a la cánula.");
                return;
            }

            if (blood.transform.localScale.z >= endHeight) return;

            elapsedTime += Time.deltaTime;

            float t = Mathf.Clamp01(elapsedTime / fillVelocity);
            float currentLength = Mathf.Lerp(startHeight, endHeight, t);

            blood.transform.localScale = new Vector3(blood.transform.localScale.x, blood.transform.localScale.y, currentLength);

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
