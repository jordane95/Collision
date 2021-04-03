using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private bool condition = false;

    // Start is called before the first frame update
    void Start()
    {
        if (!condition)
        {
            SceneManager.LoadScene(Begin.scene_name, LoadSceneMode.Additive);
            condition = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
