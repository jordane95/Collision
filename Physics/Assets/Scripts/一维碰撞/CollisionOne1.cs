using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionOne1 : MonoBehaviour
{
    public float MoveSpeed;
    private float mass1, mass2, speed1, speed2, v1, v2;

    // Start is called before the first frame update
    void Start()
    {
        //将物体设为蓝色
        this.GetComponent<Renderer>().material.color = Color.blue;
    }

    private void FixedUpdate()
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
        v1 = speed1;
        v2 = speed2;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //打印碰撞到物体的名称
        Debug.Log(collision.gameObject.name);
        //获取碰撞到物体的Render组件并且更改其材质球颜色
        collision.gameObject.GetComponent<Renderer>().material.color = Color.red;
        //计算碰撞后的速度
        v1 = ((mass1-mass2) * speed1 +2* mass2 * speed2) / (mass1 + mass2);
        v2 = ((mass2-mass1) * speed1 + 2*mass1 * speed1) / (mass1 + mass2);
        Debug.Log(v1);
        Debug.Log(v2);
        if (this.name == "Cube1")
        {
            MoveSpeed = v1;
        }
        else
        {
            MoveSpeed = v2;
        }
        this.GetComponent<Rigidbody>().velocity = Vector3.right * MoveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(900,0, 200, 50),"物体1的质量:" + mass1.ToString("f1"));
        GUI.Label(new Rect(900, 20, 200, 50),"物体2的质量:" + mass2.ToString("f1"));
        GUI.Label(new Rect(900, 40, 200, 50),"物体1的速度:" + v1.ToString("f1"));
        GUI.Label(new Rect(900, 60, 200, 50),"物体2的速度:" + v2.ToString("f1"));
    }
}