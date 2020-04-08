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
            Debug.Log(_numberCard);
            Debug.Log(FindObjectOfType<CardManagerGlobal>()._cardSelected);

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
        Debug.Log(_scriptableEffect._effectTitle);
        yield return new WaitForSeconds(FindObjectOfType<CardManagerGlobal>()._timeCardSelected);
        _goDown = true;

    }
}
