using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string nameSceneToPlay = "GameScene";

    [SerializeField]
    private GameObject panelControl;
    [SerializeField]
    private GameObject panelMenu;
    [SerializeField]
    private GameObject panelLoading;

    public void PlayButton()
    {
        panelMenu.SetActive(false);
        panelLoading.SetActive(true);
        SceneManager.LoadScene(nameSceneToPlay);
    }

    public void ControlButton()
    {
        panelMenu.SetActive(false);
        panelControl.SetActive(true);
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void ControlToMenu()
    {
        panelMenu.SetActive(true);
        panelControl.SetActive(false);
    }

}
