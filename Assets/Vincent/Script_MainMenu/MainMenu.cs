using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PlayOneSound))]
public class MainMenu : MonoBehaviour
{
    public string nameSceneToPlay = "GameScene";

    [SerializeField]
    private GameObject panelControl;
    [SerializeField]
    private GameObject panelMenu;
    [SerializeField]
    private GameObject panelLoading;

    private PlayOneSound sound;

    void Start()
    {
        sound = GetComponent<PlayOneSound>();
    }

    public void PlayButton()
    {
        panelMenu.SetActive(false);
        panelLoading.SetActive(true);
        sound.PlaySound();
        SceneManager.LoadScene(nameSceneToPlay);
    }

    public void ControlButton()
    {
        panelMenu.SetActive(false);
        panelControl.SetActive(true);
        sound.PlaySound();
    }

    public void ExitButton()
    {
        sound.PlaySound();
        Application.Quit();
    }

    public void ControlToMenu()
    {
        panelMenu.SetActive(true);
        panelControl.SetActive(false);
        sound.PlaySound();
    }

}
