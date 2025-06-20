using Oculus.Interaction;
using Oculus.Platform.Models;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class ConectorALlave : MonoBehaviour
{
    [SerializeField] private Transform NuevaPosicion;
    [SerializeField] private GameObject colliders; //Estos hay que quitarlos para que el conector del sistema de suero no pueda ser cogido
    [SerializeField] private SoltarConectorSistema SoltarConectorSistemaCompleto;
    [SerializeField] private SoltarConectorSistema SoltarConectorSistemaCompleto2;
    [SerializeField] private AudioSource conexionSound;
    private Grabbable grabbable;
    private Grabbable myGrab;
    private Rigidbody rb;
    private ConfigurableJoint joint;

    private bool stepDone = false;

    private bool nextLevel = true;

    [SerializeField] private ColisionSistemaSuero colisionSistemaSuero;



    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        myGrab = GetComponent<Grabbable>();

        SoltarConectorSistemaCompleto.enabled = false;
        SoltarConectorSistemaCompleto2.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Llave3Pasos") && colisionSistemaSuero.pinchoConectado && !stepDone)
        {
            if (conexionSound != null)
            {
                conexionSound.Play();
            }
            //rb.LockKinematic();
            grabbable = other.GetComponent<Grabbable>();
            if (grabbable != null)
            {
                myGrab.enabled = false;
                //grabbable.enabled = false; // Desactivar el Grabbable
                StartCoroutine(EsperarUnSegundo());
            }

            /*
            other.transform.SetParent(Padre.transform);
            other.transform.position = NuevaPosicion.position;
            other.transform.rotation = NuevaPosicion.rotation;
            transform.SetParent(other.transform);
            */

            //other.transform.SetParent(Padre.transform);
            other.transform.position = NuevaPosicion.position;
            other.transform.rotation = NuevaPosicion.rotation;

            //Primer joint

            joint = grabbable.gameObject.AddComponent<ConfigurableJoint>();
            joint.connectedBody = rb;

            //other.GetComponent<Rigidbody>().isKinematic = true;

            // Configuraciones básicas
            joint.xMotion = ConfigurableJointMotion.Free;
            joint.yMotion = ConfigurableJointMotion.Free;
            joint.zMotion = ConfigurableJointMotion.Free;

            joint.angularXMotion = ConfigurableJointMotion.Free;
            joint.angularYMotion = ConfigurableJointMotion.Free;
            joint.angularZMotion = ConfigurableJointMotion.Free;

            // Usar rotación esférica (Slerp)
            joint.rotationDriveMode = RotationDriveMode.Slerp;
            joint.targetPosition = Vector3.zero; // Posición objetivo relativa al objeto conectado

            JointDrive slerpDrive = new JointDrive
            {
                positionSpring = 30000f,     // Cuánta fuerza para alinear rotación
                positionDamper = 200f,       // Amortiguación para evitar temblores
                maximumForce = Mathf.Infinity
            };

            joint.slerpDrive = slerpDrive;
            joint.xDrive = slerpDrive;
            joint.yDrive = slerpDrive;
            joint.zDrive = slerpDrive;


            SoltarConectorSistemaCompleto.enabled = true;
            SoltarConectorSistemaCompleto2.enabled = true;


            colliders.SetActive(false);

            stepDone = true;

            if (nextLevel)
            {
                GameManager.controladorAplicacion.stepCompleted();
                GameManager.controladorAplicacion.CambiarEstadoJuego(GameState.ColocarCompresor);
                nextLevel = false;
            }
        }
    }

    public void deleteJoint()
    {
        if (joint == null) return;
        Destroy(joint);
        SoltarConectorSistemaCompleto.enabled = false;
        SoltarConectorSistemaCompleto2.enabled = false;
        colliders.SetActive(true);
        stepDone = false;
    }

    IEnumerator EsperarUnSegundo()
    {
        // Esperamos 1 segundo
        yield return new WaitForSeconds(1f);

        // Después de 1 segundo, se ejecuta este código
        //grabbable.enabled = true;
        myGrab.enabled = true;
    }
}

