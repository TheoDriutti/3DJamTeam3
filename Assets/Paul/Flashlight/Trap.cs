using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private float reloading;
    public int timeToReload = 2;
    private MeshRenderer Mesh;
    public string Type ;
    
    // Start is called before the first frame update
    void Start()
    {
        
       
    }

    // Update is called once per frame
    void Update()
    {
        reloading -= Time.deltaTime;
        
    }

    public void ActiveTrap() 
    {
        if (reloading < 0)
        {
            StartCoroutine(Deploy());

        }
        
    }
    public IEnumerator Deploy() 
    {

        if (Type == "Slow")
        {
            gameObject.transform.localScale = new Vector3(3, 3, 3);
        }
        if (Type == "Stop")
        {
            gameObject.transform.localScale = new Vector3(2, 2, 2);
        }
        
        yield return new WaitForSeconds(1);
        gameObject.transform.localScale = new Vector3(1, 1, 1);
        
        
        reloading = timeToReload;
    }
}
