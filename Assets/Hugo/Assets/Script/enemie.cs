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

    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.CompareTag("Mur"))
        {
            dir = false;
          
        }
        if (collision.gameObject.CompareTag("Mur2"))
        {
            
            dir = true;
          
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Piege1"))
        {
            StartCoroutine(Traped("Stop"));
        }
        if (other.gameObject.CompareTag("Piege2"))
        {
            StartCoroutine(Traped("Slow"));
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


