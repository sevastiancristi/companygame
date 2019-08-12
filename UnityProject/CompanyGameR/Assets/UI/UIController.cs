using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public float UIScale = 1f;
    private const float ReferenceSize = 128f;

    // Start is called before the first frame update
    void Start()
    {
        float UISize = UIScale * ReferenceSize;
        Transform bottomBezel = this.transform.Find("BottomBezel");
        bottomBezel.GetComponent<RectTransform>().sizeDelta = new Vector2(0f, UISize);
        
        bottomBezel.GetComponent<Image>().color = ColorPool.getBezelColorFromHex(ColorPool.HEX_PRIMARYBEZELS);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
