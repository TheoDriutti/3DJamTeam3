using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New effect", menuName = "Add new effect")]
public class ScriptableEffect : ScriptableObject
{

    [Header("Description lisible sur la carte")]
    [TextArea(1, 1)]
    public string _effectTitle;
    [TextArea(5, 1)]
    public string _effectDescription;
    [Header("Effet a choisir")]
    public EnumEffect._enumEffect _EnumEffect;

    [Header("Nombre d'utilisation")]
    public bool _isInfinite;
    public int _numberOfReusing;
}
