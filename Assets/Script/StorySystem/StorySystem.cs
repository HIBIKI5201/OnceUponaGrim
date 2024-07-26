using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorySystem : MonoBehaviour
{
    [SerializeField]
    Text textBox;

    [Header("オブジェクト")]
    [SerializeField]
    GameObject player;

    [SerializeField]
    GameObject grim;

    [SerializeField]
    GameObject palpal;

    [SerializeField]
    GameObject otherOne;
    [SerializeField]
    string otherOneName;
    static string OtherOneName;


    [SerializeField]
    GameObject otherTwo;
    [SerializeField]
    string otherTwoName;
    static string OtherTwoName;

    enum Character
    {
        player,
        grim,
        palpal,
        otherOne,
        otherTwo,
    }

    [SerializeField]
    List<Character> SayChara;

    Dictionary<Character, string> CharacterNames = new()
    { 
        {Character.player, MainSystem._playerName },
        {Character.grim, "グリム" },
        {Character.palpal, "パルパル" },
        {Character.otherOne, OtherOneName },
        {Character.otherTwo, OtherTwoName },
    };

    [SerializeField]
    List<string> text;

    int textNumber;

    public void NextText()
    {
        if (int.TryParse(text[textNumber], out int intValue))
        {
            switch (intValue)
            {
                case 1:
                    Debug.Log("一番");
                    break;
            }
        }
        else
        {
            Debug.Log(CharacterNames[SayChara[textNumber]] + text[textNumber]);
            //textBox.text = text[textNumber];
        }


        textNumber++;
    }
}
