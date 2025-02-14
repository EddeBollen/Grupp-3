using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayNightCycle : MonoBehaviour
{
    public SleepSystem sleepSystem;
    public Image blackScreen;
    public float fadeDuration = 2f;
    public float targetFade = 0.75f;
    public float timeBeforeFadeBack = 60f; 
    public bool isNight = false;

    void Start()
    {
        isNight = blackScreen.color.a >= targetFade;
        sleepSystem = FindObjectOfType<SleepSystem>();
        blackScreen.color = new Color(0, 0, 0, 0);
        StartCoroutine(FadeSequence());
    }

    public void SetDayTime()
    {
        isNight = false;
        StartCoroutine(FadeToClear());
    }

    void Update()
    {
        if (blackScreen.color.a >= targetFade)
        {
            isNight = true;
        }
        else
        {
            isNight = false;
        }

        if (isNight)
        {
            Night();
        }
        else
        {
            Day();
        }
    }

    public IEnumerator FadeSequence()
    {
        while (true)
        {
            yield return FadeToBlack(120f);
            yield return new WaitForSeconds(timeBeforeFadeBack);
            yield return FadeToClear();
        }
    }

    IEnumerator FadeToBlack(float delay)
    {
        yield return new WaitForSeconds(delay);
        float elapsedTime = 0f;
        Color startColor = blackScreen.color;
        Color targetColor = new Color(0, 0, 0, targetFade);

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            blackScreen.color = Color.Lerp(startColor, targetColor, elapsedTime / fadeDuration);
            yield return null;
        }
    }

    IEnumerator FadeToClear()
    {
        float elapsedTime = 0f;
        Color startColor = blackScreen.color;
        Color targetColor = new Color(0, 0, 0, 0);

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            blackScreen.color = Color.Lerp(startColor, targetColor, elapsedTime / fadeDuration);
            yield return null;
        }
    }

    void Night()
    {
        Debug.Log("Nu är det nog dags att sova");
    }

    void Day()
    {
        Debug.Log("Nu är nog dags att vakna");
    }
}