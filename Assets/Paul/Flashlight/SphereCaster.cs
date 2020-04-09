using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereCaster : MonoBehaviour
{
    public float _sphereRadius, _maxDistance;
<<<<<<< HEAD
    public LayerMask _layerMask;

    public GameObject _currentHitObject;
=======
    public LayerMask _layerEnemy;
    public LayerMask _layerTrap;
>>>>>>> fbefcaf89676c4bafc6ec5ed081e435607ba2fd7

    Vector3 _origin, _direction;

    float _currentHitDistance;

    public List<GameObject> _enemyTouched;
<<<<<<< HEAD
=======
    public List<GameObject> _trapTouched;
>>>>>>> fbefcaf89676c4bafc6ec5ed081e435607ba2fd7

    void Update()
    {
        _origin = transform.position;
        _direction = transform.forward;

<<<<<<< HEAD
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
=======
        _currentHitDistance = _maxDistance;
        _enemyTouched.Clear();
        RaycastHit[] _hitsEnemy = Physics.SphereCastAll(_origin, _sphereRadius, _direction, _maxDistance, _layerEnemy, QueryTriggerInteraction.UseGlobal);
        foreach (RaycastHit hit in _hitsEnemy)
        {
            _enemyTouched.Add(hit.transform.gameObject);
            _currentHitDistance = hit.distance;
        }
        _trapTouched.Clear();
        RaycastHit[] _hitsTrap = Physics.SphereCastAll(_origin, _sphereRadius, _direction, _maxDistance, _layerTrap, QueryTriggerInteraction.UseGlobal);
        foreach (RaycastHit hit in _hitsTrap)
        {
            _trapTouched.Add(hit.transform.gameObject);
            _currentHitDistance = hit.distance;
>>>>>>> fbefcaf89676c4bafc6ec5ed081e435607ba2fd7
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Debug.DrawLine(_origin, _origin + _direction * _currentHitDistance);
        Gizmos.DrawWireSphere(_origin + _direction * _currentHitDistance, _sphereRadius);
    }
}
