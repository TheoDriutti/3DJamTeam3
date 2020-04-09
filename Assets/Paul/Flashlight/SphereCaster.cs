using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereCaster : MonoBehaviour
{
    public float _sphereRadius, _maxDistance;
    public LayerMask _layerEnemy;
    public LayerMask _layerTrap;

    Vector3 _origin, _direction;

    float _currentHitDistance;

    public List<GameObject> _enemyTouched;
    public List<GameObject> _trapTouched;

    void Update()
    {
        _origin = transform.position;
        _direction = transform.forward;

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
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Debug.DrawLine(_origin, _origin + _direction * _currentHitDistance);
        Gizmos.DrawWireSphere(_origin + _direction * _currentHitDistance, _sphereRadius);
    }
}
