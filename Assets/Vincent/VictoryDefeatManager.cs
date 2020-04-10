using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryDefeatManager : MonoBehaviour
{

    public bool victory = false;
    public bool defeat = false;

    [SerializeField]
    private GameObject victoryHUD;
    [SerializeField]
    private GameObject defeatHUD;
    [SerializeField]
    private GameObject loadingHUD;

    // Update is called once per frame
    void Update()
    {
        victoryHUD.SetActive(victory);
        defeatHUD.SetActive(defeat);
    }

    public void ClickButtonReplay()
    {
        victory = false;
        defeat = false;
        loadingHUD.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ClickButtonExit()
    {
        Application.Quit();
    }

}
