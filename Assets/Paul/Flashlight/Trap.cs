using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private float reloading;
    public bool TrapIsActive = false;
    public float multiplicateur = 1;
    public float TempsDeViePiege = 1;
    public float RadiusMultiplicateur;
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
        TrapIsActive = true;
        if (Type == "Slow")
        {
            gameObject.transform.localScale = new Vector3(2 * RadiusMultiplicateur, 2 * RadiusMultiplicateur, 2 * RadiusMultiplicateur);
        }
        if (Type == "Stop")
        {
            gameObject.transform.localScale = new Vector3(1*RadiusMultiplicateur,1 * RadiusMultiplicateur, 1 * RadiusMultiplicateur);
        }
        
        yield return new WaitForSeconds(TempsDeViePiege);
        gameObject.transform.localScale = new Vector3(1, 1, 1);
        TrapIsActive = false;
        
        reloading = timeToReload* multiplicateur;
    }
}
