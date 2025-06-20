using System.Collections;
using UnityEngine;

public class AudioTimeController : MonoBehaviour
{
    public AudioSource audioSource;

    //[Range(0.5f, 2.0f)] public float soundSpeed = 1.0f;

    [SerializeField] private float realValue = 0.58f;


    private void Start()
    {
        if (audioSource != null)
        {
            audioSource.pitch = realValue;
            StartCoroutine(StartBreathing());
        }
    }

    IEnumerator StartBreathing()
    {
        // Esperamos un segundo antes de ajustar el pitch
        yield return new WaitForSeconds(1f);
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }

    //Comentamos esto porque ya hemos averiguado la velocidad a la que debe estar
    /*
    void Update()
    {
        if (audioSource == null || audioSource.clip == null) return;

        audioSource.pitch = soundSpeed;
    }
    */
}