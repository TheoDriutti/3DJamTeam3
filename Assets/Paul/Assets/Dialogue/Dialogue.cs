using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string _nameOfTheSpeaker;

    [TextArea(3,1)]
    public string[] _sentences;
}
