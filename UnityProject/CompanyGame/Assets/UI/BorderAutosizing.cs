using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderAutosizing : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AdjustSize()
    {
        Vector3 ThisSize = this.transform.GetComponent<RectTransform>().sizeDelta;

        Vector3 BottomSize = this.transform.Find("UIBorder_Bottom").GetComponent<RectTransform>().sizeDelta;
        Vector3 TopSize = this.transform.Find("UIBorder_Top").GetComponent<RectTransform>().sizeDelta;
        Vector3 LeftSize = this.transform.Find("UIBorder_Left").GetComponent<RectTransform>().sizeDelta;
        Vector3 RightSize = this.transform.Find("UIBorder_Right").GetComponent<RectTransform>().sizeDelta;
        Vector3 BottomLeftCornerDownSize = this.transform.Find("UIBorder_BottomLeftCornerDown").GetComponent<RectTransform>().sizeDelta;
        Vector3 BottomLeftCornerUpSize = this.transform.Find("UIBorder_BottomLeftCornerUp").GetComponent<RectTransform>().sizeDelta;
        Vector3 TopLeftCornerDownSize = this.transform.Find("UIBorder_TopLeftCornerDown").GetComponent<RectTransform>().sizeDelta;
        Vector3 TopLeftCornerUpSize = this.transform.Find("UIBorder_TopLeftCornerUp").GetComponent<RectTransform>().sizeDelta;
        Vector3 TopRightCornerDownSize = this.transform.Find("UIBorder_TopRightCornerDown").GetComponent<RectTransform>().sizeDelta;
        Vector3 TopRightCornerUpSize = this.transform.Find("UIBorder_TopRightCornerUp").GetComponent<RectTransform>().sizeDelta;
        Vector3 BottomRightCornerDownSize = this.transform.Find("UIBorder_BottomRightCornerDown").GetComponent<RectTransform>().sizeDelta;
        Vector3 BottomRightCornerUpSize = this.transform.Find("UIBorder_BottomRightCornerUp").GetComponent<RectTransform>().sizeDelta;

        BottomSize.x = ThisSize.x - 2 * BottomSize.y;
        TopSize = BottomSize;
        LeftSize.x = BottomSize.y;
        LeftSize.y = ThisSize.y - 2*BottomSize.y;
        RightSize.x = BottomSize.y;
        RightSize.y = LeftSize.y;
        BottomLeftCornerDownSize.x = BottomSize.y;
        BottomLeftCornerDownSize.y = BottomSize.y;
        BottomLeftCornerUpSize.x = BottomSize.y; 
        BottomLeftCornerUpSize.y = BottomSize.y; 
        TopLeftCornerDownSize.x = BottomSize.y; 
        TopLeftCornerDownSize.y = BottomSize.y; 
        TopLeftCornerUpSize.x = BottomSize.y; 
        TopLeftCornerUpSize.y = BottomSize.y; 
        TopRightCornerDownSize.x = BottomSize.y; 
        TopRightCornerDownSize.y = BottomSize.y; 
        TopRightCornerUpSize.x = BottomSize.y; 
        TopRightCornerUpSize.y = BottomSize.y; 
        BottomRightCornerDownSize.x = BottomSize.y;
        BottomRightCornerDownSize.y = BottomSize.y;
        BottomRightCornerUpSize.x = BottomSize.y; 
        BottomRightCornerUpSize.y = BottomSize.y;

        this.transform.Find("UIBorder_Bottom").GetComponent<RectTransform>().sizeDelta = BottomSize;
        this.transform.Find("UIBorder_Top").GetComponent<RectTransform>().sizeDelta = TopSize;
        this.transform.Find("UIBorder_Left").GetComponent<RectTransform>().sizeDelta = LeftSize;
        this.transform.Find("UIBorder_Right").GetComponent<RectTransform>().sizeDelta = RightSize;
        this.transform.Find("UIBorder_BottomLeftCornerDown").GetComponent<RectTransform>().sizeDelta = BottomLeftCornerDownSize;
        this.transform.Find("UIBorder_BottomLeftCornerUp").GetComponent<RectTransform>().sizeDelta = BottomLeftCornerUpSize;
        this.transform.Find("UIBorder_TopLeftCornerDown").GetComponent<RectTransform>().sizeDelta = TopLeftCornerDownSize;
        this.transform.Find("UIBorder_TopLeftCornerUp").GetComponent<RectTransform>().sizeDelta = TopLeftCornerUpSize;
        this.transform.Find("UIBorder_TopRightCornerDown").GetComponent<RectTransform>().sizeDelta = TopRightCornerDownSize;
        this.transform.Find("UIBorder_TopRightCornerUp").GetComponent<RectTransform>().sizeDelta = TopRightCornerUpSize;
        this.transform.Find("UIBorder_BottomRightCornerDown").GetComponent<RectTransform>().sizeDelta = BottomRightCornerDownSize;
        this.transform.Find("UIBorder_BottomRightCornerUp").GetComponent<RectTransform>().sizeDelta = BottomRightCornerUpSize;
    }
}
