using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleCamera : MonoBehaviour
{
    public float _rotateMax;
    public float _speed;
    [HideInInspector] public float _numberIncrease;
    float _rotateMin;
    bool _isIncreasing;

    private void Start()
    {
        _rotateMin = -_rotateMax;
    }

    void Update()
    {
        Debug.Log(_numberIncrease);
        Debug.Log(_isIncreasing);
        if (_isIncreasing)
            _numberIncrease += _speed / 100;
        else
            _numberIncrease -= _speed / 100;

        if (_numberIncrease >= _rotateMax)
            _isIncreasing = false;
        else if (_numberIncrease <= _rotateMin)
            _isIncreasing = true;
    }
}
