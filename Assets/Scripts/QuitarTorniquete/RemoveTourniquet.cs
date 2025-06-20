using Oculus.Interaction;
using UnityEngine;

public class RemoveTourniquet : MonoBehaviour
{
    [SerializeField] private Grabbable myGrabbable;
    [SerializeField] private GameObject TourniquetVisuals;
    [SerializeField] private GameObject TiedTourniquet;
    [SerializeField] private AudioSource TorniqueteContact;

    private Rigidbody myRigidbody;
    private bool firstTimeGrabbed = false;

    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (myGrabbable.Agarrado && !firstTimeGrabbed)
        {
            if (TorniqueteContact != null)
            {
                TorniqueteContact.Play();
            }
            firstTimeGrabbed = true;
            TourniquetVisuals.SetActive(true);
            TiedTourniquet.SetActive(false);
            myRigidbody.UnlockKinematic();
            myRigidbody.isKinematic = false;
            myRigidbody.LockKinematic();

            GameManager.controladorAplicacion.stepCompleted();
            GameManager.controladorAplicacion.CambiarEstadoJuego(GameState.ConectarEquipoInfusion);
        }
    }
}
