using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private float reloading;
    public int timeToReload = 2;
    private MeshRenderer Mesh;
    private SphereCollider collider;
    // Start is called before the first frame update
    void Start()
    {
        collider = gameObject.GetComponent<SphereCollider>();
        collider.enabled = false;
        Mesh = gameObject.GetComponent<MeshRenderer>();
        Mesh.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        reloading -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && reloading < 0) 
        {
            StartCoroutine(Deploy());
            
        
        }
    }

    IEnumerator Deploy() 
    {
        Mesh.enabled = true;
        collider.enabled = true;
        gameObject.transform.localScale = new Vector3(3, 3, 1);
        yield return new WaitForSeconds(1);
        gameObject.transform.localScale = new Vector3(1, 1, 1);
        Mesh.enabled = false;
        collider.enabled = false;
        reloading = timeToReload;
    }
}
