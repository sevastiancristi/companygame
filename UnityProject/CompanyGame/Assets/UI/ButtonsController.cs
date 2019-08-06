using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsController : MonoBehaviour
{

    public GameObject buttonPrefab;
    public int buttonsCount;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 thisSize = this.transform.GetComponent<RectTransform>().sizeDelta;
        Vector3 prefabPosition;
        prefabPosition.y = 0f;
        prefabPosition.z = 0f;
        float distanceBetweenButtons = (thisSize.x - thisSize.y*3f/4f) / (float)buttonsCount;

        for(int i = 0; i < buttonsCount; i++)
        {
            prefabPosition.x = thisSize.y * 3f / 4f + distanceBetweenButtons * (float)i;
            Debug.Log(prefabPosition);
            GameObject x = Instantiate(buttonPrefab,this.transform.GetComponent<RectTransform>().position, Quaternion.identity,this.transform);
            x.transform.GetComponent<RectTransform>().anchoredPosition = prefabPosition;
            x.transform.GetComponent<RectTransform>().sizeDelta = new Vector3(thisSize.y * 3f / 4f, thisSize.y * 3f / 4f, 0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
