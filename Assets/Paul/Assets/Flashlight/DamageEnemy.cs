using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : MonoBehaviour
{
        void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            int _damage = FindObjectOfType<FlashLight>()._damage;
            Debug.Log("Je mets " + _damage);
        }
    }
}
