using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public List<CinemachineVirtualCamera> cameras;

    public void SetCameraPriority(int index, int priority)
    {
        if (cameras != null)
        {
            if (index >= cameras.Count)
            {
                Debug.LogError("Invalid index specified for setting camera priority.");
                return;
            }

            cameras[index].Priority = priority;
        }
    }
}
