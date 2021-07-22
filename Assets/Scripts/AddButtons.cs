using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddButtons : MonoBehaviour
{
    public GameObject prefabButton;
    public GameObject TopSide;
    public GameObject BottomSide;
    public Sprite[] spriteList;
    public int ButtonSayisi;
    public bool isShadow;
    public GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        AddOrderedButtons(BottomSide,isShadow);
        isShadow = true;
        AddOrderedButtons(TopSide,isShadow);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //public void Control(GameObject Tiklanan)
    //{

    //}
    
    public void AddOrderedButtons(GameObject parentObj, bool isShadow)
    {
        //Objelerin sırasını değiştir
        for (int t = 0; t < spriteList.Length; t++)
        {
            var tmp = spriteList[t];
            int r = Random.Range(t, spriteList.Length);
            spriteList[t] = spriteList[r];
            spriteList[r] = tmp;
        }
        for (int i = 0; i < ButtonSayisi; i++)
        {
            var obj = Instantiate(prefabButton);
            obj.transform.SetParent(parentObj.GetComponent<RectTransform>(), false);
            obj.GetComponent<RectTransform>().anchoredPosition = parentObj.GetComponent<RectTransform>().anchoredPosition;
            obj.GetComponent<Image>().sprite = spriteList[i];
            if (isShadow == true)
            {
                obj.GetComponent<Image>().color = new Color32(0, 0, 0, 100);
                obj.AddComponent<ItemSlot>();
                obj.AddComponent<PopUp>();
            }
            else
            {
                obj.AddComponent<DragDrop>();
                obj.GetComponent<DragDrop>().setCanvas(canvas);
                obj.AddComponent<CanvasGroup>();
            }
        }
    }
}
