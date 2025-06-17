using UnityEngine;

public class KeepAchievements : MonoBehaviour
{
    private static KeepAchievements instance;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            //Debug.Log("Keep" + instance);
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            Debug.Log(gameObject.scene.name);
        }
    }
}
