using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public float UIScale = 1f;

    public float ButtonSize = 40f;
    public float ButtonHeight = 2f;
    public float ButtonSpacing = 100f;
    public float ToplineDisplayBezelHeight = 2f;
    public float BezelHeight = 40f;
    public int MainMenuButtonsCount = 6;

    private const float ReferenceSize = 128f;

    // Start is called before the first frame update
    void Start()
    {
        float UISize = UIScale * ReferenceSize;
        // Transform bottomBezel = this.transform.Find("BottomBezel");
        //bottomBezel.GetComponent<RectTransform>().sizeDelta = new Vector2(0f, UISize);
        //UIFactory.CreateRoundButton(this.transform.Find("BottomBezel").gameObject, ColorProvider.Department.ACCOUNTING, 50f, 5f, 25f, 25f);
        //GameObject go = UIFactory.CreateMainRoundButtonsMenu(this.transform.gameObject, ColorProvider.Department.RESEARCHANDDEVELOPMENT, 8, 50f, 2f, 100f, 2f, 50f,true);
        //go.transform.Find("ToplineBezel").Find("ToplineDisplayBezel").GetComponent<Canvas>().sortingOrder++;
        //GameObject go2 = UIFactory.CreateRoundButtonsMenu(go, ColorProvider.Department.RESEARCHANDDEVELOPMENT, 7, 50f, 2f, 100f, 2f, 50f,true);
        //go2.transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(0f, 0f, 0f);
        //go2.SetActive(false);
        //go.transform.GetComponent<RoundButtonsMainMenuController>().buttonsGameObjectList[0].transform.GetComponent<RoundButtonController>().SelectCallback += () => { go2.SetActive(true); };
        //go.transform.GetComponent<RoundButtonsMainMenuController>().buttonsGameObjectList[0].transform.GetComponent<RoundButtonController>().UnselectCallback += () => { go2.SetActive(false); };
        // bottomBezel.GetComponent<Image>().color = ColorProvider.GetBezelColorFromHex(ColorProvider.COLORHEXCODE_CONSTRUCTION);
        GameObject go = BuildMainRoundButtonsMenu();
        GameObject go_0 = BuildRoundButtonsMenu(go, 0, 8);
        GameObject go_1 = BuildRoundButtonsMenu(go, 1, 5);
        GameObject go_2 = BuildRoundButtonsMenu(go, 2, 4);
        GameObject go_3 = BuildRoundButtonsMenu(go, 3, 6);
        GameObject go_4 = BuildRoundButtonsMenu(go, 4, 3);
        GameObject go_5 = BuildRoundButtonsMenu(go, 5, 5);
        BuildSquareButtonsMenu(go_0, 0);
        //BuildSquareButtonsMenu(go_0, 5);
        //BuildSquareButtonsMenu(go_0, 2);
        BuildSquareButtonsMenu(go_1, 0);
        //BuildSquareButtonsMenu(go_1, 2);
        BuildSquareButtonsMenu(go_5, 3);
    }

    public GameObject BuildMainRoundButtonsMenu()
    {
        GameObject go =  UIFactory.CreateMainRoundButtonsMenu(this.transform.gameObject, 
            ColorProvider.Department.RESEARCHANDDEVELOPMENT, MainMenuButtonsCount, 
            ButtonSize, ButtonHeight, ButtonSpacing, ToplineDisplayBezelHeight, BezelHeight, true);
        go.transform.GetComponent<Image>().color = ColorProvider.GetBezelColorFromHex(ColorProvider.COLORHEXCODE_PRIMARYBEZELS);
        go.transform.GetComponent<RoundButtonsMainMenuController>().buttonsGameObjectList[0].transform.GetComponent<RoundButtonController>().DepartmentColor = ColorProvider.Department.HUMANRESOURCES;
        go.transform.GetComponent<RoundButtonsMainMenuController>().buttonsGameObjectList[1].transform.GetComponent<RoundButtonController>().DepartmentColor = ColorProvider.Department.CONSTRUCTION;
        go.transform.GetComponent<RoundButtonsMainMenuController>().buttonsGameObjectList[2].transform.GetComponent<RoundButtonController>().DepartmentColor = ColorProvider.Department.SALESANDMARKETING;
        go.transform.GetComponent<RoundButtonsMainMenuController>().buttonsGameObjectList[3].transform.GetComponent<RoundButtonController>().DepartmentColor = ColorProvider.Department.INFORMATINOTECHNOLOGY;
        go.transform.GetComponent<RoundButtonsMainMenuController>().buttonsGameObjectList[4].transform.GetComponent<RoundButtonController>().DepartmentColor = ColorProvider.Department.LOGISTICS;
        go.transform.GetComponent<RoundButtonsMainMenuController>().buttonsGameObjectList[5].transform.GetComponent<RoundButtonController>().DepartmentColor = ColorProvider.Department.PROCUREMENT;
        return go;

    }

    public GameObject BuildRoundButtonsMenu(GameObject parent, int parentButtonIndex, int buttonsCount)
    {
        if (parent.transform.GetComponent<RoundButtonsMainMenuController>() != null)
        {
            GameObject go = UIFactory.CreateRoundButtonsMenu(parent, parent.transform.GetComponent<RoundButtonsMainMenuController>().buttonsGameObjectList[parentButtonIndex].transform.GetComponent<RoundButtonController>().DepartmentColor, buttonsCount,
                ButtonSize, ButtonHeight, ButtonSpacing, ToplineDisplayBezelHeight, BezelHeight, true);
            go.SetActive(false);
            float startingAnchoredPosition = (parent.transform.parent.gameObject.GetComponent<RectTransform>().sizeDelta.x -
                parent.transform.Find("ToplineBezel").Find("ToplineDisplayBezel").GetComponent<RectTransform>().sizeDelta.x)/ 2;

            //if()
            int startIndex = parentButtonIndex - (MainMenuButtonsCount - buttonsCount) / 2 - 1;
            int endIndex = startIndex + buttonsCount;
            if (parentButtonIndex > (MainMenuButtonsCount - 1) / 2 )
            {
                while (endIndex >= MainMenuButtonsCount)
                {
                    startIndex--;
                    endIndex--;
                }
                while (startIndex < 0)
                {
                    startIndex++;
                    endIndex++;
                }
            }
            else
            {
                while (startIndex < 0)
                {
                    startIndex++;
                    endIndex++;
                }
                while (endIndex >= MainMenuButtonsCount)
                {
                    startIndex--;
                    endIndex--;
                }
            }
            go.transform.GetComponent<RectTransform>().anchoredPosition = new Vector3( startingAnchoredPosition + ButtonSpacing/2 + startIndex * ButtonSpacing,0f,0f);

            parent.transform.GetComponent<RoundButtonsMainMenuController>().buttonsGameObjectList[parentButtonIndex].transform.GetComponent<RoundButtonController>().SelectCallback += () => { go.SetActive(true); };
            parent.transform.GetComponent<RoundButtonsMainMenuController>().buttonsGameObjectList[parentButtonIndex].transform.GetComponent<RoundButtonController>().UnselectCallback += () => { go.SetActive(false); };
            
            GameObject lParent = parent;
            while (lParent.transform.GetComponent<RoundButtonsMenuController>() != null ||
                   lParent.transform.GetComponent<RoundButtonsMainMenuController>() != null)
            {
                if(lParent.transform.GetComponent<RoundButtonsMainMenuController>() != null)
                    lParent.transform.Find("ToplineBezel").Find("ToplineDisplayBezel").GetComponent<Canvas>().sortingOrder++;
                else
                    lParent.transform.Find("ToplineDisplayBezel").GetComponent<Canvas>().sortingOrder++;
                lParent = lParent.transform.parent.gameObject;
            }

            return go;
        }
        else if (parent.transform.GetComponent<RoundButtonsMenuController>())
        {
            GameObject go = UIFactory.CreateRoundButtonsMenu(parent, parent.transform.GetComponent<RoundButtonsMenuController>().buttonsGameObjectList[parentButtonIndex].transform.GetComponent<RoundButtonController>().DepartmentColor, buttonsCount,
                ButtonSize, ButtonHeight, ButtonSpacing, ToplineDisplayBezelHeight, BezelHeight, true);
            go.SetActive(false);

            parent.transform.GetComponent<RoundButtonsMenuController>().buttonsGameObjectList[parentButtonIndex].transform.GetComponent<RoundButtonController>().SelectCallback += () => { go.SetActive(true); };
            parent.transform.GetComponent<RoundButtonsMenuController>().buttonsGameObjectList[parentButtonIndex].transform.GetComponent<RoundButtonController>().UnselectCallback += () => { go.SetActive(false); };

            GameObject lParent = parent;
            while (lParent.transform.GetComponent<RoundButtonController>() != null)
            {
                lParent.transform.Find("ToplineBezel").Find("ToplineDisplayBezel").GetComponent<Canvas>().sortingOrder++;
                lParent = lParent.transform.parent.gameObject;
            }

            return go;
        }
        else
            return null;
    }

    public GameObject BuildSquareButtonsMenu(GameObject parent, int parentButtonIndex )
    {
        int buttonsCount = (int)(parent.transform.GetComponent<RectTransform>().sizeDelta.x / ButtonSize);
        GameObject go = UIFactory.CreateSquareButtonsMenu(parent, parent.transform.GetComponent<RoundButtonsMenuController>().buttonsGameObjectList[parentButtonIndex].transform.GetComponent<RoundButtonController>().DepartmentColor, buttonsCount,
             ButtonSize, ButtonHeight, ToplineDisplayBezelHeight, BezelHeight, ButtonHeight, true);
        go.SetActive(false);

        parent.transform.GetComponent<RoundButtonsMenuController>().buttonsGameObjectList[parentButtonIndex].transform.GetComponent<RoundButtonController>().SelectCallback += () => { go.SetActive(true); };
        parent.transform.GetComponent<RoundButtonsMenuController>().buttonsGameObjectList[parentButtonIndex].transform.GetComponent<RoundButtonController>().UnselectCallback += () => { go.SetActive(false); };

        GameObject lParent = parent;
        while (lParent.transform.GetComponent<RoundButtonController>() != null)
        {
            lParent.transform.Find("ToplineBezel").Find("ToplineDisplayBezel").GetComponent<Canvas>().sortingOrder++;
            lParent = lParent.transform.parent.gameObject;
        }

        return go;
    }
}
