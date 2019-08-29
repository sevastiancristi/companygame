using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class RoundButtonController : AbstractButtonController
{
    private float _bezelWidth;
    public float BezelWidth
    {
        get => _bezelWidth;
        set
        {
            _bezelWidth = value;
            adjustBezelWidth();
        }
    }

    private float _bezelHeight;
    public float BezelHeight
    {
        get => _bezelHeight;
        set
        {
            _bezelHeight = value;
            adjustBezelHeight();
        }
    }

    private Transform bezelTransform;
    private Transform leftBezelTransform;
    private Transform rightBezelTransform;


    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        bezelTransform.gameObject.SetActive(false);
    }

    public override void Press()
    {
        bezelTransform.gameObject.SetActive(true);
        functionTransform.GetComponent<Image>().color = functionHighlightColor;
        faceTransform.GetComponent<RectTransform>().localPosition = buttonPressedHeight;
    }

    public override void Unpress()
    {
        bezelTransform.gameObject.SetActive(false);
        functionTransform.GetComponent<Image>().color = functionColor;
        faceTransform.GetComponent<RectTransform>().localPosition = buttonNotPressedHeight;
    }

    protected override void InitTransformMembers()
    {
        faceTransform = this.transform.Find("Face");
        shadowTransform = this.transform;
        functionTransform = this.transform.Find("Face").Find("Function");
        bezelTransform = this.transform.Find("Bezel");
        leftBezelTransform = this.transform.Find("Bezel").Find("LeftBezel");
        rightBezelTransform = this.transform.Find("Bezel").Find("RightBezel");
        infoBoxTransform = this.transform.Find("InfoBox");
    }

    protected override void adjustDepartmentColor()
    {
        base.adjustDepartmentColor();
        faceTransform.GetComponent<Image>().color = faceColor;
        functionTransform.GetComponent<Image>().color = functionColor;
        shadowTransform.GetComponent<Image>().color = shadowColor;
        bezelTransform.GetComponent<Image>().color = faceColor;
        leftBezelTransform.GetComponent<Image>().color = faceColor;
        rightBezelTransform.GetComponent<Image>().color = faceColor;
    }

    private void adjustBezelWidth()
    {
        InitTransformMembers();
        leftBezelTransform.GetComponent<RectTransform>().sizeDelta = new Vector3(_bezelWidth, 0f, 0f);
        rightBezelTransform.GetComponent<RectTransform>().sizeDelta = new Vector3(_bezelWidth, 0f, 0f);
    }

    private void adjustBezelHeight()
    {
        InitTransformMembers();
        bezelTransform.GetComponent<RectTransform>().sizeDelta = new Vector3(0f, _bezelHeight, 0f);
    }

}
