using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SquareButtonsMenuController : AbstractButtonsMenuController
{
    public GameObject leftSquareScrollButtonPrefab;
    public GameObject rightSquareScrollButtonPrefab;

    private GameObject leftScrollGameObject;
    private GameObject rightScrollGameObject;

    private float _fadingBezelWidth = 0f;
    private float FadingBezelWidth
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

    private bool _hasScrollingButtons;
    public bool HasScrollingButtons
    {
        get => _hasScrollingButtons;
        set
        {
            _hasScrollingButtons = value;
            adjustScrollButons();
        }
    }

    private Transform leftFadingBezelTransform;
    private Transform rightFadingBezelTransform;
    private Transform leftFadingToplineBezelTransform;
    private Transform rightFadingToplineBezelTransform;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

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

    protected override void adjustButtonsCount(int value)
    {
        base.adjustButtonsCount(value);
        leftScrollGameObject = Instantiate(leftSquareScrollButtonPrefab, new Vector3(0f, 0f, 0f), Quaternion.identity, toplineDisplayBezelTransform);
        rightScrollGameObject = Instantiate(rightSquareScrollButtonPrefab, new Vector3(0f, 0f, 0f), Quaternion.identity, toplineDisplayBezelTransform);

        //TODO: Remove testing!
        leftScrollGameObject.GetComponent<SquareScrollButtonController>().SelectCallback += () => { Debug.Log("Scrolling left!"); leftScrollGameObject.GetComponent<SquareScrollButtonController>().Unselect(); };
        leftScrollGameObject.GetComponent<SquareScrollButtonController>().UnselectCallback += () => { Debug.Log("Scrolling left done!"); };
        rightScrollGameObject.GetComponent<SquareScrollButtonController>().SelectCallback += () => { Debug.Log("Scrolling right!"); rightScrollGameObject.GetComponent<SquareScrollButtonController>().Unselect(); };
        rightScrollGameObject.GetComponent<SquareScrollButtonController>().UnselectCallback += () => { Debug.Log("Scrolling right done!"); };

    }

    protected override void adjustButtonSize()
    {
        if (ButtonsCount <= 0)
        {
            Debug.LogError(this + ":\n Buttons count must be set first!");
            return;
        }

        InitTransformMembers();
        FadingBezelWidth = ButtonSize / 2;
        Vector3 bezelSize = bezelTransform.GetComponent<RectTransform>().sizeDelta;
        bezelSize.x = ButtonSize * ButtonsCount;
        bezelTransform.GetComponent<RectTransform>().sizeDelta = bezelSize;

        leftScrollGameObject.transform.GetComponent<SquareScrollButtonController>().ButtonSize = ButtonSize;
        rightScrollGameObject.transform.GetComponent<SquareScrollButtonController>().ButtonSize = ButtonSize;

        leftScrollGameObject.transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(0f, 0f, 0f);
        rightScrollGameObject.transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(0f, 0f, 0f);

        for (int i = 0; i < buttonsGameObjectList.Count; i++)
        {
            buttonsGameObjectList[i].GetComponent<SquareButtonController>().ButtonSize = ButtonSize;
            buttonsGameObjectList[i].GetComponent<RectTransform>().anchoredPosition =new Vector3(i* ButtonSize, 0f,0f);
        }

    }


    void adjustFadingBezelWidth()
    {
        if (ButtonsCount <= 0 || ButtonSize <= 0f)
        {
            Debug.LogError(this + ":\n Buttons count, size and spacing must be set first!");
            return;
        }

        InitTransformMembers();

        leftFadingBezelTransform.GetComponent<RectTransform>().sizeDelta = new Vector3(_fadingBezelWidth, 0f, 0f);
        rightFadingBezelTransform.GetComponent<RectTransform>().sizeDelta = new Vector3(_fadingBezelWidth, 0f, 0f);
        leftFadingToplineBezelTransform.GetComponent<RectTransform>().sizeDelta = new Vector3(_fadingBezelWidth, 0f, 0f);
        rightFadingToplineBezelTransform.GetComponent<RectTransform>().sizeDelta = new Vector3(_fadingBezelWidth, 0f, 0f);

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
    }

    protected override void adjustDepartmentColor()
    {
        base.adjustDepartmentColor();

        InitTransformMembers();

        bezelTransform.GetComponent<Image>().color = ColorProvider.GetBezelColorFromHex(ColorProvider.Colors[(int)DepartmentColor][(int)ColorProvider.ColorType.FACE]);
        leftFadingBezelTransform.GetComponent<Image>().color = ColorProvider.GetBezelColorFromHex(ColorProvider.Colors[(int)DepartmentColor][(int)ColorProvider.ColorType.FACE]);
        rightFadingBezelTransform.GetComponent<Image>().color = ColorProvider.GetBezelColorFromHex(ColorProvider.Colors[(int)DepartmentColor][(int)ColorProvider.ColorType.FACE]);

        leftScrollGameObject.transform.GetComponent<SquareScrollButtonController>().DepartmentColor = DepartmentColor;
        rightScrollGameObject.transform.GetComponent<SquareScrollButtonController>().DepartmentColor = DepartmentColor;
    }

    protected override void adjustButtonHeight()
    {
        base.adjustButtonHeight();

        InitTransformMembers();

        leftScrollGameObject.transform.GetComponent<SquareScrollButtonController>().ButtonHeight = ButtonHeight;
        rightScrollGameObject.transform.GetComponent<SquareScrollButtonController>().ButtonHeight = ButtonHeight;
    }

    void adjustFaceBorderSize()
    {
        if(ButtonsCount <= 0 )
        {
            Debug.LogError(this + ":\n Buttons count must be set first!");
        }

        InitTransformMembers();

        for(int i = 0; i < buttonsGameObjectList.Count; i++)
        {
            buttonsGameObjectList[i].GetComponent<SquareButtonController>().FaceBorderSize = _faceBorderSize;
        }
    }

    void adjustScrollButons()
    {
        leftSquareScrollButtonPrefab.SetActive(_hasScrollingButtons);
        rightSquareScrollButtonPrefab.SetActive(_hasScrollingButtons);
    }

    protected override void rearrangeTransformMembers()
    {
        for(int i = 0; i < ButtonsCount; i++)
            buttonsGameObjectList[i].GetComponent<RectTransform>().anchoredPosition = new Vector3(i * ButtonSize, 0f, 0f);
        Vector3 bezelSize = bezelTransform.GetComponent<RectTransform>().sizeDelta;
        bezelSize.x = ButtonSize * ButtonsCount;
        bezelTransform.GetComponent<RectTransform>().sizeDelta = bezelSize;

    }
}
