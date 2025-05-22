using UnityEngine;

public class AudioTimeController : MonoBehaviour
{
    public AudioSource audioSource;

    //[Range(0.5f, 2.0f)] public float soundSpeed = 1.0f;

    private float realValue = 0.53f;


    private void Start()
    {
        if (audioSource != null)
        {
            audioSource.pitch = realValue;
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