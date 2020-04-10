using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;






public class MainMenu : MonoBehaviour
{
    private PlayMultipleSound sound;
    [SerializeField]
    public TYPE_AUDIO typeAudio;

    void Start()
    {
        sound = GetComponent<PlayMultipleSound>();
    }

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
        sound.PlaySound(typeAudio);
    }

    public void ControlButton()
    {
        panelMenu.SetActive(false);
        panelControl.SetActive(true);
        sound.PlaySound(typeAudio);
    }

    public void ExitButton()
    {
        Application.Quit();
        sound.PlaySound(typeAudio);
    }

    public void ControlToMenu()
    {
        panelMenu.SetActive(true);
        panelControl.SetActive(false);
        sound.PlaySound(typeAudio);
    }

}
