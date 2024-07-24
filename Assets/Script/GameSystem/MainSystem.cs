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
        // �C���X�^���X�����

        SaveData saveData = new SaveData(_playerName, _level, _maxHealth);

        // �C���X�^���X�ϐ��� JSON �ɃV���A��������
        string json = JsonUtility.ToJson(saveData);

        // PlayerPrefs �ɕۑ�����
        PlayerPrefs.SetString("SaveData", json);
    }

    public void Load()
    {
        // PlayerPrefs ���當��������o��
        string json = PlayerPrefs.GetString("SaveData");
        // �f�V���A���C�Y����
        SaveData saveData = JsonUtility.FromJson<SaveData>(json);
        // ��ʂɕ\������
        string status = "Name: " + saveData.Name + "\r\nLevel: " + saveData.Level
            + "\r\nHP: " + saveData.MaxHp;
        Debug.Log(status);
    }
}
