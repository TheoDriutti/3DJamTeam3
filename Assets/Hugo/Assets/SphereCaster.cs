using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereCaster : MonoBehaviour
{
    public float _sphereRadius, _maxDistance;
    public LayerMask _layerGlobal;

    Vector3 _origin, _direction;

    float _currentHitDistance;

    [HideInInspector] public List<GameObject> _objectTouched;

    void Update()
    {
        _origin = transform.position;
        _direction = transform.forward;

        _currentHitDistance = _maxDistance;
        _objectTouched.Clear();
        RaycastHit[] _hits = Physics.SphereCastAll(_origin, _sphereRadius, _direction, _maxDistance, _layerGlobal, QueryTriggerInteraction.UseGlobal);
        foreach (RaycastHit hit in _hits)
        {
            _objectTouched.Add(hit.transform.gameObject);
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
