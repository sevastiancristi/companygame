using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class SquareScrollButtonController : AbstractButtonController
{
    private Transform functionBackgroundTransform;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }


    public override void Press()
    {
        functionTransform.GetComponent<Image>().color = functionHighlightColor;
        faceTransform.GetComponent<RectTransform>().localPosition = buttonPressedHeight;
    }

    public override void Unpress()
    {
        functionTransform.GetComponent<Image>().color = functionColor;
        faceTransform.GetComponent<RectTransform>().localPosition = buttonNotPressedHeight;
    }

    protected override void InitTransformMembers()
    {
        faceTransform = this.transform.Find("Face");
        shadowTransform = this.transform;
        functionTransform = this.transform.Find("Face").Find("Function");
        infoBoxTransform = this.transform.Find("InfoBox");
    }

    protected override void adjustDepartmentColor()
    {
        base.adjustDepartmentColor();
        faceTransform.GetComponent<Image>().color = faceColor;
        functionTransform.GetComponent<Image>().color = functionColor;
        shadowTransform.GetComponent<Image>().color = shadowColor;
        infoBoxTransform.GetComponent<Image>().color = ColorProvider.GetBezelColorFromHex(ColorProvider.COLORHEXCODE_PRIMARYBEZELS);
    }

    protected override void adjustButtonSize()
    {
        InitTransformMembers();
        shadowTransform.GetComponent<RectTransform>().sizeDelta = new Vector3(ButtonSize/4, ButtonSize, 0f);
        infoBoxTransform.GetComponent<RectTransform>().sizeDelta = new Vector3(ButtonSize, ButtonSize, 0f);
    }


}
