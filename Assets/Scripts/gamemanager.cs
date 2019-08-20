using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class gamemanager : MonoBehaviour
{
    public static int count =0;
    public static gamemanager g;
    public static bool ti = false;
    public static float score = 0f;
    public int fina = 25;
    public GameObject nice;
    public GameObject notnice;
    public static bool correctposi = false;
    public static bool wrongposi = false;
    public float noofLives = 5f;
    public Image lifeBarImage;
    public int wrongCount = 0;
    public bool istimerenabled = false;
    public Image fillImage;
    public float TimeLeft = 25;
    float sc;
    public bool invokeOnce = false;
    public bool changetimerflag = true;
    public bool isGameOver = false;
    public bool addscore = false;
    public static int lastscene;
    public AudioSource well_done;
    public AudioSource try_again;
    public AudioSource wrong;
    public AudioSource right;
    public static int ran;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        ti = false;
        ResetTimer();
        //fina = 25f;
        // nice.GetComponent<Text>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {


        ran = Random.Range(4, 17);
        //fina = 25;
        if (count==fina)
        {
            //Debug.Log(count);
            //Debug.Log(fina);
            change();
            count = 0;
        }
        if (correctposi==true)
        {
            correctposi = false;
            text1e();
            well_done.Play();
            right.Play();
            addscore = true;
            Invoke("text1d", 1);
            
        }
        if(wrongposi==true)
        {
            wrongposi = false;
            ReduceLife();
            text2e();
            try_again.Play();
            wrong.Play();
            ResetTimer();
            Invoke("text2d", 1);
        }
        if (!isGameOver && changetimerflag)
        {
            ChangeTextAccordingtotime();
            if (fillImage.fillAmount == 0 && istimerenabled)
            {
                ResetTimer();
            }
        }
    }
    public void change()
    {
        Debug.Log("Level Complete");
        ti = true;
        Invoke("loadsc", 2f);
    }
    public void text1e()
    {
        nice.SetActive(true);
    }
    public void text1d()
    {
        nice.SetActive(false);
    }
    public void text2e()
    {
        notnice.SetActive(true);
    }
    public void text2d()
    {
        notnice.SetActive(false);
    }
    public void call()
    {
        
    }

    public void Homepage()
    {
        SceneManager.LoadScene(0);
        PlayerPrefs.SetFloat("Score", 0f);
    }

    public void Instructions()
    {
        SceneManager.LoadScene(1);
    }

    public void loadsc()
    {
        lastscene = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(lastscene);
        SceneManager.LoadScene(2);
    }

    public void Replay()
    {
        Debug.Log(lastscene);
        SceneManager.LoadScene(lastscene);
    }

    public void next()
    {
        Debug.Log(ran);
        SceneManager.LoadScene(ran);
        
    }
    public void video()
    {
        SceneManager.LoadScene(18);
    }


    public void ReduceLife()
    {
        //Debug.Log("Reduce Life function called");
        wrongCount++;

        if (wrongCount <= 5)
        {
            lifeBarImage.DOFillAmount(lifeBarImage.fillAmount - (1 / noofLives), .5f);
            //Debug.Log("life lost");
        }
        if (wrongCount == 5)
        {
            SceneManager.LoadScene(3);
            isGameOver = true;
        }
    }
    public void ResetTimer()
    {
        if(SceneManager.GetActiveScene().buildIndex >= 3)
        {
            istimerenabled = true;
            fillImage.gameObject.SetActive(true);
            TimeLeft = 10;
        }
        
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void ChangeTextAccordingtotime()
    {
        if (istimerenabled)
        {
            fillImage.gameObject.SetActive(true);
            TimeLeft -= Time.deltaTime;
            float TimeInt = TimeLeft;
            //Debug.Log(TimeInt);
            sc = PlayerPrefs.GetFloat("Score");

            fillImage.fillAmount = TimeLeft / 10;
            if (TimeInt >= 8f && TimeInt < 10f && addscore==true)
            {
                sc +=5;
                PlayerPrefs.SetFloat("Score", sc);
                addscore = false;
                ResetTimer();
            }
            if (TimeInt >= 6f && TimeInt < 8f && addscore == true)
            {
                sc += 4;
                PlayerPrefs.SetFloat("Score", sc);
                addscore = false;
                //Debug.Log(TimeInt);
                ResetTimer();
            }
            else if (TimeInt >= 4f && TimeInt < 6f && addscore == true)
            {
                sc += 3;
                PlayerPrefs.SetFloat("Score", sc);
                addscore = false;
                ResetTimer();
            }
            else if (TimeInt >= 2f && TimeInt < 4f && addscore == true)
            {
                sc += 2;
                PlayerPrefs.SetFloat("Score", sc);
                addscore = false;
                ResetTimer();
            }
            else if (TimeInt > 0f && TimeInt < 2f && addscore == true)
            {
                sc += 1;
                PlayerPrefs.SetFloat("Score", sc);
                addscore = false;
                invokeOnce = true;
                ResetTimer();
            }
            else if (TimeInt <= 0.1f )
            {
                sc += 0;
                PlayerPrefs.SetFloat("Score", sc);
                //RandomTargetPosition();
                ReduceLife();
                ResetTimer();
                invokeOnce = false;
            }
            //make 0 work only once.
        }
    }
}
