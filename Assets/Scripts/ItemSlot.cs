using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public int DogruCevap = 0;
    public int YanlisCevap = 0;
    public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log("OnDrop");
        if(eventData.pointerDrag!=null)
        {
            // eventData.pointerDrag.transform.SetParent(gameObject.transform.parent, false);
            //eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition;
            
            if (gameObject.GetComponent<Image>().sprite.name==eventData.pointerDrag.gameObject.GetComponent<Image>().sprite.name)
            {
                Debug.Log("TRUE !");
                eventData.pointerDrag.gameObject.SetActive(false);
                gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                DogruCevap++;
            }
            else
            {
                Debug.Log("False");
                eventData.pointerDrag.GetComponent<DragDrop>().ResetPosition();
                YanlisCevap++;
            }
        }
    }
}
