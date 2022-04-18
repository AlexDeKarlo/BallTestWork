using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordManager : MonoBehaviour
{
    [SerializeField]
    private Text StatsText;

    [SerializeField]
    private Text RecordText;

    public void Start()
    {
        string msg = GameManager.GetMessage();
        if (msg == null && PlayerPrefs.GetInt("MaxScore") != 0) RecordText.text = $"Рекорд  {PlayerPrefs.GetInt("MaxScore")} секунд";
        else if (PlayerPrefs.GetInt("MaxScore") == 0 && (int)PlayerPrefs.GetFloat("Score") == 0) RecordText.text = $"Рекордов нет";
        else
        {
            StatsText.text = msg;
            if (msg != "Вы проиграли")
            {
                RecordText.text = $"Твое время: {(int)PlayerPrefs.GetFloat("Score")} секунд";
                RecordText.text += $"\nРекорд  {PlayerPrefs.GetInt("MaxScore")} секунд";
            }
            PlayerPrefs.SetFloat("Score", 0);
        }

    }

}
