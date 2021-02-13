using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PanelMove : MonoBehaviour
{
    RectTransform rectTransform;
    int x = 0;
    public int pageCount
    {
        get
        {
            return x;
        }
        set
        {
            x = value;
            //rectTransform.position = new Vector3(-1080*x,0,0);
            rectTransform.anchoredPosition = new Vector2(-1080*x,0);
        }
    }
    public void BackButtonOnClick()
    {
        pageCount--;
    }
    // Start is
    // called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
