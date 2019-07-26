using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PropInfoUICtrl : MonoBehaviour {

    private Text nameText;
    private Text effectText;

    private Canvas canvas;

    void Awake()
    {
        nameText = transform.Find("nameText").GetComponent<Text>();
        effectText = transform.Find("effectText").GetComponent<Text>();
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
    }

    public void SetPropInfo(InventoryItem item)
    {
        nameText.text = item.ItemName;
        effectText.text = item.Descr;
    }

    void Update()
    {
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.GetComponent<RectTransform>(), Input.mousePosition, null, out pos);
        transform.localPosition = pos + new Vector2(10, -10);
    }

}
