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

    private void Start()
    {
        visiblePos = toastPanel.anchoredPosition;
        hiddenPos = visiblePos + new Vector2(0, 600); // Ajusta según tu layout
        toastPanel.anchoredPosition = hiddenPos;
        toastPanel.gameObject.SetActive(false);
    }

    public void ShowNotification(int i)
    {
        toastPanel.GetComponent<Image>().sprite = notificationSprites[i];
        StopAllCoroutines();
        StartCoroutine(ShowToastCoroutine());
    }

    private IEnumerator ShowToastCoroutine()
    {
        toastPanel.gameObject.SetActive(true);
        notificationSound.Play();

        // Slide In
        yield return StartCoroutine(Slide(toastPanel, hiddenPos, visiblePos, slideDuration));

        // Wait
        yield return new WaitForSeconds(visibleDuration);

        // Slide Out
        yield return StartCoroutine(Slide(toastPanel, visiblePos, hiddenPos, slideDuration));

        toastPanel.gameObject.SetActive(false);
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
