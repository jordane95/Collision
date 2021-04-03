using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitTwo : MonoBehaviour
{

    public static float MoveSpeed1 = 2, MoveSpeed2 = 2;
    public int mass1 = 1, mass2 = 1;

    public Rigidbody rb1,rb2;

    //定义物体运动的方向
    public static Vector3 n1 = new Vector3(1, 0, 1), n2 = new Vector3(-1, 0, 1);

    // Start is called before the first frame update
    void Start()
    { 
        //物体初始化
        rb1 = GameObject.Find("Sphere1").GetComponent<Rigidbody>();
        rb2 = GameObject.Find("Sphere2").GetComponent<Rigidbody>();
        rb1.mass = mass1;
        rb2.mass = mass1;
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(140, 370, 100, 50), "弹性碰撞"))
        {
            rb1.velocity = n1 * MoveSpeed1;
            rb2.velocity = n2 * MoveSpeed2;
            GameObject.Find("Sphere1").AddComponent<CollisionTwo1>();
            GameObject.Find("Sphere2").AddComponent<CollisionTwo1>();
        }
        if (GUI.Button(new Rect(140, 430, 100, 50), "完全非弹性碰撞"))
        {
            rb1.velocity = Vector3.right * MoveSpeed1;
            rb2.velocity = Vector3.right * MoveSpeed2;
            GameObject.Find("Sphere1").AddComponent<CollisionTwo2>();
            GameObject.Find("Sphere2").AddComponent<CollisionTwo2>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
