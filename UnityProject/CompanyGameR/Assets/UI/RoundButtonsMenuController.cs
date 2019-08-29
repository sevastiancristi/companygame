using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundButtonsMenuController : MonoBehaviour
{
    public GameObject buttonGameObjectPrefab;
    public List<GameObject> buttonsGameObjectList;

    private int _buttonsCount = 0;
    public int ButtonsCount
    {
        get => _buttonsCount;
        set
        {
            adjustButtonsCount(value);
            _buttonsCount = value;
        }
    }

    private float _buttonSize = 0f;
    public float ButtonSize
    {
        get => _buttonSize;
        set
        {
            _buttonSize = value;
            adjustButtonSize();
        }
    }

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

    private bool _isExclusive = false;
    public bool IsExclusive
    {
        get => _isExclusive;
        set
        {
            if (_isExclusive == true)
            {
                Debug.LogError("Already set to exclusive!");
                return;
            }

            if (value == false)
                return;

            setExclusive();
        }
    }

    private Transform bezelTransform;
    private Transform leftFadingBezelTransform;
    private Transform rightFadingBezelTransform;
    private Transform toplineBezelTransform;
    private Transform leftFadingToplineBezelTransform;
    private Transform rightFadingToplineBezelTransform;

    // Start is called before the first frame update
    void Start()
    {
        InitTransformMembers();
        buttonsGameObjectList = new List<GameObject>();
    }

    void InitTransformMembers()
    {
        bezelTransform = this.transform;
        leftFadingBezelTransform = this.transform.Find("LeftFadingBezel");
        rightFadingBezelTransform = this.transform.Find("RightFadingBezel");
        toplineBezelTransform = this.transform.Find("ToplineDisplayBezel");
        leftFadingToplineBezelTransform = this.transform.Find("ToplineDisplayBezel").Find("LeftFadingBezel");
        rightFadingToplineBezelTransform = this.transform.Find("ToplineDisplayBezel").Find("RightFadingBezel");
    }

    void adjustButtonsCount(int value)
    {
        if (_buttonsCount > 0)
        {
            Debug.LogError(this + ":\n ButtonsCount already set! Cannot set it twice!");
            return;
        }

        InitTransformMembers();

        for (int i=0; i< value; i++)
        {
            GameObject go = Instantiate(buttonGameObjectPrefab, new Vector3(i, 0f, 0f), Quaternion.identity, toplineBezelTransform);
            go.name = "Button_" + i;
            buttonsGameObjectList.Add(go);

            //TODO: Remove testing
            go.GetComponent<RoundButtonController>().SelectCallback += () => { Debug.Log(go.name + " Selected!"); };
            go.GetComponent<RoundButtonController>().UnselectCallback += () => { Debug.Log(go.name + " Unselected!"); };
        }
    }

    void adjustButtonSize()
    {
        if (_buttonsCount <= 0)
        {
            Debug.LogError(this + ":\n Buttons count must be set first!");
            return;
        }

        InitTransformMembers();

        for ( int i = 0; i < buttonsGameObjectList.Count; i++)
        {
            buttonsGameObjectList[i].GetComponent<RoundButtonController>().ButtonSize = _buttonSize;
        }
    }

    void adjustButtonSpacing()
    {
        if (_buttonsCount <= 0 || _buttonSize <= 0f)
        {
            Debug.LogError(this + ":\n Buttons count and size must be set first!");
            return;
        }

        InitTransformMembers();

        Vector3 bezelSize = bezelTransform.GetComponent<RectTransform>().sizeDelta;
        bezelSize.x = (_buttonsCount - 1) * _buttonSpacing + _buttonSize;
        bezelTransform.GetComponent<RectTransform>().sizeDelta = bezelSize;


        FadingBezelWidth = (_buttonSpacing - _buttonSize) / 2;
        for (int i = 0; i < buttonsGameObjectList.Count; i++)
        {
            buttonsGameObjectList[i].GetComponent<RectTransform>().anchoredPosition = new Vector3(_buttonSize/2 + i*_buttonSpacing, 0f, 0f);
        }
    }

    void adjustFadingBezelWidth()
    {
        if (_buttonsCount <= 0 || _buttonSize <= 0f || _buttonSpacing <= 0f)
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
        if (_buttonsCount <= 0)
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

    void adjustDepartmentColor()
    {

        if(_buttonsCount <= 0)
        {
            Debug.LogError(this + ":\n Buttons count must be set first!");
            return;
        }

        InitTransformMembers();

        bezelTransform.GetComponent<Image>().color = ColorProvider.GetBezelColorFromHex(ColorProvider.Colors[(int)_departmentColor][(int)ColorProvider.ColorType.FACE]);
        leftFadingBezelTransform.GetComponent<Image>().color = ColorProvider.GetBezelColorFromHex(ColorProvider.Colors[(int)_departmentColor][(int)ColorProvider.ColorType.FACE]);
        rightFadingBezelTransform.GetComponent<Image>().color = ColorProvider.GetBezelColorFromHex(ColorProvider.Colors[(int)_departmentColor][(int)ColorProvider.ColorType.FACE]);

        for (int i = 0; i < buttonsGameObjectList.Count; i++)
        {
            buttonsGameObjectList[i].GetComponent<RoundButtonController>().DepartmentColor = _departmentColor;
        }
    }

    void adjustButtonHeight()
    {
        if (_buttonsCount <= 0)
        {
            Debug.LogError(this + ":\n Buttons count must be set first!");
            return;
        }

        InitTransformMembers();

        for (int i = 0; i < buttonsGameObjectList.Count; i++)
        {
            buttonsGameObjectList[i].GetComponent<RoundButtonController>().ButtonHeight = _buttonHeight;
        }
    }

    void adjustBezelHeight()
    {
        InitTransformMembers();

        Vector3 bezelSize = bezelTransform.GetComponent<RectTransform>().sizeDelta;
        bezelSize.y = _bezelHeight;
        bezelTransform.GetComponent<RectTransform>().sizeDelta = bezelSize;
    }

    void setExclusive()
    {
        for(int i=0; i < buttonsGameObjectList.Count; i++)
        {
            List<RoundButtonController> altList = new List<RoundButtonController>();
            for(int j=0; j < buttonsGameObjectList.Count; j++)
            {
                if (j == i)
                    continue;
                altList.Add(buttonsGameObjectList[j].GetComponent<RoundButtonController>());
            }
            buttonsGameObjectList[i].transform.GetComponent<RoundButtonController>().SelectCallback += () => {
                for(int j=0; j < altList.Count; j++)
                {
                    if (altList[j].IsSelected)
                        altList[j].Unselect();
                }
            };
        }
    }

    private void exclusiveSelectCallback(List<RoundButtonController> buttonsList)
    {
        for (int j = 0; j < buttonsList.Count; j++)
        {
            if (buttonsList[j].IsSelected)
                buttonsList[j].Unselect();
        }
    }
}
