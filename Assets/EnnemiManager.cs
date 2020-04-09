using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiManager : MonoBehaviour
{
    public enum Ennemi { PETIT, GROS, OMBRE };
    public Transform target;
    public float moveSpeed;
    public float secondesHP;
    public EnumDifferentesLight._differentsMods lampeToKill;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //move towards the player
        float step = moveSpeed * Time.deltaTime;
        Vector3 targetPos = new Vector3(target.position.x, transform.position.y, target.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
        if (secondesHP < 0)
        {
            Destroy(this);
        }
    }
}
