using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashLight : MonoBehaviour
{
    [HideInInspector] public GameObject _icone01, _icone02, _icone03, _icone04;
    public SphereCaster _sphereCaster;
    bool _isOn = true;
    int _actualMod = -1;
    [HideInInspector] public EnumDifferentesLight._differentsMods _differentsMods;
    [Header("Reload")]
    [Range(0, 2)]
    public float _reloadPerSecond;
    public float _waitBeforeReloadSecond = 2;
    [HideInInspector] public int _damage;
    [Range(0, 100)]
    public float _lifeStart = 100;
    float _life, _consommation;
    [HideInInspector] public Light _pointLight;
    [HideInInspector] public Text _pourcentageBatterie;

    [Header("ModeTorch")]
    public NombdeDeMods[] _nombreDeModsDeLamp;

    [Header("ClignotementValues")]
    public int _timeOnClignotement;
    public int _timeOffClignotement;


    [HideInInspector] public float _effectMultiplicateurDureeDeVieTorch= 1;
    [HideInInspector] public float _effectMultiplicateurDistanceRayonLumiere = 1;
    [HideInInspector] public float _effectCapacityMax = 1;
    [HideInInspector] public bool _effectIsProjecteurCollected;
    [HideInInspector] public float _effectMultiplicateurRechargeBatterie = 1;



    void Start()
    {
        _lifeStart *= _effectCapacityMax;
        _life = _lifeStart;
        ChangingMode();
        StartCoroutine(LifeDown());
    }

    void Update()
    {
        if (_life > Mathf.RoundToInt(100* _effectCapacityMax))
            _life = Mathf.RoundToInt(100 * _effectCapacityMax);
        else if (_life < 0)
            _life = 0;

        if (Input.GetMouseButtonDown(0))
        {
            SwitchOnOff();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangingMode();
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
<<<<<<< HEAD:Assets/Paul/Assets/Flashlight/FlashLight.cs
        float _tailleCone = _pointLight.spotAngle / 4;
        _consommation = _nombreDeModsDeLamp[_actualMod]._consomationPerSeconds;

=======
        _consommation = _nombreDeModsDeLamp[_actualMod]._consomationPerSeconds;
        
>>>>>>> adab2310302fd5f9765c03f9d439925d2b7a3431:Assets/Paul/Flashlight/FlashLight.cs
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
        _sphereCaster._sphereRadius = (_pointLight.range);

        _icone01.GetComponent<ActualIcone>().ChangingIcone();
        _icone02.GetComponent<ActualIcone>().ChangingIcone();
        _icone03.GetComponent<ActualIcone>().ChangingIcone();
        _icone04.GetComponent<ActualIcone>().ChangingIcone();

    }

    IEnumerator LifeDown()
    {
        if (_isOn)
        {
            yield return new WaitForSeconds(1 / _consommation  *_effectMultiplicateurDureeDeVieTorch);
            _life--;
            _pourcentageBatterie.text = _life + " %";
            if (_life > 0)
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
            if (_life < 100)
                StartCoroutine(LifeUp());
        }
    }
    IEnumerator Clignotement()
    {

        yield return new WaitForSeconds(_timeOnClignotement);
        if(_differentsMods.ToString() == "_clignotante" && _isOn)
            _pointLight.intensity = 0;
        yield return new WaitForSeconds(_timeOffClignotement);
        _pointLight.intensity = _nombreDeModsDeLamp[_actualMod]._modIntensity;
        if (_differentsMods.ToString() == "_clignotante" && _isOn)
        {
            Debug.Log(_differentsMods.ToString());
            StartCoroutine(Clignotement());
        }
        
    }
}
