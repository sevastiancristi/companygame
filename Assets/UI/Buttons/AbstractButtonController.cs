using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class AbstractButtonController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
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

    protected abstract void InitTransformMembers();

    protected virtual void adjustDepartmentColor()
    {
        InitTransformMembers();
        faceColor = ColorProvider.GetColorFromHex(ColorProvider.Colors[(int)_departmentColor][(int)ColorProvider.ColorType.FACE]);
        functionColor = ColorProvider.GetColorFromHex(ColorProvider.Colors[(int)_departmentColor][(int)ColorProvider.ColorType.FUNCTION]);
        shadowColor = ColorProvider.GetColorFromHex(ColorProvider.Colors[(int)_departmentColor][(int)ColorProvider.ColorType.SHADOW]);
    }

    protected virtual void adjustButtonSize()
    {
        InitTransformMembers();
        shadowTransform.GetComponent<RectTransform>().sizeDelta = new Vector3(_buttonSize, _buttonSize, 0f);
        infoBoxTransform.GetComponent<RectTransform>().sizeDelta = new Vector3(_buttonSize * 2, _buttonSize, 0f);
    }

    protected virtual void adjustButtonHeight()
    {
        InitTransformMembers();
        buttonNotPressedHeight = new Vector3(0f, _buttonHeight, 0f);
        buttonPressedHeight = new Vector3(0f, 0f, 0f);
        faceTransform.GetComponent<RectTransform>().localPosition = buttonNotPressedHeight;
        infoBoxTransform.GetComponent<RectTransform>().anchoredPosition = new Vector3(0f, _buttonHeight, 0f);
    }

    protected Vector3 buttonNotPressedHeight;
    protected Vector3 buttonPressedHeight;

    protected Color faceColor;
    protected Color functionColor;
    protected Color shadowColor;
    protected Color functionHighlightColor = Color.white;

    protected Transform faceTransform;
    protected Transform shadowTransform;
    protected Transform functionTransform;
    protected Transform infoBoxTransform;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        InitTransformMembers();
        infoBoxTransform.gameObject.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        infoBoxTransform.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        infoBoxTransform.gameObject.SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData)
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
            _isSelected = true;
            SelectCallback();
        }
    }

    public void Unselect()
    {
        if (_isSelected)
        {
            Unpress();
            _isSelected = false;
            UnselectCallback();
        }
    }

    public abstract void Press();

    public abstract void Unpress();

    public void setFunctionSprite(Sprite sprite)
    {
        functionTransform.GetComponent<Image>().sprite = sprite;
    }

}
