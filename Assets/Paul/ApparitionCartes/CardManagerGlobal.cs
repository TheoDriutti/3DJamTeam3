using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManagerGlobal : MonoBehaviour
{
    public List<ScriptableEffect> _scriptableEffects;
    public List<CardAlreadyUsed> _cardAlreadyUsed;

    public CardManager _card01;
    int _tirage01;

    void Start()
    {
        for (int i= 0; i<_scriptableEffects.Count; i++)
        {
            Debug.Log(i);
            _cardAlreadyUsed.Add(new CardAlreadyUsed(_scriptableEffects[i]._effectTitle, _scriptableEffects[i]._numberOfReusing));
        }
    }

    void AttributeCard()
    {
        _tirage01 = Random.Range(0, _scriptableEffects.Count - 1);
        //if(_cardAlreadyUsed)
    }
}
