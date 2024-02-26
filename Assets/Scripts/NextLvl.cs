using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLvl : MonoBehaviour
{
    [SerializeField] private Button nextBtn;
    [SerializeField] private Button restartBtn;

    private void Start()
    {
        nextBtn.onClick.AddListener(SendEventsBuffer);
        restartBtn.onClick.AddListener(Restart);
    }

    public void SendEventsBuffer()
    {
        int level = 1;

        if (PlayerPrefs.HasKey("level"))
            level = PlayerPrefs.GetInt("level");

        if (level < 11) level++;
        else level = 1;

        PlayerPrefs.SetInt("level", level);
        PlayerPrefs.Save();

        SceneManager.LoadScene(level - 1);

        if (level > 3)
            YG.YandexGame.FullscreenShow();
    }
    public void Restart()
    {
        int level = 1;
        if (PlayerPrefs.HasKey("level"))
            level = PlayerPrefs.GetInt("level");

        SceneManager.LoadScene(level);
        if (level > 1)
            YG.YandexGame.RewVideoShow(1);
    }

    private void OnDestroy()
    {
        nextBtn.onClick.RemoveListener(SendEventsBuffer);
        restartBtn.onClick.RemoveListener(Restart);
    }
}
