using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFactory
{
    public static GameObject roundButtonPrefab = (GameObject)Resources.Load("UI/Prefabs/RoundButton", typeof(GameObject));
    public static GameObject roundButtonsMenuPrefab = (GameObject)Resources.Load("UI/Prefabs/RoundButtonsMenu", typeof(GameObject));
    public static GameObject squareButtonsMenuPrefab = (GameObject)Resources.Load("UI/Prefabs/SquareButtonsMenu", typeof(GameObject));
    public static GameObject mainRoundButtonsMenuPrefab = (GameObject)Resources.Load("UI/Prefabs/RoundButtonsMainMenu", typeof(GameObject));

    public static GameObject CreateRoundButton(GameObject parent, ColorProvider.Department departmentColor, float buttonSize, float buttonHeight, float bezelWidth, float bezelHeight)
    {
        GameObject go = MonoBehaviour.Instantiate(roundButtonPrefab, parent.transform);

        RoundButtonController buttonController = go.transform.GetComponent<RoundButtonController>();
        buttonController.DepartmentColor = departmentColor;
        buttonController.ButtonSize = buttonSize;
        buttonController.ButtonHeight = buttonHeight;
        buttonController.BezelWidth = bezelWidth;
        buttonController.BezelHeight = bezelHeight;

        return go;
    }

    public static GameObject CreateRoundButtonsMenu(GameObject parent, ColorProvider.Department departmentColor, int buttonsCount,  float buttonSize, float buttonHeight, float buttonSpacing, 
        float toplineBezelHeight, float bezelHeight, bool isExclusive)
    {
        GameObject go = MonoBehaviour.Instantiate(roundButtonsMenuPrefab, parent.transform);

        go.transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);

        RoundButtonsMenuController buttonsMenuController = go.transform.GetComponent<RoundButtonsMenuController>();
        buttonsMenuController.ButtonsCount = buttonsCount;
        buttonsMenuController.ButtonSize = buttonSize;
        buttonsMenuController.ButtonHeight = buttonHeight;
        buttonsMenuController.ButtonSpacing = buttonSpacing;
        buttonsMenuController.ToplineBezelHeight = toplineBezelHeight;
        buttonsMenuController.BezelHeight = bezelHeight;
        buttonsMenuController.DepartmentColor = departmentColor;
        buttonsMenuController.IsExclusive = isExclusive;

        return go;
    }

    public static GameObject CreateSquareButtonsMenu(GameObject parent, ColorProvider.Department departmentColor, int buttonsCount, float buttonSize, float buttonHeight,
    float toplineBezelHeight, float bezelHeight, float faceBorderSize, bool isExclusive)
    {
        GameObject go = MonoBehaviour.Instantiate(squareButtonsMenuPrefab, parent.transform);

        go.transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);

        SquareButtonsMenuController buttonsMenuController = go.transform.GetComponent<SquareButtonsMenuController>();
        buttonsMenuController.ButtonsCount = buttonsCount;
        buttonsMenuController.ButtonSize = buttonSize;
        buttonsMenuController.ButtonHeight = buttonHeight;
        buttonsMenuController.ToplineBezelHeight = toplineBezelHeight;
        buttonsMenuController.BezelHeight = bezelHeight;
        buttonsMenuController.FaceBorderSize = faceBorderSize;
        buttonsMenuController.DepartmentColor = departmentColor;
        buttonsMenuController.IsExclusive = isExclusive;

        return go;
    }

    public static GameObject CreateMainRoundButtonsMenu(GameObject parent, ColorProvider.Department departmentColor, int buttonsCount, float buttonSize, float buttonHeight, float buttonSpacing,
    float toplineBezelHeight, float bezelHeight, bool isExclusive)
    {
        GameObject go = MonoBehaviour.Instantiate(mainRoundButtonsMenuPrefab, parent.transform);

        go.transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);

        RoundButtonsMainMenuController buttonsMenuController = go.transform.GetComponent<RoundButtonsMainMenuController>();
        buttonsMenuController.ButtonsCount = buttonsCount;
        buttonsMenuController.ButtonSize = buttonSize;
        buttonsMenuController.ButtonHeight = buttonHeight;
        buttonsMenuController.ButtonSpacing = buttonSpacing;
        buttonsMenuController.ToplineBezelHeight = toplineBezelHeight;
        buttonsMenuController.BezelHeight = bezelHeight;
        buttonsMenuController.DepartmentColor = departmentColor;
        buttonsMenuController.IsExclusive = isExclusive;

        return go;
    }

    public static void ReadjustRoundButtonSizeParameters(GameObject gameObject, float buttonSize, float buttonHeight, float bezelWidth, float bezelHeight)
    {
        RoundButtonController buttonController = gameObject.transform.GetComponent<RoundButtonController>();
        buttonController.ButtonSize = buttonSize;
        buttonController.ButtonHeight = buttonHeight;
        buttonController.BezelWidth = bezelWidth;
        buttonController.BezelHeight = bezelHeight;
    }

    public static void ReadjustRoundButtonsMenuSizeParameters(GameObject gameObject, float buttonSize, float buttonHeight, float buttonSpacing, float toplineBezelHeight, float bezelHeight)
    {
        RoundButtonsMenuController buttonsMenuController = gameObject.transform.GetComponent<RoundButtonsMenuController>();
        buttonsMenuController.ButtonSize = buttonSize;
        buttonsMenuController.ButtonHeight = buttonHeight;
        buttonsMenuController.ButtonSpacing = buttonSpacing;
        buttonsMenuController.ToplineBezelHeight = toplineBezelHeight;
        buttonsMenuController.BezelHeight = bezelHeight;
    }

    public static void ReadjustSquareButtonsMenuParameters(GameObject gameObject, float buttonSize, float buttonHeight, float toplineBezelHeight, float bezelHeight)
    {
        SquareButtonsMenuController buttonsMenuController = gameObject.transform.GetComponent<SquareButtonsMenuController>();
        buttonsMenuController.ButtonSize = buttonSize;
        buttonsMenuController.ButtonHeight = buttonHeight;
        buttonsMenuController.ToplineBezelHeight = toplineBezelHeight;
        buttonsMenuController.BezelHeight = bezelHeight;
    }

    public static void ReadjustMainRoundButtonsMenuSizeParameters(GameObject gameObject, float buttonSize, float buttonHeight, float buttonSpacing, float toplineBezelHeight, float bezelHeight)
    {
        RoundButtonsMainMenuController buttonsMenuController = gameObject.transform.GetComponent<RoundButtonsMainMenuController>();
        buttonsMenuController.ButtonSize = buttonSize;
        buttonsMenuController.ButtonHeight = buttonHeight;
        buttonsMenuController.ButtonSpacing = buttonSpacing;
        buttonsMenuController.ToplineBezelHeight = toplineBezelHeight;
        buttonsMenuController.BezelHeight = bezelHeight;
    }
}
