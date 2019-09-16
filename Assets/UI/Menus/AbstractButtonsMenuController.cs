using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class AbstractButtonsMenuController : MonoBehaviour
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

    private float _buttonHeight = 0f;
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

    protected abstract void InitTransformMembers();

    protected virtual void adjustButtonsCount(int value)
    {
        if (_buttonsCount > 0)
        {
            Debug.LogError(this + ":\n ButtonsCount already set! Cannot set it twice!");
            return;
        }

        InitTransformMembers();

        for (int i = 0; i < value; i++)
        {
            GameObject go = Instantiate(buttonGameObjectPrefab, new Vector3(0f, 0f, 0f), Quaternion.identity, toplineDisplayBezelTransform);
            go.name = "Button_" + i;
            buttonsGameObjectList.Add(go);

            //TODO: Remove testing
            go.GetComponent<AbstractButtonController>().SelectCallback += () => { Debug.Log(go.name + " Selected!"); };
            go.GetComponent<AbstractButtonController>().UnselectCallback += () => { Debug.Log(go.name + " Unselected!"); };
        }
    }

    protected virtual void adjustDepartmentColor()
    {
        if (_buttonsCount <= 0)
        {
            Debug.LogError(this + ":\n Buttons count must be set first!");
            return;
        }

        for (int i = 0; i < buttonsGameObjectList.Count; i++)
        {
            buttonsGameObjectList[i].GetComponent<AbstractButtonController>().DepartmentColor = _departmentColor;
        }
    }

    protected virtual void adjustButtonSize()
    {
        if (_buttonsCount <= 0)
        {
            Debug.LogError(this + ":\n Buttons count must be set first!");
            return;
        }

        for (int i = 0; i < buttonsGameObjectList.Count; i++)
        {
            buttonsGameObjectList[i].GetComponent<AbstractButtonController>().ButtonSize = _buttonSize;
        }
    }

    protected virtual void adjustButtonHeight()
    {
        if (_buttonsCount <= 0)
        {
            Debug.LogError(this + ":\n Buttons count must be set first!");
            return;
        }

        for (int i = 0; i < buttonsGameObjectList.Count; i++)
        {
            buttonsGameObjectList[i].GetComponent<AbstractButtonController>().ButtonHeight = _buttonHeight;
        }
    }

    protected virtual void adjustBezelHeight()
    {
        InitTransformMembers();

        Vector3 bezelSize = bezelTransform.GetComponent<RectTransform>().sizeDelta;
        bezelSize.y = _bezelHeight;
        bezelTransform.GetComponent<RectTransform>().sizeDelta = bezelSize;
    }

    protected virtual void setExclusive()
    {
        for (int i = 0; i < buttonsGameObjectList.Count; i++)
        {
            List<AbstractButtonController> altList = new List<AbstractButtonController>();
            for (int j = 0; j < buttonsGameObjectList.Count; j++)
            {
                if (j == i)
                    continue;
                altList.Add(buttonsGameObjectList[j].GetComponent<AbstractButtonController>());
            }
            buttonsGameObjectList[i].transform.GetComponent<AbstractButtonController>().SelectCallback += () => {
                for (int j = 0; j < altList.Count; j++)
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

    protected Transform bezelTransform;
    protected Transform toplineDisplayBezelTransform;

    protected virtual void Start()
    {
        InitTransformMembers();
        buttonsGameObjectList = new List<GameObject>();
    }


    protected abstract void rearrangeTransformMembers();

    public void removeButtonAtIndex(int i)
    {
        if (i >= buttonsGameObjectList.Count)
        {
            Debug.LogError("AddButonError: Index greater than buttons list size!");
            return;
        }

        Destroy(buttonsGameObjectList[i]);
        buttonsGameObjectList.RemoveAt(i);
        _buttonsCount--;

        rearrangeTransformMembers();
    }

}
