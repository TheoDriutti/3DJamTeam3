using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereCaster : MonoBehaviour
{
    public float _sphereRadius, _maxDistance;
    public LayerMask _layerMask;

    public GameObject _currentHitObject;

    Vector3 _origin, _direction;

    float _currentHitDistance;

    public List<GameObject> _enemyTouched;

    void Update()
    {
        _origin = transform.position;
        _direction = transform.forward;

        RaycastHit _hit;
        if (Physics.SphereCast(_origin, _sphereRadius, _direction, out _hit, _maxDistance, _layerMask, QueryTriggerInteraction.UseGlobal))
        {
            if (!_enemyTouched.Contains(_currentHitObject))
            {
                _enemyTouched.Add(_currentHitObject);
            }
            _currentHitObject = _hit.transform.gameObject;
            _currentHitDistance = _hit.distance;
        }
        else
        {
            if (_enemyTouched.Contains(_currentHitObject))
            {
                _enemyTouched.Remove(_currentHitObject);
            }
            _currentHitDistance = _maxDistance;
            _currentHitObject = null;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Debug.DrawLine(_origin, _origin + _direction * _currentHitDistance);
        Gizmos.DrawWireSphere(_origin + _direction * _currentHitDistance, _sphereRadius);
    }
}
