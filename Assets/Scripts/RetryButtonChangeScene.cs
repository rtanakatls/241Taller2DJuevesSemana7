using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RetryButtonChangeScene : MonoBehaviour
{
    public static string SCENE_NAME = string.Empty;



    void Awake()
    {
        GetComponent<Button>().onClick.AddListener(ChangeScene);
    }

    void ChangeScene()
    {
        if (SCENE_NAME == string.Empty)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(SCENE_NAME);
        }
    }
}
