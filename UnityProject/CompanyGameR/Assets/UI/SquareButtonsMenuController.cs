using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SquareButtonsMenuController : MonoBehaviour
{
    public GameObject buttonGameObjectPrefab;
    public GameObject leftSquareScrollButtonPrefab;
    public GameObject rightSquareScrollButtonPrefab;

    private GameObject leftScrollGameObject;
    private GameObject rightScrollGameObject;
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
        
        //TODO Remove testing
        /*
        ButtonsCount = 5;
        ButtonSize = 30f;
        ToplineBezelHeight = 2f;
        DepartmentColor = ColorProvider.Department.HUMANRESOURCES;
        ButtonHeight = 2f;
        FaceBorderSize = 5f;
        BezelHeight = 50f;
        HasScrollingButtons = true;
        IsExclusive = true;
        */

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

        leftScrollGameObject = Instantiate(leftSquareScrollButtonPrefab, new Vector3(0f, 0f, 0f), Quaternion.identity, toplineBezelTransform);
        rightScrollGameObject = Instantiate(rightSquareScrollButtonPrefab, new Vector3(0f, 0f, 0f), Quaternion.identity, toplineBezelTransform);

        //TODO: Remove testing!
        leftScrollGameObject.GetComponent<SquareScrollButtonController>().SelectCallback += () => { Debug.Log("Scrolling left!"); leftScrollGameObject.GetComponent<SquareScrollButtonController>().Unselect(); };
        leftScrollGameObject.GetComponent<SquareScrollButtonController>().UnselectCallback += () => { Debug.Log("Scrolling left done!"); };
        rightScrollGameObject.GetComponent<SquareScrollButtonController>().SelectCallback += () => { Debug.Log("Scrolling right!"); rightScrollGameObject.GetComponent<SquareScrollButtonController>().Unselect(); };
        rightScrollGameObject.GetComponent<SquareScrollButtonController>().UnselectCallback += () => { Debug.Log("Scrolling right done!"); };

        for (int i = 0; i < value; i++)
        {
            GameObject go = Instantiate(buttonGameObjectPrefab, new Vector3(i, 0f, 0f), Quaternion.identity, toplineBezelTransform);
            go.name = "Button_" + i;
            buttonsGameObjectList.Add(go);

            //TODO: Remove testing
            go.GetComponent<SquareButtonController>().SelectCallback += () => { Debug.Log(go.name + " Selected!"); };
            go.GetComponent<SquareButtonController>().UnselectCallback += () => { Debug.Log(go.name + " Unselected!"); };
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
        FadingBezelWidth = _buttonSize / 2;
        Vector3 bezelSize = bezelTransform.GetComponent<RectTransform>().sizeDelta;
        bezelSize.x = _buttonSize*_buttonsCount;
        bezelTransform.GetComponent<RectTransform>().sizeDelta = bezelSize;

        leftScrollGameObject.transform.GetComponent<SquareScrollButtonController>().ButtonSize = _buttonSize;
        rightScrollGameObject.transform.GetComponent<SquareScrollButtonController>().ButtonSize = _buttonSize;

        leftScrollGameObject.transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(0f, 0f, 0f);
        rightScrollGameObject.transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(0f, 0f, 0f);

        for (int i = 0; i < buttonsGameObjectList.Count; i++)
        {
            buttonsGameObjectList[i].GetComponent<SquareButtonController>().ButtonSize = _buttonSize;
            buttonsGameObjectList[i].GetComponent<RectTransform>().anchoredPosition =new Vector3(i*_buttonSize,0f,0f);
        }

    }


    void adjustFadingBezelWidth()
    {
        if (_buttonsCount <= 0 || _buttonSize <= 0f)
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
        if (_buttonsCount <= 0)
        {
            Debug.LogError(this + ":\n Buttons count must be set first!");
            return;
        }

        InitTransformMembers();

        Vector3 toplineBezelSize = toplineBezelTransform.GetComponent<RectTransform>().sizeDelta;
        toplineBezelSize.y = _toplineBezelHeight;
        toplineBezelTransform.GetComponent<RectTransform>().sizeDelta = toplineBezelSize;
    }

    void adjustDepartmentColor()
    {

        if (_buttonsCount <= 0)
        {
            Debug.LogError(this + ":\n Buttons count must be set first!");
            return;
        }

        InitTransformMembers();

        bezelTransform.GetComponent<Image>().color = ColorProvider.GetBezelColorFromHex(ColorProvider.Colors[(int)_departmentColor][(int)ColorProvider.ColorType.FACE]);
        leftFadingBezelTransform.GetComponent<Image>().color = ColorProvider.GetBezelColorFromHex(ColorProvider.Colors[(int)_departmentColor][(int)ColorProvider.ColorType.FACE]);
        rightFadingBezelTransform.GetComponent<Image>().color = ColorProvider.GetBezelColorFromHex(ColorProvider.Colors[(int)_departmentColor][(int)ColorProvider.ColorType.FACE]);

        leftScrollGameObject.transform.GetComponent<SquareScrollButtonController>().DepartmentColor = _departmentColor;
        rightScrollGameObject.transform.GetComponent<SquareScrollButtonController>().DepartmentColor = _departmentColor;

        for (int i = 0; i < buttonsGameObjectList.Count; i++)
        {
            buttonsGameObjectList[i].GetComponent<SquareButtonController>().DepartmentColor = _departmentColor;
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

        leftScrollGameObject.transform.GetComponent<SquareScrollButtonController>().ButtonHeight = _buttonHeight;
        rightScrollGameObject.transform.GetComponent<SquareScrollButtonController>().ButtonHeight = _buttonHeight;

        for (int i = 0; i < buttonsGameObjectList.Count; i++)
        {
            buttonsGameObjectList[i].GetComponent<SquareButtonController>().ButtonHeight = _buttonHeight;
        }
    }

    void adjustFaceBorderSize()
    {
        if(_buttonsCount <= 0 )
        {
            Debug.LogError(this + ":\n Buttons count must be set first!");
        }

        InitTransformMembers();

        for(int i = 0; i < buttonsGameObjectList.Count; i++)
        {
            buttonsGameObjectList[i].GetComponent<SquareButtonController>().FaceBorderSize = _faceBorderSize;
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
        for (int i = 0; i < buttonsGameObjectList.Count; i++)
        {
            List<SquareButtonController> altList = new List<SquareButtonController>();
            for (int j = 0; j < buttonsGameObjectList.Count; j++)
            {
                if (j == i)
                    continue;
                altList.Add(buttonsGameObjectList[j].GetComponent<SquareButtonController>());
            }
            buttonsGameObjectList[i].transform.GetComponent<SquareButtonController>().SelectCallback += () => {
                for (int j = 0; j < altList.Count; j++)
                {
                    if (altList[j].IsSelected)
                        altList[j].Unselect();
                }
            };
        }
    }

    void adjustScrollButons()
    {
        leftSquareScrollButtonPrefab.SetActive(_hasScrollingButtons);
        rightSquareScrollButtonPrefab.SetActive(_hasScrollingButtons);
    }
}
