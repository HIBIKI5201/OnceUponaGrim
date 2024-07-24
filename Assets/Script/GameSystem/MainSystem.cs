using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSystem : MonoBehaviour
{
    string _playerName;
    int _level;
    int _maxHealth;

    void Start()
    {
        
    }

    public void DataSave()
    {
        // インスタンスを作る

        SaveData saveData = new SaveData(_playerName, _level, _maxHealth);

        // インスタンス変数を JSON にシリアル化する
        string json = JsonUtility.ToJson(saveData);

        // PlayerPrefs に保存する
        PlayerPrefs.SetString("SaveData", json);
    }

    public void Load()
    {
        // PlayerPrefs から文字列を取り出す
        string json = PlayerPrefs.GetString("SaveData");
        // デシリアライズする
        SaveData saveData = JsonUtility.FromJson<SaveData>(json);
        // 画面に表示する
        string status = "Name: " + saveData.Name + "\r\nLevel: " + saveData.Level
            + "\r\nHP: " + saveData.MaxHp;
        Debug.Log(status);
    }
}
