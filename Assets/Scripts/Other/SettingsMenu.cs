using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    public GameObject settingsMenuUI;
    public InputListener inputListener;
    public bool isMenuActive = false;
    public TMP_InputField sensXtext;
    public TMP_InputField sensYtext;

    void Start() {
        sensXtext.text = inputListener.sensHorizontal.ToString();
        sensYtext.text = inputListener.sensVertical.ToString();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isMenuActive)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        float.TryParse(sensXtext.text, out inputListener.sensHorizontal);
        float.TryParse(sensYtext.text, out inputListener.sensVertical);
        settingsMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isMenuActive = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Pause()
    {
        settingsMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isMenuActive = true;
        Cursor.lockState = CursorLockMode.None;
    }
}