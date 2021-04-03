using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitOne : MonoBehaviour
{

    public float MoveSpeed1 , MoveSpeed2 ;
    public int mass1 , mass2 ;

    public Rigidbody rb1,rb2;

    // Start is called before the first frame update
    void Start()
    {
        MoveSpeed1 = Random.Range(5.0f, 10.0f);
        MoveSpeed2 = Random.Range(0.0f, 5.0f);
        mass1 = Random.Range(1, 10);
        mass2 = Random.Range(1, 10);

        //物体初始化
        rb1 = GameObject.Find("Cube1").GetComponent<Rigidbody>();
        rb2 = GameObject.Find("Cube2").GetComponent<Rigidbody>();
        rb1.mass = mass1;
        rb2.mass = mass2;
 
        Debug.Log(rb1.velocity.magnitude);
        Debug.Log(rb2.velocity.magnitude);
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(140, 170, 100, 50),"弹性碰撞"))
        {
            rb1.velocity = Vector3.right * MoveSpeed1;
            rb2.velocity = Vector3.right * MoveSpeed2;
            GameObject.Find("Cube1").AddComponent<CollisionOne1>();
            GameObject.Find("Cube2").AddComponent<CollisionOne1>();
        }
        if (GUI.Button(new Rect(140, 230, 100, 50),"完全非弹性碰撞"))
        {
            rb1.velocity = Vector3.right * MoveSpeed1;
            rb2.velocity = Vector3.right * MoveSpeed2;
            GameObject.Find("Cube1").AddComponent<CollisionOne2>();
            GameObject.Find("Cube2").AddComponent<CollisionOne2>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
