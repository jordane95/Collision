using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();//退出程序
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("SceneLoader");//重新加载场景
        }
    }
}
