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
        Debug.Log ("Parent:" + _parent.name);
        Debug.Log ("this:" + this);
	}

    public void OnBeginDrag(PointerEventData data){
        if(_parent.name == "Hand"){
            Debug.Log("OnBeginDrag");
            
            GetComponent<CanvasGroup>().blocksRaycasts = false;
            parentTransform = transform.parent;
            transform.SetParent(transform.parent.parent);
            
            prevPos = transform.position;

        }

    }
    public void OnDrag(PointerEventData data){
        if(_parent.name == "Hand"){
            transform.position = data.position;
        }
    }
    
    public void OnEndDrag(PointerEventData data){
        if(_parent.name == "Hand"){
            Debug.Log("OnEndDrag");
            transform.SetParent(parentTransform);
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            transform.position = prevPos;
        }
    }   
    /*
    public void OnEndDrag ( PointerEventData data )
    {
        // ドラッグ前の位置に戻す
        transform.position = prevPos;
    }
    
    public void OnDrop (PointerEventData data)
    {
        Debug.Log("OnDrop");
        var raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll ( data, raycastResults );
        //Debug.Log(raycastResults);
        foreach ( var hit in raycastResults )
        {
            // もし DroppableField の上なら、その位置に固定する
            if ( hit.gameObject.CompareTag ( "DroppableField" ) )
            {
                transform.position = hit.gameObject.transform.position;
                this.enabled = false;
                Debug.Log(transform.position);
                Debug.Log(hit.gameObject.transform.position);
            }
        }
    }
    */
}