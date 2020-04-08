using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class Timer : MonoBehaviour
{
    Text time;
    public int _minutesAsk = 1;
    int _minutes;
    public int _secondsAsk = 0;
    int _seconds;
    float _centiemes;
    private string[] zeroOrNot = new string[3];

    public static bool _isCardVisible;
    public GameObject _cardManager;

    void Awake()
    {
        time = this.GetComponent<Text>();
        Assignation();
    }
    void Start()
    {
        zeroOrNot[0] = "0";
        zeroOrNot[1] = "0";
        zeroOrNot[2] = "0";
    }

    void Assignation()
    {
        _minutes = _minutesAsk;
        _seconds = _secondsAsk;
    }

    void Update()
    {
        if(!_isCardVisible)
            Chrono();
    }
    void Chrono()
    {
        _centiemes -= Time.deltaTime * 100;
        if (_centiemes < 0)
        {
            _centiemes = 99;
            _seconds--;
        }


        if (_centiemes < 10)
        {
            zeroOrNot[0] = "0";
        }
        else
        {
            zeroOrNot[0] = "";
        }

        if (_seconds < 0)
        {
            _seconds = 59;
            _minutes--;
        }

        if (_seconds > 59)
        {
            _seconds -= 60;
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

        if (_minutes == 0 && _seconds == 0)
        {
            Assignation();
            _isCardVisible = true;
            _cardManager.SetActive(true);
            FindObjectOfType<CardManagerGlobal>().AttributeCard01();
        }
    }

    public void EteindreLaCard()
    {
        _isCardVisible = false;
        FindObjectOfType<FlashLight>().IsLifeUpOrDown();
        _cardManager.SetActive(false);
        FindObjectOfType<WavesManager>().NewWave();
    }
}
