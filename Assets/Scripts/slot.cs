using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class slot : MonoBehaviour, IDropHandler {

   //string newparentName, prevparentName;
    public GameObject item
    {
        
        get
        {
            if (transform.childCount > 0)
            {
                return transform.GetChild (0).gameObject;
            }
            return null;
    }

}

    public void OnDrop(PointerEventData eventData)
    {
        if(!item)
        {
            if(DragHandler.itemBeginDragged.tag==this.tag)
            {
                if (DragHandler.itemBeginDragged.transform.parent.transform.parent.tag == "Scroll" && this.transform.parent.tag=="Empty")
                {
                    gamemanager.count++;
                    //Debug.Log("mf");
                    gamemanager.correctposi = true;
                }
                else if (DragHandler.itemBeginDragged.transform.parent.transform.parent.tag == "Empty" && this.transform.parent.tag == "Scroll")
                {
                    gamemanager.count--;
                    //Debug.Log("count: " + gamemanager.count);
                }
                DragHandler.itemBeginDragged.transform.SetParent(transform);
                //DragHandler.itemBeginDragged.transform.rotation = DragHandler.itemBeginDragged.transform.parent.gameObject.transform.rotation;
                //DragHandler.itemBeginDragged.transform.localScale = DragHandler.itemBeginDragged.transform.parent.gameObject.transform.localScale;

                //newparentName = DragHandler.itemBeginDragged.transform.parent.transform.parent.name;
                //Debug.Log("New: " + newparentName);
            }
            else if (DragHandler.itemBeginDragged.tag != this.tag)
            {
                gamemanager.wrongposi = true;
            }


        }
    }
    

}
