using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.VFX;

public class HomeUISystem : MonoBehaviour
{
    VisualElement _ui;

    Button _startButton;
    Button _endButton;
    Button _ContinueButton;
    void Start()
    {
        _ui = GetComponent<UIDocument>().rootVisualElement;

        _startButton = _ui.Q<Button>("Start");
        _startButton.clicked += OnPlayButtonClicked;

        _endButton = _ui.Q<Button>("End");
        _ContinueButton = _ui.Q<Button>("Continue");
    }

    void OnPlayButtonClicked()
    {
        Debug.Log("testkun");
    }
}
