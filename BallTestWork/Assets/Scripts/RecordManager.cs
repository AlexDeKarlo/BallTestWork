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
        if (msg == null && PlayerPrefs.GetInt("MaxScore") != 0) RecordText.text = $"������  {PlayerPrefs.GetInt("MaxScore")} ������";
        else if (PlayerPrefs.GetInt("MaxScore") == 0 && (int)PlayerPrefs.GetFloat("Score") == 0) RecordText.text = $"�������� ���";
        else
        {
            StatsText.text = msg;
            if (msg != "�� ���������")
            {
                RecordText.text = $"���� �����: {(int)PlayerPrefs.GetFloat("Score")} ������";
                RecordText.text += $"\n������  {PlayerPrefs.GetInt("MaxScore")} ������";
            }
            PlayerPrefs.SetFloat("Score", 0);
        }

    }

}
