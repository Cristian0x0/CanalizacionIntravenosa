using System.Collections.Generic;
using UnityEngine;

public class ColliderManager : MonoBehaviour
{
    private Dictionary<GameObject, HashSet<string>> triggerMap = new();

    [HideInInspector] public GameObject canulaReference;

    [SerializeField] private Transform NewCanulaPosition;

    [SerializeField] private NeedleVibration vibrationController;

    private bool fixedSkin = false;
    public void RegisterTriggerEnter(string triggerID, GameObject obj)
    {
        if (!triggerMap.ContainsKey(obj))
            triggerMap[obj] = new HashSet<string>();

        triggerMap[obj].Add(triggerID);

        if (triggerMap[obj].Count == 2 && fixedSkin)
        {
            if(canulaReference != null)
            {
                canulaReference.transform.SetParent(NewCanulaPosition);
                canulaReference.transform.localPosition = Vector3.zero;
                canulaReference.transform.localRotation = Quaternion.identity;

                vibrationController.StopHapticFeedback();
                vibrationController.canVibrate = false;

                GameManager.controladorAplicacion.CambiarEstadoJuego(GameState.RetirarCompresor);
            }
            else
            {
                Debug.Log("Está tocando ambos colliders pero no detecto la canula");
            }
        }
    }

    public void RegisterTriggerExit(string triggerID, GameObject obj)
    {
        if (triggerMap.ContainsKey(obj))
        {
            triggerMap[obj].Remove(triggerID);

            if (triggerMap[obj].Count < 2 && triggerMap[obj].Count > 0)
            {
                Debug.Log($"hola [EXIT] {obj.name} ya no está tocando ambos triggers.");
            }

            if (triggerMap[obj].Count == 0)
                triggerMap.Remove(obj);
        }
    }

    //Eventos para el InteractableUnityEventWrapper de los HandGrabInteractable que posee la operación de estirar la piel
    public void SecondHandInSkin() 
    {
        fixedSkin = true;
    }

    public void NoSecondHandInSkin()
    {
        fixedSkin = false;
    }
}
