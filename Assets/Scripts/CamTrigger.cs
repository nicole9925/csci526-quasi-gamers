using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTrigger : MonoBehaviour
{
    public CameraController cameraController;
    public int cameraIndex = 0;
    public int activePriority = 10;
    public int inactivePriority = 1;
    public bool switchOnPlayer = true;
    public bool switchOnEnemy = false;

    private bool _active = false;
    private List<GameObject> _entitiesOnPlatform;

    void Awake()
    {
        _entitiesOnPlatform = new List<GameObject>();
    }

    void FixedUpdate()
    {
        if (_entitiesOnPlatform.Count > 0 && !_active)
        {
            _active = true;
            cameraController.SetCameraPriority(cameraIndex, activePriority);
        }
        else if (_entitiesOnPlatform.Count == 0 && _active)
        {
            _active = false;
            cameraController.SetCameraPriority(cameraIndex, inactivePriority);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag("Player") && switchOnPlayer) ||
            (other.CompareTag("enemy") && switchOnEnemy))
        {
            if (!_entitiesOnPlatform.Contains(other.gameObject))
            {
                _entitiesOnPlatform.Add(other.gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if ((other.CompareTag("Player") && switchOnPlayer) ||
            (other.CompareTag("enemy") && switchOnEnemy))
        {
            _entitiesOnPlatform.Remove(other.gameObject);
        }
    }
}
