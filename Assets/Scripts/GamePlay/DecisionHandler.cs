using UnityEngine;

public class DecisionHandler : MonoBehaviour
{
    [SerializeField] string correctCountry;
    [SerializeField] ScoreManager scoreManager;


    public string ProcessDecision(string country, bool isAccepted)
    {
        if (isAccepted && country == correctCountry)
        {
            scoreManager.UpdateScore(1);
            return $"Correct! {scoreManager.score}";
        }
        else if (!isAccepted && country != correctCountry)
        {
            scoreManager.UpdateScore(1);
            return $"Correct! {scoreManager.score}";
        }
        else
        {
            scoreManager.UpdateScore(-1);
            return $"Incorrect! {scoreManager.score}";
        }
    }

}
