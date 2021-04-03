using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUI : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnGUI()
    {
        GUILayout.Label("完全弹性碰撞");
        GUILayout.Button( "这是一个button按钮", "button");
        GUILayout.Button("这是一个button按钮", "toggle");
        GUILayout.Label( "buttonstyle");
    }
}