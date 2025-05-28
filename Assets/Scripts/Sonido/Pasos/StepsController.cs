using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class StepsController : MonoBehaviour
{

    [SerializeField] private CharacterController controller;
    [SerializeField] private UnityEvent f_stepSoundEvent;

    private bool isWalking = false;

    void Start()
    {
        StartCoroutine(StepSoundRoutine());
    }

    private void Update()
    {
        if (controller == null) return;

        isWalking = controller.velocity.magnitude > 0.1f;
    }

    private IEnumerator StepSoundRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.4f);
            if (isWalking && f_stepSoundEvent != null)
            {
                f_stepSoundEvent.Invoke();
            }
            yield return null;
        }
    }
}
