using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundButtonsMenuController : AbstractButtonsMenuController
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
    public float  ToplineBezelHeight
    {
        get => _toplineBezelHeight;
        set
        {
            _toplineBezelHeight = value;
            adjustToplineBezelHeight();
        }
    }

    private Transform leftFadingBezelTransform;
    private Transform rightFadingBezelTransform;
    private Transform leftFadingToplineBezelTransform;
    private Transform rightFadingToplineBezelTransform;

    // Start is called before the first frame update
    protected override void Start()
    {
        InitTransformMembers();
        buttonsGameObjectList = new List<GameObject>();
    }

    protected override void InitTransformMembers()
    {
        bezelTransform = this.transform;
        leftFadingBezelTransform = this.transform.Find("LeftFadingBezel");
        rightFadingBezelTransform = this.transform.Find("RightFadingBezel");
        toplineDisplayBezelTransform = this.transform.Find("ToplineDisplayBezel");
        leftFadingToplineBezelTransform = this.transform.Find("ToplineDisplayBezel").Find("LeftFadingBezel");
        rightFadingToplineBezelTransform = this.transform.Find("ToplineDisplayBezel").Find("RightFadingBezel");
    }

    void adjustButtonSpacing()
    {
        if (ButtonsCount <= 0 || ButtonSize <= 0f)
        {
            Debug.LogError(this + ":\n Buttons count and size must be set first!");
            return;
        }

        InitTransformMembers();

        Vector3 bezelSize = bezelTransform.GetComponent<RectTransform>().sizeDelta;
        bezelSize.x = (ButtonsCount - 1) * _buttonSpacing + ButtonSize;
        bezelTransform.GetComponent<RectTransform>().sizeDelta = bezelSize;


        FadingBezelWidth = (_buttonSpacing - ButtonSize) / 2;
        for (int i = 0; i < buttonsGameObjectList.Count; i++)
        {
            buttonsGameObjectList[i].GetComponent<RectTransform>().anchoredPosition = new Vector3(ButtonSize / 2 + i*_buttonSpacing, 0f, 0f);
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

        leftFadingBezelTransform.GetComponent<RectTransform>().sizeDelta = new Vector3(_fadingBezelWidth, 0f, 0f);
        rightFadingBezelTransform.GetComponent<RectTransform>().sizeDelta = new Vector3(_fadingBezelWidth, 0f, 0f);
        leftFadingToplineBezelTransform.GetComponent<RectTransform>().sizeDelta = new Vector3(_fadingBezelWidth, 0f, 0f);
        rightFadingToplineBezelTransform.GetComponent<RectTransform>().sizeDelta = new Vector3(_fadingBezelWidth, 0f, 0f);

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

        Vector3 toplineBezelSize = toplineDisplayBezelTransform.GetComponent<RectTransform>().sizeDelta;
        toplineBezelSize.y = _toplineBezelHeight;
        toplineDisplayBezelTransform.GetComponent<RectTransform>().sizeDelta = toplineBezelSize;
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
        leftFadingBezelTransform.GetComponent<Image>().color = ColorProvider.GetBezelColorFromHex(ColorProvider.Colors[(int)DepartmentColor][(int)ColorProvider.ColorType.FACE]);
        rightFadingBezelTransform.GetComponent<Image>().color = ColorProvider.GetBezelColorFromHex(ColorProvider.Colors[(int)DepartmentColor][(int)ColorProvider.ColorType.FACE]);

    }

    protected override void rearrangeTransformMembers()
    {
        InitTransformMembers();

        Vector3 bezelSize = bezelTransform.GetComponent<RectTransform>().sizeDelta;
        bezelSize.x = (ButtonsCount - 1) * _buttonSpacing + ButtonSize;
        bezelTransform.GetComponent<RectTransform>().sizeDelta = bezelSize;

        for (int i = 0; i < buttonsGameObjectList.Count; i++)
        {
            buttonsGameObjectList[i].GetComponent<RectTransform>().anchoredPosition = new Vector3(ButtonSize / 2 + i * _buttonSpacing, 0f, 0f);
        }
    }

}
