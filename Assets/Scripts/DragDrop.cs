using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    [SerializeField] private Canvas canvas ;
    
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    GameObject ParentOBJ;
    private Vector3 initPos;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        ParentOBJ = gameObject.transform.parent.gameObject;

    }
    
    public void setCanvas(GameObject obj)
    {
       canvas =obj.GetComponent<Canvas>();
      //  canvas.scaleFactor = 1f;

    }

    public void OnBeginDrag(PointerEventData eventData)
    { 
        canvasGroup = gameObject.GetComponent<CanvasGroup>();
        // Debug.Log("OnBeginDrag");
        initPos = eventData.pointerDrag.transform.position;
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
        gameObject.transform.SetParent(ParentOBJ.GetComponent<RectTransform>(), false);
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("OnDrag");
        
        rectTransform.localPosition += new Vector3((eventData.delta.x / canvas.scaleFactor), (eventData.delta.y / canvas.scaleFactor),0);
       
        //( / canvas.scaleFactor, eventData.delta.y / canvas.scaleFactor);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("OnEndDrag");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
       // Debug.Log("OnPointerDown");
    }
    public void ResetPosition()
    {
        transform.position = initPos;
    }
}
