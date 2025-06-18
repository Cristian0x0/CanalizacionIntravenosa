using Oculus.Haptics;
using Oculus.Interaction.Editor;
using System.Collections.Generic;
using UnityEngine;

public class RightZone : MonoBehaviour
{

    //Este script viene controlado por el GameManager, solo se activa en en paso oportuno.

    public float TimeUntilDone = 5f;

    private List<Transform> handsInside = new List<Transform>();
    private float stayTimer = 0f;
    private bool timerActive = false;

    private int contactCount = 0; //Para saber cuantas veces ha sido encontrada la vena antes de pasar al siguiente paso. Si solo es una vez significa que lo ha conseguido a la primera, y por lo tanto el usuario obtiene el logro "Unmatched Nurse"

    [SerializeField] private NearbyArea nearbyArea;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hands") && !handsInside.Contains(other.transform))
        {
            handsInside.Add(other.transform);

            contactCount++;

            if (!timerActive)
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
                if (nearbyArea != null && nearbyArea.hapticSource != null)
                {   
                    nearbyArea.hapticSource.Stop();
                    nearbyArea.hapticPlaying = false;
                }
                if(contactCount == 1)
                {
                    KeepAchievements.instance.UnmatchedNurseAchievement();
                }
                GameManager.controladorAplicacion.stepCompleted();
                GameManager.controladorAplicacion.CambiarEstadoJuego(GameState.AplicarAntiseptico);
            }
        }
    }
}
