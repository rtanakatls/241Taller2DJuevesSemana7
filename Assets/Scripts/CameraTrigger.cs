using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    [SerializeField] private int enterCameraIndex;
    [SerializeField] private int exitCameraIndex;

    public int EnterCameraIndex
    {
        get
        {
            return enterCameraIndex;
        }
    }

    public int ExitCameraIndex
    {
        get
        {
            return exitCameraIndex;
        }
    }
}
