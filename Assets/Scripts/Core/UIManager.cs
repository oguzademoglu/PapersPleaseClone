using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameText, countryText, ageText, scoreText, timerText;
    [SerializeField] CustomerSpawner customerSpawner;

    public void UpdateDocumentUI()
    {
        nameText.text = customerSpawner.RandomName;
        countryText.text = customerSpawner.RandomCountry;
        ageText.text = $"{customerSpawner.RandomAge}";
        scoreText.text = "";
    }

    public void UpdateScoreText(string resultMessage)
    {
        scoreText.text = resultMessage;
    }
    public void UpdateTimerText(float timeRemaining)
    {
        timerText.text = $"Time:\n{timeRemaining}";// <--- This line is causing the error
    }
}
