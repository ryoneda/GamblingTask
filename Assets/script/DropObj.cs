using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropObj : MonoBehaviour, IDropHandler
{
       public void OnDrop ( PointerEventData data )
    {
        Debug.Log("OnDrop");
        var raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll ( data, raycastResults );
        Debug.Log(raycastResults);
        foreach ( var hit in raycastResults )
        {
            // もし DroppableField の上なら、その位置に固定する
            if ( hit.gameObject.CompareTag ( "DroppableField" ) )
            {
                //transform.position = hit.gameObject.transform.position;
                hit.gameObject.transform.position = transform.position;
                //this.enabled = false;
                Debug.Log("DroppableField");
            }
        }
    }
}
