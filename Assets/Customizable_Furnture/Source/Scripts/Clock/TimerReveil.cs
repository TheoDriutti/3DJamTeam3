using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerReveil : MonoBehaviour
{
    [HideInInspector]
    public Text time;
    [HideInInspector]
    public GameObject _timeRemainGameObject;
    int _actualDay = 0;


    [HideInInspector]
    public int _minutes;
    [HideInInspector]
    public int _seconds;
    [HideInInspector]
    public float _centiemes;
    [Range(1, 100)]
    [Header("Debug")]
    public int vitesseTimer = 1;
    [Header("Level Design")]
    [Range(0, 24)]
    public int begginingGame;
    [Range(0, 24)]
    public int timeOfOneDay;
    [Range(0, 24)]
    public int timeBegginingNight;
    [Range(0, 24)]
    public int timeEndingNight;
    [Range(0, 24)]
    public int _vitesseDuJeu;
    int _secondRemainNight;

    public static int _difficulty = 1;

    public GameObject _reveil;


    [HideInInspector]
    public GameObject _popupPasserNuit;
    [HideInInspector]
    public Slider _sliderTimer;
    private string[] zeroOrNot = new string[3];
    bool _isNight;

    void Start()    
    {
        _minutes = begginingGame;
        zeroOrNot[0] = "0";
        zeroOrNot[1] = "0";
        zeroOrNot[2] = "0";
    }

    void Update()
    {
        this.transform.position = _reveil.transform.position;
        //_centiemes += (Time.deltaTime * 100 * (vitesseTimer) * (timeOfOneDay / _vitesseDuJeu));
        if (_minutes == timeBegginingNight)
        {
        }
        if (_minutes == timeEndingNight)
        {
            IsDay();
        }

        if (_minutes == timeEndingNight - 1 && _seconds == 58)
        {
            _timeRemainGameObject.SetActive(true);
            _timeRemainGameObject.GetComponent<Text>().text = ("Tu n'as pas dormi, difficulté 5");
            _difficulty = 5;
            StartCoroutine(EteindreTimer());
        }

        
        else
        {
            _popupPasserNuit.SetActive(false);
        }

        if (_minutes == timeOfOneDay)
        {
            _minutes = 0;
            _seconds = 0;
            _centiemes = 0;
        }

        
        if (_centiemes > 99)
        {
            _centiemes = 0;
            _seconds++;
            if (_isNight)
            {
                _secondRemainNight--;
            }
            else
            {
                _secondRemainNight = 0;
            }
        }

        if (_centiemes < 10)
        {
            zeroOrNot[0] = "0";
        }
        else
        {
            zeroOrNot[0] = "";
        }

        if (_seconds > 59)
        {
            _seconds = 0;
            _minutes++;
        }

        if (_seconds < 10)
        {
            zeroOrNot[1] = "0";
        }
        else
        {
            zeroOrNot[1] = "";
        }

        if (_minutes < 10)
        {
            zeroOrNot[2] = "0";
        }
        else
        {
            zeroOrNot[2] = "";
        }

        time.text = (zeroOrNot[2] + _minutes.ToString("f0") + " : " + zeroOrNot[1] + _seconds.ToString("f0"));
        //time.text = (zeroOrNot[2] + _minutes.ToString("f0") + " : " + zeroOrNot[1] + _seconds.ToString("f0") + " : " + zeroOrNot[0] + _centiemes.ToString("f0"));
    }
    
    void IsDay()
    {
        if (_isNight)
        {
            _isNight = false;
        }
    }
    void PasserLaNuit()
    {
        _minutes = timeEndingNight;
        _seconds = 0;
        _centiemes = 0;
        _timeRemainGameObject.SetActive(true);
        _timeRemainGameObject.GetComponent<Text>().text = ("Tu as dormi " + _secondRemainNight + " minutes");
        if (_secondRemainNight > 480)
        {
            _timeRemainGameObject.GetComponent<Text>().text += (", difficulté 1");
            _difficulty = 1;
        }
        else if (_secondRemainNight > 360 && _secondRemainNight <= 480)
        {
            _timeRemainGameObject.GetComponent<Text>().text += (", difficulté 2");
            _difficulty = 2;
        }
        else if (_secondRemainNight > 240 && _secondRemainNight <= 360)
        {
            _timeRemainGameObject.GetComponent<Text>().text += (", difficulté 3");
            _difficulty = 3;
        }
        else if (_secondRemainNight > 120 && _secondRemainNight <= 240)
        {
            _timeRemainGameObject.GetComponent<Text>().text += (", difficulté 4");
            _difficulty = 4;
        }
        else
        {
            _timeRemainGameObject.GetComponent<Text>().text += (", difficulté 5");
            _difficulty = 5;
        }
        StartCoroutine(EteindreTimer());
    }

    IEnumerator EteindreTimer()
    {
        yield return new WaitForSeconds(2);
        _timeRemainGameObject.SetActive(false);
        _timeRemainGameObject.GetComponent<Text>().text = ("");

    }

    public void AddingTime()
    {
        _seconds += Mathf.RoundToInt(_sliderTimer.value);
    }
}
