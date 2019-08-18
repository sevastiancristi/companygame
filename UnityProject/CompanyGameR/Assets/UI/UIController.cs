using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    static public float UIScale = 1f;

    private const float ReferenceSize = 128f;

    // Start is called before the first frame update
    void Start()
    {
        float UISize = UIScale * ReferenceSize;
       // Transform bottomBezel = this.transform.Find("BottomBezel");
        //bottomBezel.GetComponent<RectTransform>().sizeDelta = new Vector2(0f, UISize);
        //UIFactory.CreateRoundButton(this.transform.Find("BottomBezel").gameObject, ColorProvider.Department.ACCOUNTING, 50f, 5f, 25f, 25f);
        GameObject go = UIFactory.CreateMainRoundButtonsMenu(this.transform.gameObject, ColorProvider.Department.RESEARCHANDDEVELOPMENT, 8, 50f, 2f, 100f, 2f, 50f,true);
        go.transform.Find("ToplineBezel").Find("ToplineDisplayBezel").GetComponent<Canvas>().sortingOrder++;
        GameObject go2 = UIFactory.CreateRoundButtonsMenu(go, ColorProvider.Department.RESEARCHANDDEVELOPMENT, 7, 50f, 2f, 100f, 2f, 50f,true);
        go2.transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(0f, 0f, 0f);
        go2.SetActive(false);
        go.transform.GetComponent<RoundButtonsMainMenuController>().buttonsGameObjectList[0].transform.GetComponent<RoundButtonController>().SelectCallback += () => { go2.SetActive(true); };
        go.transform.GetComponent<RoundButtonsMainMenuController>().buttonsGameObjectList[0].transform.GetComponent<RoundButtonController>().UnselectCallback += () => { go2.SetActive(false); };
       // bottomBezel.GetComponent<Image>().color = ColorProvider.GetBezelColorFromHex(ColorProvider.COLORHEXCODE_CONSTRUCTION);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
