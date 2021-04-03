using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float MoveSpeed;
    private float mass1, mass2, speed1, speed2, v1,v2;

    void Awake()
    {
        //将物体设为蓝色
        gameObject.GetComponent<Renderer>().material.color = Color.blue;
        //使物体以给定初速度运动
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.right * MoveSpeed;
    }


    // Start is called before the first frame update
    void Start()
    {
        //获取物体的质量
        mass1 = GameObject.Find("Cube1").GetComponent<Rigidbody>().mass;
        mass2 = GameObject.Find("Cube2").GetComponent<Rigidbody>().mass;
        //获取物体速度
        Vector3 Speed1 = GameObject.Find("Cube1").GetComponent<Rigidbody>().velocity;
        Vector3 Speed2 = GameObject.Find("Cube2").GetComponent<Rigidbody>().velocity;

        speed1 = Vector3.Dot(Speed1, Vector3.right);
        speed2 = Vector3.Dot(Speed2, Vector3.right);
        Debug.Log(speed1);
        Debug.Log(speed2);
    }

    private void OnCollisionEnter (Collision collision)
    {
        Debug.Log(speed1);
        Debug.Log(speed2);
        //打印碰撞到物体的名称
        Debug.Log(collision.gameObject.name);
        //获取碰撞到物体的Render组件并且更改其材质球颜色
        collision.gameObject.GetComponent<Renderer>().material.color = Color.red;
        //计算碰撞后的速度
        v1 = ((mass1 - mass2) * speed1 + 2 * mass2 * speed2) / (mass1 + mass2);
        v2 = ((mass2 - mass1) * speed2 + 2 * mass1 * speed1) / (mass1 + mass2);
        Debug.Log(v1);
        Debug.Log(v2);
        if (this.name == "Cube1")
        {
           MoveSpeed = v1;
        }else
        {
           MoveSpeed = v2;
        }
    }

    // Update is called once per frame
    private void Update()
    {
       gameObject.GetComponent<Rigidbody>().velocity = Vector3.right * MoveSpeed;
    }

}
