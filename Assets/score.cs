using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public Text sco;
    float scor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scor = PlayerPrefs.GetFloat("Score");
        sco.text = "Score  " + scor;
    }
}
