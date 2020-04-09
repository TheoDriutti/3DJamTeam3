using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemie : MonoBehaviour
{
    private float DeltaTime = 1;
    public float speed;
    public float PV;
    private Rigidbody rb;
    public bool dir;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(dir == true)
        rb.velocity = transform.right * DeltaTime * speed;
        if(dir == false) { rb.velocity = transform.right * DeltaTime * -speed; };

        if (PV < 1)
        {
            // game over
        }
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Piege") && other.gameObject.GetComponent<Trap>().Type == "Slow")
        {
            StartCoroutine(Traped("Slow"));
            
        }
        if (other.gameObject.CompareTag("Piege") && other.gameObject.GetComponent<Trap>().Type == "Stop")
        {
            StartCoroutine(Traped("Stop"));
        }
        
    }

    IEnumerator Traped(string slowOrStop) 
    {
        if (slowOrStop == "Stop")
        {
            DeltaTime = 0;
            yield return new WaitForSeconds(1);
            DeltaTime = 1;
        }
       else if (slowOrStop == "Slow")
        {
            DeltaTime = 0.5f;
            yield return new WaitForSeconds(1);
            DeltaTime = 1;
        }
        

    }

}


