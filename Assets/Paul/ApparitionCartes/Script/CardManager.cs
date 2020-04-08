using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    [HideInInspector] public Text _titreText, _descriptionText;
    int _actualEffect;
    int _numberOfUsing;

    void Start()
    {
        AttribuerEffect();
    }

    void AttribuerEffect()
    {

    }
}
