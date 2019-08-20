using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollRectScript : MonoBehaviour
{

    private ScrollRect ScrollRect;
    private bool mouseDown, buttonDown, buttonUp;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        ScrollRect = GetComponent<ScrollRect>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mouseDown)
        {
            if (buttonDown)
                ScrollDown();
            else if (buttonUp)
                ScrollUp();
        }
    }
    public void ButtonDownIsPressed()
    {
        mouseDown = true;
        buttonDown = true;

    }
    public void ButtonUpIsPressed()
    {
        mouseDown = true;
        buttonUp = true;
    }
    public void ScrollDown()
    {
        if(Input.GetMouseButtonUp(0))
        {
            mouseDown = false;
            buttonDown = false;
        }
        else
        {
            ScrollRect.horizontalNormalizedPosition -= speed;
        }
    }
    public void ScrollUp()
    {
        if (Input.GetMouseButtonUp(0))
        {
            mouseDown = false;
            buttonUp = false;
        }
        else
        {
            ScrollRect.horizontalNormalizedPosition +=speed;
        }
    }
}
