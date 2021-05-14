using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartPlayer : MonoBehaviour
{
    [SerializeField] GameObject _Player;
    [SerializeField] GameObject Portal;
    [SerializeField] Text[] ScoreText;
     int score;
    float interval;

    private void Start()
    {
        Player._score = false;
        Player.timescore = false;
        ScoreText[0].text = Mathf.Round(PlayerPrefs.GetFloat("scoreText")).ToString();
        ScoreText[1].text = Mathf.Round(PlayerPrefs.GetFloat("scoreText")).ToString();
    }
    void Update()
    {
        PlayerStart(.5f);
        if (Player._score && Player.timescore)
        {
            PlayerPrefs.SetFloat("scoreText", PlayerPrefs.GetFloat("scoreText") + score+.4f);
           ScoreText[0].text = Mathf.Round(PlayerPrefs.GetFloat("scoreText")).ToString();
           ScoreText[1].text = Mathf.Round(PlayerPrefs.GetFloat("scoreText")).ToString();
        }

    }

    void PlayerStart(float counter, bool counterStop = false) 
    {
        if (!counterStop)
        {
            interval += Time.deltaTime;
            if (interval >= counter)
            {
                _Player.SetActive(true);
                Portal.SetActive(true);
                counterStop = true;
                interval = 0;
            }
        } 
    }
}
