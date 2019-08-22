﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class SquareScrollButtonController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Action SelectCallback;
    public Action UnselectCallback;

    private bool _isSelected = false;
    public bool IsSelected { get => _isSelected; }

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


    private Vector3 buttonNotPressedHeight;
    private Vector3 buttonPressedHeight;

    private Color faceColor;
    private Color functionColor;
    private Color shadowColor;
    private Color functionHighlightColor = Color.white;

    private Transform faceTransform;
    private Transform shadowTransform;
    private Transform functionBackgroundTransform;
    private Transform functionTransform;
    private Transform infoBoxTransform;



    // Start is called before the first frame update
    void Start()
    {
        InitTransformMembers();
        infoBoxTransform.gameObject.SetActive(false);

        //TODO remove testing
        //DepartmentColor = ColorProvider.Department.ACCOUNTING;
        //ButtonSize = 50f;
        //ButtonHeight = 5f;
        //FaceBorderSize = 10f;
    }

    //TODO: Optimize if needed
    public void OnPointerEnter(PointerEventData eventData)
    {
        infoBoxTransform.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        infoBoxTransform.gameObject.SetActive(false);
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (_isSelected)
            {
                this.Unselect();
            }
            else
            {
                this.Select();
            }
        }
    }

    public void Select()
    {
        if (!_isSelected)
        {
            Press();
            SelectCallback();
        }
    }

    public void Unselect()
    {
        if (_isSelected)
        {
            Unpress();
            UnselectCallback();
        }
    }

    public void Press()
    {
        functionTransform.GetComponent<Image>().color = functionHighlightColor;
        faceTransform.GetComponent<RectTransform>().localPosition = buttonPressedHeight;
        _isSelected = true;
    }

    public void Unpress()
    {
        functionTransform.GetComponent<Image>().color = functionColor;
        faceTransform.GetComponent<RectTransform>().localPosition = buttonNotPressedHeight;
        _isSelected = false;
    }

    private void InitTransformMembers()
    {
        faceTransform = this.transform.Find("Face");
        shadowTransform = this.transform;
        functionTransform = this.transform.Find("Face").Find("Function");
        infoBoxTransform = this.transform.Find("InfoBox");
    }

    private void adjustButtonHeight()
    {
        InitTransformMembers();
        buttonNotPressedHeight = new Vector3(0f, _buttonHeight, 0f);
        buttonPressedHeight = new Vector3(0f, 0f, 0f);
        faceTransform.GetComponent<RectTransform>().localPosition = buttonNotPressedHeight;
        infoBoxTransform.GetComponent<RectTransform>().anchoredPosition = new Vector3(0f, _buttonHeight, 0f);
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
        infoBoxTransform.GetComponent<Image>().color = ColorProvider.GetBezelColorFromHex(ColorProvider.COLORHEXCODE_PRIMARYBEZELS);
    }

    //This should always be recalled when resizing the UI
    private void adjustButtonSize()
    {
        InitTransformMembers();
        shadowTransform.GetComponent<RectTransform>().sizeDelta = new Vector3(_buttonSize/4, _buttonSize, 0f);
        infoBoxTransform.GetComponent<RectTransform>().sizeDelta = new Vector3(_buttonSize, _buttonSize, 0f);
    }


}