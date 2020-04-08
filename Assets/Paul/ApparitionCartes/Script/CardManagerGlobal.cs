using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManagerGlobal : MonoBehaviour
{

    [HideInInspector] public string _cardSelected;
    [Header("Déposez vos scriptables objects là(augmentez la size)")]
    public List<ScriptableEffect> _scriptableEffects;
    [HideInInspector] public List<CardAlreadyUsed> _cardAlreadyUsed;

    CardManager _card01, _card02, _card03;
    int _tirage01, _tirage02, _tirage03;
    [Header("Apparition des cartes")]
    public int _speedReveals;
    [Range(0f,1f)]
    public float _timeToWaitBeforeNewCardAppears;
    public float _timeCardSelected;

    void Start()
    {
        _card01 = GameObject.Find("Card01").GetComponent<CardManager>();
        _card02 = GameObject.Find("Card02").GetComponent<CardManager>();
        _card03 = GameObject.Find("Card03").GetComponent<CardManager>();

        for (int i= 0; i<_scriptableEffects.Count; i++)
        {
            _cardAlreadyUsed.Add(new CardAlreadyUsed(_scriptableEffects[i]._effectTitle, _scriptableEffects[i]._numberOfReusing, _scriptableEffects[i]._isInfinite));
        }
    }

    public void AttributeCard01()
    {
        if (_cardAlreadyUsed.Count > 0)
        {
            _tirage01 = Random.Range(0, _cardAlreadyUsed.Count);

            _card01._scriptableEffect = _scriptableEffects[_tirage01];
            _card01.AttribuerEffect();
            _card01._goUp = true;

            //Si la carte est infinie
            if (!_cardAlreadyUsed[_tirage01]._isInfinite)
            {
                _cardAlreadyUsed[_tirage01]._numberOfUsing--;
            }
            //Retirer la carte si elle atteint 0
            if (_cardAlreadyUsed[_tirage01]._numberOfUsing <= 0)
            {
                _cardAlreadyUsed.Remove(_cardAlreadyUsed[_tirage01]);
            }
            StartCoroutine(AttributeCard02());
        }
        
    }
    IEnumerator AttributeCard02()
    {
        if (_cardAlreadyUsed.Count > 0)
        {
            _tirage02 = Random.Range(0, _cardAlreadyUsed.Count);
            if (_tirage02 == _tirage01)
            {
                StartCoroutine(AttributeCard02());
            }
            else
            {
                yield return new WaitForSeconds(_timeToWaitBeforeNewCardAppears);
                _card02._scriptableEffect = _scriptableEffects[_tirage02];
                _card02.AttribuerEffect();
                _card02._goUp = true;

                //Si la carte est infinie
                if (!_cardAlreadyUsed[_tirage02]._isInfinite)
                {
                    _cardAlreadyUsed[_tirage02]._numberOfUsing--;
                }
                //Retirer la carte si elle atteint 0
                if (_cardAlreadyUsed[_tirage02]._numberOfUsing <= 0)
                {
                    _cardAlreadyUsed.Remove(_cardAlreadyUsed[_tirage02]);
                }

                StartCoroutine(AttributeCard03());
            }
        }

            
    }

    IEnumerator AttributeCard03()
    {
        if (_cardAlreadyUsed.Count > 0)
        {
            _tirage03 = Random.Range(0, _cardAlreadyUsed.Count);
            if (_tirage03 == _tirage01 || _tirage03 == _tirage02)
            {
                StartCoroutine(AttributeCard03());
            }
            else
            {
                yield return new WaitForSeconds(_timeToWaitBeforeNewCardAppears);
                _card03._scriptableEffect = _scriptableEffects[_tirage03];
                _card03.AttribuerEffect();
                _card03._goUp = true;

                //Si la carte est infinie
                if (!_cardAlreadyUsed[_tirage03]._isInfinite)
                {
                    _cardAlreadyUsed[_tirage03]._numberOfUsing--;
                }
                //Retirer la carte si elle atteint 0
                if (_cardAlreadyUsed[_tirage03]._numberOfUsing <= 0)
                {
                    _cardAlreadyUsed.Remove(_cardAlreadyUsed[_tirage03]);
                }
            }

               
        }
    }
}
