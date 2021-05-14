using UnityEngine;
using UnityEngine.UI;

public class Score_color : MonoBehaviour
{
    [SerializeField] Text ScoreText;
    int score;
    private void Update()
    {
        if (Player._score)
        {
            ScoreText.enabled = true;
            PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score" ) + 10);
            PlayerPrefs.Save();
            if (PlayerPrefs.GetInt("score") > score)
            {
                score++;
            }
            ScoreText.text = score.ToString();
        }
    }
}
