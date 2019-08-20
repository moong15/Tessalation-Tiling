using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timebehaviour : MonoBehaviour
{
    public static float tim = 0f;
    float sc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tim = Time.timeSinceLevelLoad;

        if (gamemanager.ti)
        {
            sc = PlayerPrefs.GetFloat("Score");
            if (tim < 60f)
                sc+= 100f;
            else if (tim > 60f && tim < 90f)
                sc += 60f;
            else
                sc += 30f;
            Debug.Log(gamemanager.score);
            PlayerPrefs.SetFloat("Score", sc);
            gamemanager.ti = false;
        }
    }
}
