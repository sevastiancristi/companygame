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
    public int MainMenuButtonsCount = 7;

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
        List<GameObject> goArray = new List<GameObject>(7);
        goArray.Add(BuildRoundButtonsMenu(go, 0, 6));
        goArray.Add(BuildRoundButtonsMenu(go, 1, 5));
        goArray.Add(BuildRoundButtonsMenu(go, 2, 4));
        goArray.Add(BuildRoundButtonsMenu(go, 3, 6));
        goArray.Add(BuildRoundButtonsMenu(go, 4, 3));
        goArray.Add(BuildRoundButtonsMenu(go, 5, 5));
        goArray.Add(BuildRoundButtonsMenu(go, 6, 5));
        int x = 0;
        for(int i = 0; i < goArray.Count; i++)
            for(int j = 0; j < goArray[i].GetComponent<RoundButtonsMenuController>().ButtonsCount; j++)
                goArray[i].transform.GetComponent<RoundButtonsMenuController>().buttonsGameObjectList[j].transform.GetComponent<RoundButtonController>().setFunctionSprite(SpritesPackage.Instance.getSpriteFromMulti("UI/Sprites/BusinessIcon","BusinessIcon_"+((int)(x++)).ToString()));
        BuildSquareButtonsMenu(goArray[0], 0);
        //BuildSquareButtonsMenu(go_0, 5);
        //BuildSquareButtonsMenu(go_0, 2);
        BuildSquareButtonsMenu(goArray[1], 0);
        //BuildSquareButtonsMenu(go_1, 2);
        BuildSquareButtonsMenu(goArray[5], 3);
    }

    public GameObject BuildMainRoundButtonsMenu()
    {
        GameObject go =  UIFactory.CreateMainRoundButtonsMenu(this.transform.gameObject, 
            ColorProvider.Department.RESEARCHANDDEVELOPMENT, MainMenuButtonsCount, 
            ButtonSize, ButtonHeight, ButtonSpacing, ToplineDisplayBezelHeight, BezelHeight, true);
        go.transform.Find("ToplineBezel").Find("ToplineDisplayBezel").GetComponent<RectTransform>().anchoredPosition = new Vector3(
            (this.transform.gameObject.GetComponent<RectTransform>().sizeDelta.x - (ButtonSpacing * (MainMenuButtonsCount-1) + ButtonSize))/2 , 0f, 0f);
        go.transform.GetComponent<Image>().color = ColorProvider.GetBezelColorFromHex(ColorProvider.COLORHEXCODE_PRIMARYBEZELS);
        go.transform.GetComponent<RoundButtonsMainMenuController>().buttonsGameObjectList[0].transform.GetComponent<RoundButtonController>().DepartmentColor = ColorProvider.Department.HUMANRESOURCES;
        go.transform.GetComponent<RoundButtonsMainMenuController>().buttonsGameObjectList[0].transform.GetComponent<RoundButtonController>().setFunctionSprite(SpritesPackage.Instance.getSpriteFor(SpritesPackage.Department.HUMANRESOURCES));
        go.transform.GetComponent<RoundButtonsMainMenuController>().buttonsGameObjectList[1].transform.GetComponent<RoundButtonController>().DepartmentColor = ColorProvider.Department.ACCOUNTING;
        go.transform.GetComponent<RoundButtonsMainMenuController>().buttonsGameObjectList[1].transform.GetComponent<RoundButtonController>().setFunctionSprite(SpritesPackage.Instance.getSpriteFor(SpritesPackage.Department.ACCOUNTING));
        go.transform.GetComponent<RoundButtonsMainMenuController>().buttonsGameObjectList[2].transform.GetComponent<RoundButtonController>().DepartmentColor = ColorProvider.Department.SALESANDMARKETING;
        go.transform.GetComponent<RoundButtonsMainMenuController>().buttonsGameObjectList[2].transform.GetComponent<RoundButtonController>().setFunctionSprite(SpritesPackage.Instance.getSpriteFor(SpritesPackage.Department.SALESANDMARKETING));
        go.transform.GetComponent<RoundButtonsMainMenuController>().buttonsGameObjectList[3].transform.GetComponent<RoundButtonController>().DepartmentColor = ColorProvider.Department.INFORMATINOTECHNOLOGY;
        go.transform.GetComponent<RoundButtonsMainMenuController>().buttonsGameObjectList[3].transform.GetComponent<RoundButtonController>().setFunctionSprite(SpritesPackage.Instance.getSpriteFor(SpritesPackage.Department.INFORMATINOTECHNOLOGY));
        go.transform.GetComponent<RoundButtonsMainMenuController>().buttonsGameObjectList[4].transform.GetComponent<RoundButtonController>().DepartmentColor = ColorProvider.Department.LOGISTICS;
        go.transform.GetComponent<RoundButtonsMainMenuController>().buttonsGameObjectList[4].transform.GetComponent<RoundButtonController>().setFunctionSprite(SpritesPackage.Instance.getSpriteFor(SpritesPackage.Department.LOGISTICS));
        go.transform.GetComponent<RoundButtonsMainMenuController>().buttonsGameObjectList[5].transform.GetComponent<RoundButtonController>().DepartmentColor = ColorProvider.Department.PROCUREMENT;
        go.transform.GetComponent<RoundButtonsMainMenuController>().buttonsGameObjectList[5].transform.GetComponent<RoundButtonController>().setFunctionSprite(SpritesPackage.Instance.getSpriteFor(SpritesPackage.Department.PROCUREMENT));
        go.transform.GetComponent<RoundButtonsMainMenuController>().buttonsGameObjectList[6].transform.GetComponent<RoundButtonController>().DepartmentColor = ColorProvider.Department.RESEARCHANDDEVELOPMENT;
        go.transform.GetComponent<RoundButtonsMainMenuController>().buttonsGameObjectList[6].transform.GetComponent<RoundButtonController>().setFunctionSprite(SpritesPackage.Instance.getSpriteFor(SpritesPackage.Department.RESEARCHANDDEVELOPMENT));
        return go;
    }

    public GameObject BuildRoundButtonsMenu(GameObject parent, int parentButtonIndex, int buttonsCount)
    {
        if (parent.transform.GetComponent<RoundButtonsMainMenuController>() != null)
        {
            GameObject go = UIFactory.CreateRoundButtonsMenu(parent, parent.transform.GetComponent<RoundButtonsMainMenuController>().buttonsGameObjectList[parentButtonIndex].transform.GetComponent<RoundButtonController>().DepartmentColor, buttonsCount,
                ButtonSize, ButtonHeight, ButtonSpacing, ToplineDisplayBezelHeight, BezelHeight, true);
            go.SetActive(false);
            float startingAnchoredPosition = parent.transform.Find("ToplineBezel").Find("ToplineDisplayBezel").GetComponent<RectTransform>().anchoredPosition.x;
                //(parent.transform.parent.gameObject.GetComponent<RectTransform>().sizeDelta.x -
                //parent.transform.Find("ToplineBezel").Find("ToplineDisplayBezel").GetComponent<RectTransform>().sizeDelta.x)/ 2;

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
            while (lParent.transform.GetComponent<RoundButtonsMenuController>() != null ||
                   lParent.transform.GetComponent<RoundButtonsMainMenuController>() != null)
            {
                if (lParent.transform.GetComponent<RoundButtonsMainMenuController>() != null)
                    lParent.transform.Find("ToplineBezel").Find("ToplineDisplayBezel").GetComponent<Canvas>().sortingOrder++;
                else
                    lParent.transform.Find("ToplineDisplayBezel").GetComponent<Canvas>().sortingOrder++;
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
        while (lParent.transform.GetComponent<RoundButtonsMenuController>() != null ||
               lParent.transform.GetComponent<RoundButtonsMainMenuController>() != null)
        {
            if (lParent.transform.GetComponent<RoundButtonsMainMenuController>() != null)
                lParent.transform.Find("ToplineBezel").Find("ToplineDisplayBezel").GetComponent<Canvas>().sortingOrder++;
            else
                lParent.transform.Find("ToplineDisplayBezel").GetComponent<Canvas>().sortingOrder++;
            lParent = lParent.transform.parent.gameObject;
        }

        return go;
    }
}
