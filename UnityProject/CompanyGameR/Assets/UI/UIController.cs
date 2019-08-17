using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    static public float UIScale = 1f;

    static private float buttonHeight = 10f;

    private const float ReferenceSize = 128f;

    static public float ButtonHeight { get => buttonHeight; }

    // Start is called before the first frame update
    void Start()
    {
        float UISize = UIScale * ReferenceSize;
        Transform bottomBezel = this.transform.Find("BottomBezel");
        //bottomBezel.GetComponent<RectTransform>().sizeDelta = new Vector2(0f, UISize);
        buttonHeight = 3f;
       // bottomBezel.GetComponent<Image>().color = ColorProvider.GetBezelColorFromHex(ColorProvider.COLORHEXCODE_CONSTRUCTION);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
