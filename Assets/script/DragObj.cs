using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragObj : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
    public Transform parentTransform;
    private GameObject _parent;
    private Vector2 prevPos;

    void Start(){
        _parent = transform.parent.gameObject;
	}

    public void OnBeginDrag(PointerEventData data){
   
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        parentTransform = transform.parent;
        transform.SetParent(transform.parent.parent);
            
        prevPos = transform.position;

    }
    public void OnDrag(PointerEventData data){
        transform.position = data.position;
    }
    
    public void OnEndDrag(PointerEventData data){
        transform.SetParent(parentTransform);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        transform.position = prevPos;
    }   
}