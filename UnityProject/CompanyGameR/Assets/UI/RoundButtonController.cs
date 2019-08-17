using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class RoundButtonController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IPointerDownHandler
{
    private ColorProvider.Department _departmentColor;
    public ColorProvider.Department DepartmentColor
    {
        get => _departmentColor;
        set
        {
            _departmentColor = value;
            adjustDepartmentColor();
        }
    }

    private float _buttonSize;
    public float ButtonSize
    {
        get => _buttonSize;
        set
        {
            _buttonSize = value;
            adjustButtonSize();
        }
    }

    private float _buttonHeight;
    public float ButtonHeight
    {
        get => _buttonHeight;
        set
        {
            _buttonHeight = value;
            adjustButtonHeight();
        }
    }

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


    public Action SelectCallback;
    public Action UnselectCallback;

    private Vector3 buttonNotPressedHeight;
    private Vector3 buttonPressedHeight;

    private Color faceColor;
    private Color functionColor;
    private Color shadowColor;
    private Color functionHighlightColor = Color.white;

    private Transform faceTransform;
    private Transform shadowTransform;
    private Transform functionTransform;
    private Transform bezelTransform;
    private Transform leftBezelTransform;
    private Transform rightBezelTransform;

    private bool IsSelected = false;

    // Start is called before the first frame update
    void Start()
    {
        InitTransformMembers();
    }

    //TODO: Optimize if needed
    public void OnPointerEnter(PointerEventData eventData)
    {
        if(!IsSelected)
            functionTransform.GetComponent<Image>().color = functionHighlightColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!IsSelected)
        {
            functionTransform.GetComponent<Image>().color = functionColor;
            faceTransform.GetComponent<RectTransform>().localPosition = buttonNotPressedHeight;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        faceTransform.GetComponent<RectTransform>().localPosition = buttonPressedHeight;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (IsSelected)
        {
            this.Unselect();
        }
        else
        {
            this.Select();
        }
    }

    public void Select()
    {
        if (!IsSelected)
        {
            bezelTransform.gameObject.SetActive(true);
            SelectCallback();
            IsSelected = true;
        }
    }

    public void Unselect()
    {
        if (IsSelected)
        {
            bezelTransform.gameObject.SetActive(false);
            faceTransform.GetComponent<RectTransform>().localPosition = buttonNotPressedHeight;
            UnselectCallback();
            IsSelected = false;
        }
    }

    public void Press()
    {
        functionTransform.GetComponent<Image>().color = functionHighlightColor;
        faceTransform.GetComponent<RectTransform>().localPosition = buttonPressedHeight;
        IsSelected = true;
    }

    private void InitTransformMembers()
    {
        faceTransform = this.transform.Find("Face");
        shadowTransform = this.transform;
        functionTransform = this.transform.Find("Face").Find("Function");
        bezelTransform = this.transform.Find("Bezel");
        leftBezelTransform = this.transform.Find("Bezel").Find("LeftBezel");
        rightBezelTransform = this.transform.Find("Bezel").Find("RightBezel");
    }

    private void adjustButtonHeight()
    {
        InitTransformMembers();
        buttonNotPressedHeight = new Vector3(0f, _buttonHeight, 0f);
        buttonPressedHeight = new Vector3(0f, 0f, 0f);
        faceTransform.GetComponent<RectTransform>().localPosition = buttonNotPressedHeight;
    }

    private void adjustDepartmentColor()
    {
        InitTransformMembers();
        faceColor = ColorProvider.GetColorFromHex(ColorProvider.Colors[(int)_departmentColor][(int)ColorProvider.ColorType.FACE]);
        functionColor = ColorProvider.GetColorFromHex(ColorProvider.Colors[(int)_departmentColor][(int)ColorProvider.ColorType.FUNCTION]);
        shadowColor = ColorProvider.GetColorFromHex(ColorProvider.Colors[(int)_departmentColor][(int)ColorProvider.ColorType.SHADOW]);
        faceTransform.GetComponent<Image>().color = faceColor;
        functionTransform.GetComponent<Image>().color = functionColor;
        shadowTransform.GetComponent<Image>().color = shadowColor;
        bezelTransform.GetComponent<Image>().color = faceColor;
        leftBezelTransform.GetComponent<Image>().color = faceColor;
        rightBezelTransform.GetComponent<Image>().color = faceColor;

        bezelTransform.gameObject.SetActive(false);
    }

    //This should always be recalled when resizing the UI
    private void adjustButtonSize()
    {
        this.transform.GetComponent<RectTransform>().sizeDelta = new Vector3(_buttonSize, _buttonSize, 0f);
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
