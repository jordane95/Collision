using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Begin : MonoBehaviour
{
    public static string scene_name;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(30, 200, 100, 50),"一维碰撞"))
        {
            scene_name = "CollisionOneDimension";
            GameObject.Find("Main Camera").AddComponent<SceneLoader>();
        }
        if (GUI.Button(new Rect(30, 400, 100, 50),"二维碰撞"))
        {
            scene_name = "CollisionTwoDimension";
            GameObject.Find("Main Camera").AddComponent<SceneLoader>();
        }
    }
}
