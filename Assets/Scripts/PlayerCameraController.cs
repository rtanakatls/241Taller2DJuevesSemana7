using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    [SerializeField] private List<CinemachineVirtualCamera> virtualCameras;

    private void ChangeCamera(int index)
    {
        foreach (CinemachineVirtualCamera cam in virtualCameras)
        {
            cam.Priority = 0;
        }
        virtualCameras[index].Priority = 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CameraTrigger"))
        {
            ChangeCamera(collision.gameObject.GetComponent<CameraTrigger>().EnterCameraIndex);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CameraTrigger"))
        {
            ChangeCamera(collision.gameObject.GetComponent<CameraTrigger>().ExitCameraIndex);
        }
    }
}
