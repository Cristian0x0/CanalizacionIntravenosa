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

    private List<Action> achievementFunctions;

    private Notifications notifications;

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
    }

    //Funciones que se ejecutan al conseguir un logro

    public void EverythingInPlaceAchievement()
    {
        notifications.ShowNotification(0);
        if (AchievementsButtons[0].image.sprite == Achievements[0]) return;
        Achieved[0] = true;
        AchievementsButtons[0].image.sprite = Achievements[0];
    }

    public void SteadyHandsAchievement()
    {
        notifications.ShowNotification(1);
        if (AchievementsButtons[1].image.sprite == Achievements[1]) return;
        Achieved[1] = true;
        AchievementsButtons[1].image.sprite = Achievements[1];
    }

    public void TrueProfessionalAchievement()
    {
        notifications.ShowNotification(2);
        if (AchievementsButtons[2].image.sprite == Achievements[2]) return;
        Achieved[2] = true;
        AchievementsButtons[2].image.sprite = Achievements[2];
    }

    public void UnmatchedNurseAchievement()
    {
        notifications.ShowNotification(3);
        if (AchievementsButtons[3].image.sprite == Achievements[3]) return;
        Achieved[3] = true;
        AchievementsButtons[3].image.sprite = Achievements[3];
    }

    public void GreatLearnerAchievement()
    {
        notifications.ShowNotification(4);
        if (AchievementsButtons[4].image.sprite == Achievements[4]) return;
        Achieved[4] = true;
        AchievementsButtons[4].image.sprite = Achievements[4];
    }

    public void AbsoluteDedicationAchievement()
    {
        notifications.ShowNotification(5);
        if (AchievementsButtons[5].image.sprite == Achievements[5]) return;
        Achieved[5] = true;
        AchievementsButtons[5].image.sprite = Achievements[5];
    }

    public void ReadyForActionAchievement()
    {
        notifications.ShowNotification(6);
        if (AchievementsButtons[6].image.sprite == Achievements[6]) return;
        Achieved[6] = true;
        AchievementsButtons[6].image.sprite = Achievements[6];
    }

    public void ABrightFutureAchievement()
    {
        notifications.ShowNotification(7);
        if (AchievementsButtons[7].image.sprite == Achievements[7]) return;
        Achieved[7] = true;
        AchievementsButtons[7].image.sprite = Achievements[7];
    }
}
