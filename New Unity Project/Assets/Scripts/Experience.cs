using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experience : MonoBehaviour
{

    public int MoveSpeed1 = 1, MoveSpeed2 = 2;
    public int m1 = 1, m2 = 1;

    // Start is called before the first frame update
    void Start()
    {
        //物体初始化
        cube1 = GameObject.Find("Cube1");
        cube2 = GameObject.Find("Cube2");

        cube1.GetComponent<Rigidbody>().mass = m1;
        cube2.GetComponent<Rigidbody>().mass = m2;
        cube1.AddComponent<Move>();
        cube2.AddComponent<Move>();
        cube1.Move();
        cube2.Move();
    }
    // Update is called once per frame
    void Update()
    {
      
    }
}