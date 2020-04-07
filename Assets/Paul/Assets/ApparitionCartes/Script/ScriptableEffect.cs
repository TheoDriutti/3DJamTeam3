using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New effect", menuName = "Add new effect")]
public class ScriptableEffect : ScriptableObject
{

    [TextArea(1, 1)]
    public string _effectTitle;
    [TextArea(5, 1)]
    public string _effectDescription;
    public EnumEffect._enumEffect _EnumEffect;
    public int _id;

    public int _numberOfReusing;
}
