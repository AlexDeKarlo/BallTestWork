using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int MaxRecord = 0;
    [SerializeField]
    private float Record = 0;

    private static string Message;
    /// <summary>
    /// Получение сообщения о результате игры
    /// </summary>
    /// <returns>string</returns>
    public static string GetMessage()
    {
        string msg = Message;
        Message = null;
        return msg;
    }

    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private Vector3 SpawnPoint;
    private void Start()
    {
        MaxRecord = PlayerPrefs.GetInt("MaxScore");
        Record = 0;
        GameObject pl =Instantiate(Player, SpawnPoint, Quaternion.identity);
        pl.GetComponent<PlayerController>().onFinish += NewRecord;
        pl.GetComponent<PlayerController>().onDestroy += DestroyPlayer;
    }
    private void Update()
    {
        Record += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.R)) // Сброс настроек
        {
            GetComponent<MenuManager>().LoadLevel("Menu");
            MaxRecord = 0;
            Record = 0;
            PlayerPrefs.SetFloat("Score", Record);
            PlayerPrefs.SetInt("MaxScore", MaxRecord);
        }
    }
    private void NewRecord()
    {
        if (MaxRecord == 0 || Record < MaxRecord) 
        {
            Message = "Новый рекорд";
            MaxRecord = (int)Record;
            PlayerPrefs.SetInt("MaxScore", MaxRecord);
        }
        PlayerPrefs.SetFloat("Score", Record);
        Message = "Вы выиграли";
        GetComponent<MenuManager>().LoadLevel("Records");

    }
    private void DestroyPlayer()
    {
        PlayerPrefs.SetFloat("Score", Record);
        Message = "Вы проиграли";
        GetComponent<MenuManager>().LoadLevel("Records");
    }
}
