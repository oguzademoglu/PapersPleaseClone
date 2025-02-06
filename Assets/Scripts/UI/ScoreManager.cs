using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    public int score;

    public void UpdateScore(int amount)
    {
        score += amount;
        scoreText.text = $"Score:\n{score}";
    }
}
