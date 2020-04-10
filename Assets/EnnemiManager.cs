using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnnemiManager : MonoBehaviour
{
    public enum Ennemi { PETIT, GROS, OMBRE };
    public Transform target;
    public float moveSpeed;
    private float initialSpeed;
    public float attackRange;
    public float secondesHP;
    public EnumDifferentesLight._differentsMods lampeToKill;

    private Vector3 targetPos;

    // Start is called before the first frame update
    void Start()
    {
        targetPos = new Vector3(target.position.x, transform.position.y, target.position.z);
        initialSpeed = moveSpeed;
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
            Cursor.visible = true;
            SceneManager.LoadScene(0);
        }
        else
        {
            //move towards the player
            float step = moveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trap") && other.gameObject.GetComponent<Trap>().TrapIsActive == true)
        {
            StartCoroutine(Traped(other.gameObject));

        }
    }

    IEnumerator Traped(GameObject trap)
    {
        if (trap.GetComponent<Trap>().Type == "Slow")
        {
            moveSpeed = moveSpeed * 0.5f;
        }

        if (trap.GetComponent<Trap>().Type == "Stop")
        {
            moveSpeed = moveSpeed * 0;
        }
        yield return new WaitForSeconds(trap.GetComponent<Trap>().TempsDeViePiege);
        moveSpeed = initialSpeed;


    }
}

