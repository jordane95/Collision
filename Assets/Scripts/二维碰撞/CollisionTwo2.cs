using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTwo2 : MonoBehaviour
{
    public float MoveSpeed;

    //vn代表法线方向的速度分量，vt代表切线，v1,v2代表碰撞完成后法向速度
    private float mass1, mass2, vt1, vt2, vn1, vn2, v1, v2;

    //定义碰撞过程中的切向量和法向量
    public Vector3 n, t;

    //定义物体碰撞后的矢量速度
    public Vector3 Velocity1, Velocity2;

    // Start is called before the first frame updat
    void Start()
    {
        if (this.name == "Sphere1")
        {
            MoveSpeed = InitTwo.MoveSpeed1;
            this.GetComponent<Renderer>().material.color = Color.blue;
            this.GetComponent<Rigidbody>().velocity = InitTwo.n1 * MoveSpeed;
        }
        else
        {
            MoveSpeed = InitTwo.MoveSpeed2;
            this.GetComponent<Renderer>().material.color = Color.blue;
            this.GetComponent<Rigidbody>().velocity = InitTwo.n2 * MoveSpeed;
        }
        Debug.Log(MoveSpeed);
    }

    private void FixedUpdate()
    {
        //获取物体的质量
        mass1 = GameObject.Find("Sphere1").GetComponent<Rigidbody>().mass;
        mass2 = GameObject.Find("Sphere2").GetComponent<Rigidbody>().mass;
        //获取物体速度
        Vector3 Speed1 = GameObject.Find("Sphere1").GetComponent<Rigidbody>().velocity;
        Vector3 Speed2 = GameObject.Find("Sphere2").GetComponent<Rigidbody>().velocity;

        //获取法向量和切向量
        n = (GameObject.Find("Sphere1").transform.position - GameObject.Find("Sphere2").transform.position).normalized;
        t = Vector3.Cross(Vector3.up, n).normalized;

        //将速度沿切向和法向分解
        vn1 = Vector3.Dot(Speed1, n);
        vn2 = Vector3.Dot(Speed2, n);
        vt1 = Vector3.Dot(Speed1, t);
        vt2 = Vector3.Dot(Speed1, t);
        Debug.Log(vn1);
        Debug.Log(vn2);
        Debug.Log(vt1);
        Debug.Log(vt2);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //打印碰撞到物体的名称
        Debug.Log(collision.gameObject.name);
        //获取碰撞到物体的Render组件并且更改其材质球颜色
        collision.gameObject.GetComponent<Renderer>().material.color = Color.red;
        //计算碰撞后的速度
        v1 = (mass1 * vn1 + mass2 * vn2) / (mass1 + mass2);
        v2 = (mass1 * vn1 + mass2 * vn2) / (mass1 + mass2);
        Debug.Log(v1);
        Debug.Log(v2);

        Velocity1 = t * vt1 + n * v1;
        Velocity2 = t * vt2 + n * v2;

        if (this.name == "Sphere1")
        {
            this.GetComponent<Rigidbody>().velocity = Velocity1;
        }
        else
        {
            this.GetComponent<Rigidbody>().velocity = Velocity2;
        }
    }
 
    // Update is called once per frame
    void Update()
    {
        
    }
}
