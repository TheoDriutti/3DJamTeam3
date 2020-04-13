using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FlashLight : MonoBehaviour
{
     public GameObject _icone01, _icone02, _icone03, _icone04;
    public SphereCaster _sphereCaster;
    bool _isOn = true;
    public int _actualMod = -1;
     public EnumDifferentesLight._differentsMods _differentsMods;
    [Header("Reload")]
    [Range(0, 5)]
    public float _reloadPerSecond;
    public float _waitBeforeReloadSecond = 2;
     public float _damage;
    [Range(0, 100)]
    public float _lifeStart = 100;
    float _life, _consommation;
     public Light _pointLight;
     public Text _pourcentageBatterie;

    [Header("ModeTorch")]
    public NombdeDeMods[] _nombreDeModsDeLamp;

    [Header("ClignotementValues")]
    public int _timeOnClignotement;
    public int _timeOffClignotement;


    [HideInInspector] public float _effectMultiplicateurDureeDeVieTorch = 1;
    [HideInInspector] public float _effectMultiplicateurDistanceRayonLumiere = 1;
    [HideInInspector] public float _effectCapacityMax = 1;
    [HideInInspector] public bool _effectIsProjecteurCollected;
    [HideInInspector] public float _effectMultiplicateurRechargeBatterie = 1;

    string sceneName;


    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        _lifeStart *= _effectCapacityMax;
        _life = _lifeStart;
        ChangingMode();
        StartCoroutine(LifeDown());
        if(sceneName=="MainMenu")
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

        }
    }

    void Update()
    {
        if (_pointLight.intensity == 0)
        {
            _sphereCaster.enabled = false;
        }
        else
        {
            _sphereCaster.enabled = true;
        }

        if (!ClockTimer._isCardVisible && sceneName != "MainMenu")
        {
            if (_life > Mathf.RoundToInt(100 * _effectCapacityMax))
                _life = Mathf.RoundToInt(100 * _effectCapacityMax);
            else if (_life < 0)
                _life = 0;

            if (Input.GetMouseButtonDown(0))
            {
                SwitchOnOff();
            }
            if (Input.GetMouseButtonDown(1))
            {
                ChangingMode();
            }

        }

        foreach (GameObject obj in _sphereCaster._enemyTouched)
        {
            if (obj != null && obj.tag == "Enemy")
            {
                EnnemiManager enMa = obj.GetComponent<EnnemiManager>();
                string typeLampeToKill = enMa.lampeToKill.ToString();
                Debug.Log(typeLampeToKill == _differentsMods.ToString());
                if (typeLampeToKill == "_classique" || typeLampeToKill == _differentsMods.ToString())
                {
                    Debug.Log(typeLampeToKill + "  " + enMa.secondesHP);
                    enMa.secondesHP -= Time.deltaTime * _nombreDeModsDeLamp[_actualMod]._modDamage;
                }
            }
        }

    }
    void SwitchOnOff()
    {
        if (_isOn)
        {
            _isOn = false;
            _pointLight.enabled = false;
            StopCoroutine(LifeDown());
            StopCoroutine(Clignotement());
            StartCoroutine(WaitToReload());
        }
        else
        {
            if (_life > 0)
            {
                _isOn = true;
                _pointLight.enabled = true;
                StopCoroutine(LifeUp());
                StopCoroutine(WaitToReload());
                StartCoroutine(LifeDown());
            }
        }

        _icone01.GetComponent<ActualIcone>().ChangingIcone();
        _icone02.GetComponent<ActualIcone>().ChangingIcone();
        _icone03.GetComponent<ActualIcone>().ChangingIcone();
        _icone04.GetComponent<ActualIcone>().ChangingIcone();
    }
    void ChangingMode()
    {
        StopCoroutine(Clignotement());
        if (_actualMod != _nombreDeModsDeLamp.Length - 1)
            _actualMod++;
        else
            _actualMod = 0;

        _pointLight.intensity = _nombreDeModsDeLamp[_actualMod]._modIntensity;
        _pointLight.spotAngle = _nombreDeModsDeLamp[_actualMod]._modRadius;
        _pointLight.range = _nombreDeModsDeLamp[_actualMod]._modDistance * _effectMultiplicateurDistanceRayonLumiere;
        _pointLight.color = _nombreDeModsDeLamp[_actualMod]._color;
        _damage = _nombreDeModsDeLamp[_actualMod]._modDamage;
        float _tailleCone = _pointLight.spotAngle / 4;
        _consommation = _nombreDeModsDeLamp[_actualMod]._consomationPerSeconds;

        _differentsMods = _nombreDeModsDeLamp[_actualMod]._differentsMods;

        if (_differentsMods.ToString() == "_clignotante")
        {
            StartCoroutine(Clignotement());
        }
        else
        {
            StopCoroutine(Clignotement());
            _pointLight.intensity = _nombreDeModsDeLamp[_actualMod]._modIntensity;
        }

        _sphereCaster._sphereRadius = (_pointLight.spotAngle / 5);
        _sphereCaster._maxDistance = (_pointLight.range);

        _icone01.GetComponent<ActualIcone>().ChangingIcone();
        _icone02.GetComponent<ActualIcone>().ChangingIcone();
        _icone03.GetComponent<ActualIcone>().ChangingIcone();
        _icone04.GetComponent<ActualIcone>().ChangingIcone();

    }

    public void IsLifeUpOrDown()
    {
        if (_isOn)
            StartCoroutine(LifeDown());
        else
            StartCoroutine(LifeUp());
    }

    IEnumerator LifeDown()
    {
        if (_isOn)
        {
            yield return new WaitForSeconds(1 / _consommation * _effectMultiplicateurDureeDeVieTorch);
            _life--;
            _pourcentageBatterie.text = _life + " %";
            if (_life > 0 && !ClockTimer._isCardVisible)
                StartCoroutine(LifeDown());
            else
                SwitchOnOff();
        }
    }
    IEnumerator WaitToReload()
    {
        yield return new WaitForSeconds(_waitBeforeReloadSecond);
        if (!_isOn)
            StartCoroutine(LifeUp());
    }
    IEnumerator LifeUp()
    {
        if (!_isOn)
        {
            yield return new WaitForSeconds(1 / _reloadPerSecond / _effectMultiplicateurRechargeBatterie);
            _life++;
            _pourcentageBatterie.text = _life + " %";
            if (_life < 100 && !ClockTimer._isCardVisible)
                StartCoroutine(LifeUp());
        }
    }
    IEnumerator Clignotement()
    {
        if (_isOn && !ClockTimer._isCardVisible)
        {
            yield return new WaitForSeconds(_timeOnClignotement);
            if (_differentsMods.ToString() == "_clignotante" && _isOn)
                _pointLight.intensity = 0;
            yield return new WaitForSeconds(_timeOffClignotement);
            _pointLight.intensity = _nombreDeModsDeLamp[_actualMod]._modIntensity;

            if (_differentsMods.ToString() == "_clignotante" && _isOn)
            {
                StartCoroutine(Clignotement());
            }
        }

    }
}
