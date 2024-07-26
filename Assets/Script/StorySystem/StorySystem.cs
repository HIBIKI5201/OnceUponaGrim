using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorySystem : MonoBehaviour
{
    [SerializeField]
    Text textBox;

    enum Character
    {
        player,
        grim,
        palpal,
        other
    }

    [SerializeField]
    List<Character> activeChara;

    Dictionary<Character, string> CharacterNames = new() 
    { {Character.player, MainSystem._playerName },
        {Character.grim, "ƒOƒŠƒ€" }
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
                    Debug.Log("ˆê”Ô");
                    break;
            }
        }
        else
        {
            Debug.Log(text[textNumber]);
            //textBox.text = text[textNumber];
        }


        textNumber++;
    }
}
