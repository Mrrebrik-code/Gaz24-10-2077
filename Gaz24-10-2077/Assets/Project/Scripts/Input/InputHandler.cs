using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Zenject;

public class InputHandler : MonoBehaviour
{
    public Settings _inputSettings;
    public InputState _inputState;

    private void Update()
    {
        if (_inputState.isDownMove || _inputState.isUpMove || _inputState.isLeftMove || _inputState.isRightMove )
        {
            _inputState.isInputState = true;
        }
        else
        {
            _inputState.isInputState = false;
        }
        _inputState.isUpMove = Input.GetKey(_inputSettings.keyboard_UP) || Input.GetKey(_inputSettings.arrowKeyboard_UP);

        _inputState.isDownMove = Input.GetKey(_inputSettings.keyboard_DOWN) || Input.GetKey(_inputSettings.arrowKeyboard_DOWN);

        _inputState.isLeftMove = Input.GetKey(_inputSettings.keyboard_LEFT) || Input.GetKeyDown(_inputSettings.arrowKeyboard_LEFT);

        _inputState.isRightMove = Input.GetKey(_inputSettings.keyboard_RIGHT) || Input.GetKey(_inputSettings.arrowKeyboard_RIGHT);

        _inputState.isHandBrake = Input.GetKey(_inputSettings.handBrake);
    }

    [Serializable]
    public class Settings
    {
        [Header("keyboard - button")]
        public KeyCode keyboard_UP;
        public KeyCode keyboard_DOWN;
        public KeyCode keyboard_LEFT;
        public KeyCode keyboard_RIGHT;
        [Space]
        [Header("ArrowKeyboard")]
        public KeyCode arrowKeyboard_UP;
        public KeyCode arrowKeyboard_DOWN;
        public KeyCode arrowKeyboard_LEFT;
        public KeyCode arrowKeyboard_RIGHT;
        [Space]
        [Header("Game functional")]
        public KeyCode handBrake;
    }

}

