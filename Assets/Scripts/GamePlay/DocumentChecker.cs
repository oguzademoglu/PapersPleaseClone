using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class DocumentChecker : MonoBehaviour
{

    [SerializeField] DecisionHandler decisionHandler;
    [SerializeField] UIManager uiManager;
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] CustomerSpawner customerSpawner;

    // [SerializeField] TextMeshProUGUI nameText, countryText, ageText, scoreText, timerText;
    // [SerializeField] DocumentData documentData;
    // // [SerializeField] string correctCountry = "Turkiye";
    // public int score = 0;

    private float timeLimit = 5f;
    private float timeRemaining;
    private bool isTimerRunning = false;


    void Start()
    {
        GenerateNewDocument();
    }

    void GenerateNewDocument()
    {
        // string randomName = documentData.names[UnityEngine.Random.Range(0, documentData.names.Count)];
        // string randomCountry = documentData.countries[UnityEngine.Random.Range(0, documentData.countries.Count)];
        // int randomAge = UnityEngine.Random.Range(documentData.minAge, documentData.maxAge + 1);

        // nameText.text = randomName;
        // countryText.text = randomCountry;
        // ageText.text = $"{randomAge}";
        customerSpawner.GenerateNewDocument();
        uiManager.UpdateDocumentUI();

        StartTimer();
    }

    void StartTimer()
    {
        timeRemaining = timeLimit;
        isTimerRunning = true;
        StartCoroutine(TimerCountdown());
    }

    IEnumerator TimerCountdown()
    {
        while (timeRemaining > 0)
        {
            uiManager.UpdateTimerText(timeRemaining);
            yield return new WaitForSeconds(Time.deltaTime);
            timeRemaining -= Time.deltaTime;
        }
        isTimerRunning = false;
        // scoreText.text = "Süre doldu";
        scoreManager.UpdateScore(-1);
        uiManager.UpdateScoreText($"Süre doldu! {scoreManager.score}");
        GenerateNewDocument();
    }

    public void AcceptDocument()
    {
        if (!isTimerRunning) return;
        isTimerRunning = false;
        Debug.Log("Document accepted");
        string result = decisionHandler.ProcessDecision(customerSpawner.RandomCountry, true);
        uiManager.UpdateScoreText(result);
        // if (countryText.text.Contains(correctCountry))
        // {
        //     score++;
        //     scoreText.text = $"Doğru Karar: {score}";
        // }
        // else
        // {
        //     score--;
        //     scoreText.text = $"Yanlış Karar: {score}";
        // }
        GenerateNewDocument();
    }
    public void RejectDocument()
    {
        if (!isTimerRunning) return;
        isTimerRunning = false;
        Debug.Log("Document rejected");
        string result = decisionHandler.ProcessDecision(customerSpawner.RandomCountry, false);
        uiManager.UpdateScoreText(result);
        // if (!countryText.text.Contains(correctCountry))
        // {
        //     score++;
        //     scoreText.text = $"Doğru Karar: {score}";
        // }
        // else
        // {
        //     score--;
        //     scoreText.text = $"Yanlış Karar: {score}";
        // }
        GenerateNewDocument();
    }
}
