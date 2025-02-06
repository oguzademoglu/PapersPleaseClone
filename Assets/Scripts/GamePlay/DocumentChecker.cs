using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class DocumentChecker : MonoBehaviour
{

    [Header("Helpers")]
    [SerializeField] DecisionHandler decisionHandler;
    [SerializeField] UIManager uiManager;
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] CustomerSpawner customerSpawner;

    private readonly float timeLimit = 10f;
    private float timeRemaining;
    private bool isTimerRunning = false;


    void Start()
    {
        GenerateNewDocument();
    }

    void GenerateNewDocument()
    {
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
        GenerateNewDocument();
    }
    public void RejectDocument()
    {
        if (!isTimerRunning) return;
        isTimerRunning = false;
        Debug.Log("Document rejected");
        string result = decisionHandler.ProcessDecision(customerSpawner.RandomCountry, false);
        uiManager.UpdateScoreText(result);
        GenerateNewDocument();
    }
}
