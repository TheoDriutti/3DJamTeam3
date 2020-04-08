using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CardAlreadyUsed
{
    public string _name;
    public int _numberOfUsing;
    public bool _isInfinite;

    public CardAlreadyUsed(string name, int numberOfUsing, bool isInfinite)
    {
        this._name = name;
        this._numberOfUsing = numberOfUsing;
        this._isInfinite = isInfinite;
    }
}
