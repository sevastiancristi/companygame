using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundButtonsMainMenuController : AbstractButtonsMenuController
{
    private float _buttonSpacing;
    public float ButtonSpacing
    {
        get => _buttonSpacing;
        set
        {
            _buttonSpacing = value;
            adjustButtonSpacing();
        }
    }

    private float _fadingBezelWidth = 0f;
    public float FadingBezelWidth
    {
        get => _fadingBezelWidth;
        set
        {
            _fadingBezelWidth = value;
            adjustFadingBezelWidth();
        }
    }

    private float _toplineBezelHeight = 0f;
    public float ToplineBezelHeight
    {
        get => _toplineBezelHeight;
        set
        {
            _toplineBezelHeight = value;
            adjustToplineBezelHeight();
        }
    }

    private Transform toplineBezelTransform;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    protected override void InitTransformMembers()
    {
        bezelTransform = this.transform;
        toplineBezelTransform = this.transform.Find("ToplineBezel");
        toplineDisplayBezelTransform = this.transform.Find("ToplineBezel").Find("ToplineDisplayBezel");
    }


    void adjustButtonSpacing()
    {
        if (ButtonsCount <= 0 || ButtonSize <= 0f)
        {
            Debug.LogError(this + ":\n Buttons count and size must be set first!");
            return;
        }

        InitTransformMembers();

        Vector3 bezelSize = toplineDisplayBezelTransform.GetComponent<RectTransform>().sizeDelta;
        bezelSize.x = (ButtonsCount - 1) * _buttonSpacing + ButtonSize;
        toplineDisplayBezelTransform.GetComponent<RectTransform>().sizeDelta = bezelSize;


        FadingBezelWidth = (_buttonSpacing - ButtonSize) / 2;
        for (int i = 0; i < buttonsGameObjectList.Count; i++)
        {
            buttonsGameObjectList[i].GetComponent<RectTransform>().anchoredPosition = new Vector3(ButtonSize / 2 + i * _buttonSpacing, 0f, 0f);
        }
    }

    void adjustFadingBezelWidth()
    {
        if (ButtonsCount <= 0 || ButtonSize <= 0f || _buttonSpacing <= 0f)
        {
            Debug.LogError(this + ":\n Buttons count, size and spacing must be set first!");
            return;
        }

        InitTransformMembers();


        for (int i = 0; i < buttonsGameObjectList.Count; i++)
        {
            buttonsGameObjectList[i].GetComponent<RoundButtonController>().BezelWidth = _fadingBezelWidth;
        }
    }

    void adjustToplineBezelHeight()
    {
        if (ButtonsCount <= 0)
        {
            Debug.LogError(this + ":\n Buttons count must be set first!");
            return;
        }

        InitTransformMembers();

        Vector3 toplineBezelSize = toplineBezelTransform.GetComponent<RectTransform>().sizeDelta;
        toplineBezelSize.y = _toplineBezelHeight;
        toplineBezelTransform.GetComponent<RectTransform>().sizeDelta = toplineBezelSize;
        for (int i = 0; i < buttonsGameObjectList.Count; i++)
        {
            buttonsGameObjectList[i].GetComponent<RoundButtonController>().BezelHeight = _toplineBezelHeight;
        }
    }

    protected override void adjustDepartmentColor()
    {
        base.adjustDepartmentColor();
        InitTransformMembers();

        bezelTransform.GetComponent<Image>().color = ColorProvider.GetBezelColorFromHex(ColorProvider.Colors[(int)DepartmentColor][(int)ColorProvider.ColorType.FACE]);

    }

}
