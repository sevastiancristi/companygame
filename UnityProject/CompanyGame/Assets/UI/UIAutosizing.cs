using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAutosizing : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AdjustSize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AdjustSize()
    {
        Vector3 ThisSize = this.transform.GetComponent<RectTransform>().sizeDelta;

        Vector3 BottomSize = this.transform.Find("UIBottom").GetComponent<RectTransform>().sizeDelta;
        Vector3 LeftSize = this.transform.Find("UILeft").GetComponent<RectTransform>().sizeDelta;
        Vector3 BottomLeftCornerSize = this.transform.Find("UIBottomLeftCorner").GetComponent<RectTransform>().sizeDelta;
        Vector3 Border = this.transform.Find("UIBorder").GetComponent<RectTransform>().sizeDelta;

        BottomSize.x = ThisSize.x - BottomLeftCornerSize.x;
        BottomSize.y = BottomLeftCornerSize.y;
        LeftSize.x = BottomLeftCornerSize.x;
        LeftSize.y = ThisSize.y - BottomLeftCornerSize.y;
        Border.x = BottomSize.x;
        Border.y = LeftSize.y;

        this.transform.Find("UIBottom").GetComponent<RectTransform>().sizeDelta = BottomSize;
        this.transform.Find("UILeft").GetComponent<RectTransform>().sizeDelta = LeftSize;
        this.transform.Find("UIBottomLeftCorner").GetComponent<RectTransform>().sizeDelta = BottomLeftCornerSize;
        this.transform.Find("UIBorder").GetComponent<RectTransform>().sizeDelta = Border;
        this.transform.Find("UIBorder").GetComponent<BorderAutosizing>().AdjustSize();
    }
}
