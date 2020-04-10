using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiManager : MonoBehaviour
{
    public enum Ennemi { PETIT, GROS, OMBRE };
    public Transform target;
    public float moveSpeed;
    public float attackRange;
    public float secondesHP;
    public EnumDifferentesLight._differentsMods lampeToKill;

    private Vector3 targetPos;

    // Start is called before the first frame update
    void Start()
    {
        targetPos = new Vector3(target.position.x, transform.position.y, target.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (ClockTimer._isCardVisible)
        {
            Destroy(this.gameObject);
        }

        if (secondesHP < 0.2f)
        {
            Destroy(this.gameObject);
        }

        if (Vector3.Distance(targetPos, transform.position) < attackRange)
        {
            // player prend des dégâts
        }
        else
        {
            //move towards the player
            float step = moveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
        }

    }
}

