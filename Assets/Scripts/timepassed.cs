using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timepassed : MonoBehaviour
{
    public Text timepass;
    int min=0;
    int sec=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sec = (int)Timebehaviour.tim-min*60;
        if(sec>60)
        {
            min++;
            sec = 1;
        }
        timepass.text = min +" Min "+ sec+" Sec";
        if (gamemanager.ti == true)
        {
            min = 0;
            sec = 0;
            this.gameObject.SetActive(false);
        }
    }
}
