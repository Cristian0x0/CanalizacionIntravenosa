using Unity.VisualScripting;
using UnityEngine;

public class HandsBehaviour : MonoBehaviour
{
    //Este script se engarga de activar y desactivar los colliders de las manos dependiendo de si el usuario se encuentra realizando el proceso o está en el menú.

    //A continuación se muestran todos los colliders de las manos destinados a agarrar objetos

    [SerializeField] private Collider leftHandGripCollider;
    [SerializeField] private Collider leftHandPinchCollider;
    [SerializeField] private Collider rightHandGripCollider;
    [SerializeField] private Collider rightHandPinchCollider;
    [SerializeField] private Collider leftHandControllerGripCollider;
    [SerializeField] private Collider leftHandControllerPinchCollider;
    [SerializeField] private Collider rightHandControllerGripCollider;
    [SerializeField] private Collider rightHandControllerPinchCollider;

    private void Start()
    {
        GameManager.EnEstadoJuegoCambiado += ComprobarActivacion;

        leftHandGripCollider.enabled = false;
        leftHandPinchCollider.enabled = false;
        rightHandGripCollider.enabled = false;
        rightHandPinchCollider.enabled = false;
        leftHandControllerGripCollider.enabled = false;
        leftHandControllerPinchCollider.enabled = false;
        rightHandControllerGripCollider.enabled = false;
        rightHandControllerPinchCollider.enabled = false;
    }

    private void ComprobarActivacion(GameState state)
    {
        if (state != GameState.MainMenuStep)
        {
            leftHandGripCollider.enabled = true;
            leftHandPinchCollider.enabled = true;
            rightHandGripCollider.enabled = true;
            rightHandPinchCollider.enabled = true;
            leftHandControllerGripCollider.enabled = true;
            leftHandControllerPinchCollider.enabled = true;
            rightHandControllerGripCollider.enabled = true;
            rightHandControllerPinchCollider.enabled = true;

            GameManager.EnEstadoJuegoCambiado -= ComprobarActivacion;
        }
    }
}
