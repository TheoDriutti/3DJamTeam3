using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereCaster : MonoBehaviour
{
    public float _sphereRadius, _maxDistance;
    public LayerMask _layerGlobal;

    Vector3 _origin, _direction;

    float _currentHitDistance;

    public List<GameObject> _TrapTouched;
    public List<GameObject> _EnemyTouched;

    void Update()
    {
        _origin = transform.position;
        _direction = transform.forward;

        _currentHitDistance = _maxDistance;
        _TrapTouched.Clear();
        _EnemyTouched.Clear();
        RaycastHit[] _hits = Physics.SphereCastAll(_origin, _sphereRadius, _direction, _maxDistance, _layerGlobal, QueryTriggerInteraction.UseGlobal);
        foreach (RaycastHit hit in _hits)
        {
            if (hit.transform.gameObject.CompareTag("Piege"))
            {
                _TrapTouched.Add(hit.transform.gameObject);
                _currentHitDistance = hit.distance;
            }
            if (hit.transform.gameObject.CompareTag("Enemy"))
            {
                _EnemyTouched.Add(hit.transform.gameObject);
                _currentHitDistance = hit.distance;
            }
            
        }

        foreach (GameObject trap in _TrapTouched)
        {
            if (gameObject.GetComponent<FlashLight>()._actualMod == 0)
            {
                trap.gameObject.GetComponent<Trap>().ActiveTrap();
            }
            
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Debug.DrawLine(_origin, _origin + _direction * _currentHitDistance);
        Gizmos.DrawWireSphere(_origin + _direction * _currentHitDistance, _sphereRadius);
    }
}
