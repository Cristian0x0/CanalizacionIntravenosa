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

    private Notifications notifications;
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
        if(SimulationCompleteTimes == 1) GreatLearnerAchievement();
        if (SimulationCompleteTimes == 3) AbsoluteDedicationAchievement();
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
    }

    //Funciones que se ejecutan al conseguir un logro

    public void EverythingInPlaceAchievement()
    {
        if (AchievementsButtons[0].image.sprite == Achievements[0]) return;
        notifications.ShowNotification(0);
        Achieved[0] = true;
        AchievementsButtons[0].image.sprite = Achievements[0];
    }

    public void SteadyHandsAchievement()
    {
        if (AchievementsButtons[1].image.sprite == Achievements[1]) return;
        notifications.ShowNotification(1);
        Achieved[1] = true;
        AchievementsButtons[1].image.sprite = Achievements[1];
    }

    public void TrueProfessionalAchievement()
    {
        if (AchievementsButtons[2].image.sprite == Achievements[2]) return;
        notifications.ShowNotification(2);
        Achieved[2] = true;
        AchievementsButtons[2].image.sprite = Achievements[2];
    }

    public void UnmatchedNurseAchievement()
    {
        if (AchievementsButtons[3].image.sprite == Achievements[3]) return;
        notifications.ShowNotification(3);
        Achieved[3] = true;
        AchievementsButtons[3].image.sprite = Achievements[3];
    }

    public void GreatLearnerAchievement()
    {
        if (AchievementsButtons[4].image.sprite == Achievements[4]) return;
        notifications.ShowNotification(4);
        Achieved[4] = true;
        AchievementsButtons[4].image.sprite = Achievements[4];
    }

    public void AbsoluteDedicationAchievement()
    {
        if (AchievementsButtons[5].image.sprite == Achievements[5]) return;
        notifications.ShowNotification(5);
        Achieved[5] = true;
        AchievementsButtons[5].image.sprite = Achievements[5];
    }

    public void ReadyForActionAchievement()
    {
        if (AchievementsButtons[6].image.sprite == Achievements[6]) return;
        notifications.ShowNotification(6);
        Achieved[6] = true;
        AchievementsButtons[6].image.sprite = Achievements[6];
    }

    public void ABrightFutureAchievement()
    {
        if (AchievementsButtons[7].image.sprite == Achievements[7]) return;
        notifications.ShowNotification(7);
        Achieved[7] = true;
        AchievementsButtons[7].image.sprite = Achievements[7];
    }
}
