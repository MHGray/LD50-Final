using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] PlayerMove player;
    [SerializeField] MouseLook mouseLook;
    [SerializeField] GameObject menu;


    private bool optionsEnabled = false;

    public void Update()
    {
        //Check for Escape being pressed
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            //Toggle Options Menu, Turn Off player Movement
            if (optionsEnabled)
            {
                optionsEnabled = !optionsEnabled;
                disableOptions();
            }
            else
            {
                optionsEnabled = !optionsEnabled;
                enableOptions();
            }
        }
    }

    private void enableOptions()
    {
        Cursor.lockState = CursorLockMode.Confined;
        //Stop Player from moving
        player.enabled = false;
        mouseLook.enabled = false;
        //Bring up Menu
        menu.SetActive(true);
    }

    private void disableOptions()
    {
        Cursor.lockState = CursorLockMode.Locked;

        player.enabled = true;
        mouseLook.enabled = true;
        menu.SetActive(false);
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
