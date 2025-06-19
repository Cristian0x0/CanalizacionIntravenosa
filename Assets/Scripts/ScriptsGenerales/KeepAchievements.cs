using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeepAchievements : MonoBehaviour
{
    public static KeepAchievements instance;

    [SerializeField] private List<Button> AchievementsButtons;
    [SerializeField] private List<Sprite> Achievements;
    [SerializeField] private List<bool> Achieved;

    [SerializeField] private Notifications notifications;
    [HideInInspector]public int SimulationCompleteTimes = 0; //Utilizado para obtener los logros "Great learner" y "Absolute dedication"

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void updateAchievements()
    {
        
        notifications = GameObject.Find("NotificationsCanvas").GetComponent<Notifications>();

        //Tenemos que volver a referenciar los botones en cada reinicio
        GameObject panel = GameObject.Find("AchievementsButtons");
        if (panel != null)
        {
            AchievementsButtons.Clear();
            AchievementsButtons.AddRange(panel.GetComponentsInChildren<Button>());
        }

        //Actualizamos estos botones

        for (int i = 0; i < Achieved.Count; i++)
        {
            if (Achieved[i] && AchievementsButtons[i].image.sprite != Achievements[i])
            {
                AchievementsButtons[i].image.sprite = Achievements[i];
            }
        }

        if (SimulationCompleteTimes == 1) UnlockAchievement(4);
        if (SimulationCompleteTimes == 3) UnlockAchievement(5);
    }

    //Funciones que se ejecutan al conseguir un logro

    public void UnlockAchievement(int index)
    {
        if (AchievementsButtons[index].image.sprite == Achievements[index]) return;

        notifications.ShowNotification(index);
        Achieved[index] = true;
        AchievementsButtons[index].image.sprite = Achievements[index];
    }
}
