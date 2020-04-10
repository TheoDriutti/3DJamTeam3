using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoupeLight : MonoBehaviour
{
    public bool _stoperLight;
    void Start()
    {
        if(_stoperLight)
            this.gameObject.SetActive(false);
    }
}
