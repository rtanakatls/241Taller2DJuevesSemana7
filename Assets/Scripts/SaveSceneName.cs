using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveSceneName : MonoBehaviour
{
    void Awake()
    {
        RetryButtonChangeScene.SCENE_NAME = SceneManager.GetActiveScene().name;   
    }
}
