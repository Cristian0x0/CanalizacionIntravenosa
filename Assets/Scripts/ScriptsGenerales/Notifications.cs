using System.Collections;
using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.UI;

public class Notifications : MonoBehaviour
{
    [SerializeField] private RectTransform toastPanel;
    [SerializeField] private AudioSource notificationSound;
    [SerializeField] private List<Sprite> notificationSprites;

    [SerializeField] private float slideDuration = 0.5f;
    [SerializeField] private float visibleDuration = 2f;
    private Vector2 hiddenPos;
    private Vector2 visiblePos;

    private Queue<int> notificationQueue = new Queue<int>();
    private bool isShowing = false;

    private void Start()
    {
        visiblePos = toastPanel.anchoredPosition;
        hiddenPos = visiblePos + new Vector2(0, 600); // Ajusta según tu layout
        toastPanel.anchoredPosition = hiddenPos;
        toastPanel.gameObject.SetActive(false);
    }

    public void ShowNotification(int i)
    {
        notificationQueue.Enqueue(i);
        if (!isShowing)
        {
            StartCoroutine(ProcessNotifications());
        }
    }

    private IEnumerator ProcessNotifications()
    {
        isShowing = true;

        while (notificationQueue.Count > 0)
        {
            int i = notificationQueue.Dequeue();
            toastPanel.GetComponent<Image>().sprite = notificationSprites[i];
            toastPanel.gameObject.SetActive(true);
            notificationSound.Play();

            yield return Slide(toastPanel, hiddenPos, visiblePos, slideDuration);

            yield return new WaitForSeconds(visibleDuration);

            yield return Slide(toastPanel, visiblePos, hiddenPos, slideDuration);

            toastPanel.gameObject.SetActive(false);
        }

        isShowing = false;
    }

    private IEnumerator Slide(RectTransform panel, Vector2 from, Vector2 to, float duration)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            float t = elapsed / duration;
            panel.anchoredPosition = Vector2.Lerp(from, to, t);
            elapsed += Time.deltaTime;
            yield return null;
        }
        panel.anchoredPosition = to;
    }
}
