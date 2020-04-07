using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CardAlreadyUsed
{
    public string _name;
    public int _numberOfUsing;

    public CardAlreadyUsed(string name, int numberOfUsing)
    {
        this._name = name;
        this._numberOfUsing = numberOfUsing;
    }
}
