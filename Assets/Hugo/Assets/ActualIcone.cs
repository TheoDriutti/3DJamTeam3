using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActualIcone : MonoBehaviour
{

    public EnumDifferentesLight._differentsMods _enumName;
    public int _id;
    float _ecart = 115;

    void Start()
    {
        ChangingIcone();
        this.transform.position = new Vector3(this.transform.position.x + (_ecart * (_id-1)), this.transform.position.y, this.transform.position.z);
    }
    public void ChangingIcone()
    {
        if (!ClockTimer._isCardVisible)
        {
            if (FindObjectOfType<FlashLight>()._differentsMods == _enumName)
            {
                this.GetComponent<Image>().color = new Color(255, 255, 255, 0.9f);
            }
            else
            {
                this.GetComponent<Image>().color = new Color(255, 255, 255, 0.2f);
            }
        }
        else
        {
            this.GetComponent<Image>().color = new Color(255, 255, 255, 0.2f);
        }
    }
}
