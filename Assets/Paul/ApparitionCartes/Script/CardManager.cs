using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class CardManager : MonoBehaviour
{
    [HideInInspector] public Text _titreText, _descriptionText;

    [HideInInspector] public ScriptableEffect _scriptableEffect;

    [HideInInspector] public bool _goUp;
    [HideInInspector] public bool _goDown;
    int _speed;

    [HideInInspector] public GameObject _otherCard01, _otherCard02;

    string _numberCard;

    EnumEffect._enumEffect _enumEffect;

    void Start()
    {
        _numberCard = (Regex.Replace(this.name, "[^0-9]", ""));
        _speed = FindObjectOfType<CardManagerGlobal>()._speedReveals;
    }
    public void AttribuerEffect()
    {
        _titreText.text = _scriptableEffect._effectTitle;
        _descriptionText.text = _scriptableEffect._effectDescription;
    }

    void Update()
    {
        if (_goUp)
            GoUp();
        if (_goDown)
            GoDown();
    }

    public void GoUp()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + _speed);
        if (transform.position.y >= 540)
        {
            _goUp = false;
        }
    }
    public void GoDown()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - _speed);
        if (transform.position.y <= -540)
        {
            _goDown = false;
        }
    }

    public void SelectionnerUneCarte()
    {
        if (FindObjectOfType<CardManagerGlobal>()._cardSelected == "")
        {
            FindObjectOfType<CardManagerGlobal>()._cardSelected = _numberCard;

            if (FindObjectOfType<CardManagerGlobal>()._cardSelected == _numberCard)
            {
                StartCoroutine(ThisCardSelected());
                _otherCard01.GetComponent<CardManager>()._goDown = true;
                _otherCard02.GetComponent<CardManager>()._goDown = true;
            }
        }
    }

    IEnumerator ThisCardSelected()
    {
        _enumEffect = _scriptableEffect._EnumEffect;
        AffectedEffect();
        yield return new WaitForSeconds(FindObjectOfType<CardManagerGlobal>()._timeCardSelected);
        _goDown = true;
        yield return new WaitForSeconds(FindObjectOfType<CardManagerGlobal>()._timeCardSelected);
        FindObjectOfType<CardManagerGlobal>()._cardSelected = "";
        FindObjectOfType<ClockTimer>().EteindreLaCard();
    }

    void AffectedEffect()
    {
        if(_enumEffect.ToString() == "AugmentationDureeDeVieTorche")
        {
            FindObjectOfType<FlashLight>()._effectMultiplicateurDureeDeVieTorch *= FindObjectOfType<EffectManager>()._multiplicateurDureeVieTorche;
        }
        else if (_enumEffect.ToString() == "AugmentationDistanceRayonDeLumiere")
        {
            FindObjectOfType<FlashLight>()._effectMultiplicateurDistanceRayonLumiere *= FindObjectOfType<EffectManager>()._multiplicateurDistanceRayonLumiere;
        }
        else if (_enumEffect.ToString() == "CapacityBatteryMax")
        {
            FindObjectOfType<FlashLight>()._effectCapacityMax *= FindObjectOfType<EffectManager>()._capacityMax;
        }
        else if (_enumEffect.ToString() == "TempsRechargementPiege")
        {

        }
        else if (_enumEffect.ToString() == "RalentissementMob")
        { 

        }
        else if (_enumEffect.ToString() == "DiminutionFolie")
        {

        }
        else if (_enumEffect.ToString() == "Projecteur")
        {
            FindObjectOfType<FlashLight>()._effectIsProjecteurCollected =true;
        }
        else if (_enumEffect.ToString() == "AugmentationDureePieges")
        {

        }
        else if (_enumEffect.ToString() == "AugmentationZonePieges")
        {

        }
        else if (_enumEffect.ToString() == "RechargePlusRapide")
        {

            FindObjectOfType<FlashLight>()._effectMultiplicateurRechargeBatterie *= FindObjectOfType<EffectManager>()._multiplicateurRechargeBatterie;
        }
        else if (_enumEffect.ToString() == "ChangementCouleurDeLaLampe")
        {

        }
    }
}
