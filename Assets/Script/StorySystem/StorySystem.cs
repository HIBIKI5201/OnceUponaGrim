using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorySystem : MonoBehaviour
{
    Text textBox;

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
