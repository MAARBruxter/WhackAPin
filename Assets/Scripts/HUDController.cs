using TMPro;
using UnityEngine;

public class HUDController : MonoBehaviour
{
    [Tooltip("Text element displaying the level time.")]
    [SerializeField] private TextMeshProUGUI timeText;
    [Tooltip("Text element displaying the score.")]
    [SerializeField] private TextMeshProUGUI textScore;


    private void Update()
    {
        int seconds = (int)LevelManager.Instance.LevelTime % 60;

        int minutes = (int)LevelManager.Instance.LevelTime / 60;

        timeText.text = minutes.ToString("00") + ":" + seconds.ToString("00");

        if (minutes <= 0 && seconds <= 10)
        {
            timeText.color = Color.red;
        }
        else
        {
            timeText.color = Color.white;
        }

        textScore.text = GameManager.Instance.Score.ToString();


    }
}
