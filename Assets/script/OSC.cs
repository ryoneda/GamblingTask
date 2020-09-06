using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OSC : MonoBehaviour
{

    bool startFlag = false;
    void Start()
    {
        startFlag = true;
        OSCHandler.Instance.Init();
    }

    void Update()
    {
        // ゲームがスタートしてから送信可能になる
        if (startFlag)
        {
            if (true)
            {
                string inputStr = Input.inputString;
                string allNumStr = "0123456789";
                if (true)
                {
                    //Debug.Log( "aaa");
                    int sentInt;
                    int.TryParse(inputStr, out sentInt);
                    List<object> values = new List<object>();
                    values.AddRange(new object[]{10, 20, 30});
                    OSCHandler.Instance.SendMessageToClient("sonic", "/Int", 120);
                }
            }
        }
    }
}
