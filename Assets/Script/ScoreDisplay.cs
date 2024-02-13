using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public Text ScoreText;
    [SerializeField] private GoalCounter primaryGoalCounter;
    [SerializeField] private GoalCounter secondaryGoalCounter;

    void Update()
    {
        if (primaryGoalCounter != null && secondaryGoalCounter != null)
        {
            ScoreText.text = "Score: " + (primaryGoalCounter.CurrentScore - secondaryGoalCounter.CurrentScore);
        }
    }
}