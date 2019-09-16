using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class SquareButtonController : AbstractButtonController
{
    private float _faceBorderSize;
    public float FaceBorderSize
    {
        get => _faceBorderSize;
        set
        {
            _faceBorderSize = value;
            adjustFaceBorderSize();
        }
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    private Transform functionBackgroundTransform;

    protected override void InitTransformMembers()
    {
        faceTransform = this.transform.Find("Face");
        shadowTransform = this.transform;
        functionTransform = this.transform.Find("Face").Find("FunctionBackground").Find("Function");
        functionBackgroundTransform = this.transform.Find("Face").Find("FunctionBackground");
        infoBoxTransform = this.transform.Find("InfoBox");
    }

    protected override void adjustDepartmentColor()
    {
        base.adjustDepartmentColor();
        faceTransform.GetComponent<Image>().color = faceColor;
        functionTransform.GetComponent<Image>().color = Color.gray;
        functionBackgroundTransform.GetComponent<Image>().color = functionColor;
        shadowTransform.GetComponent<Image>().color = shadowColor;
        infoBoxTransform.GetComponent<Image>().color = ColorProvider.GetBezelColorFromHex(ColorProvider.COLORHEXCODE_PRIMARYBEZELS);
    }

    protected void adjustFaceBorderSize()
    {
        InitTransformMembers();
        functionBackgroundTransform.GetComponent<RectTransform>().sizeDelta = new Vector3(-_faceBorderSize, -_faceBorderSize, 0f);
        functionTransform.GetComponent<RectTransform>().sizeDelta = new Vector3(-_faceBorderSize, -_faceBorderSize, 0f);
    }

    public override void Press()
    {
        faceTransform.GetComponent<Image>().color = functionHighlightColor;
        faceTransform.GetComponent<RectTransform>().localPosition = buttonPressedHeight;
    }

    public override void Unpress()
    {
        faceTransform.GetComponent<Image>().color = faceColor;
        faceTransform.GetComponent<RectTransform>().localPosition = buttonNotPressedHeight;
    }
}
