using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    void Update()
    {
        if(Input.anyKey)
        {
            gv.core.gameManager.OnPressAnyButton();
        } 
    }
}
