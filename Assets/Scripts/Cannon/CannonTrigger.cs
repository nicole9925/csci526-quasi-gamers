using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonTrigger : MonoBehaviour
{
    [SerializeField] private Transform trigger;
    [SerializeField] private Transform cannon;
    [SerializeField] private CannonLauncher launcher;
    [SerializeField] private float triggerVelocityThreshold = -2.0f;
    [SerializeField] private float triggerActivateTime = 1.0f;
    [SerializeField] private float triggerResetTime = 2.0f;
    [SerializeField] private float cannonForce = 5.0f;
    [SerializeField] private float maxTriggerDistance = 5.0f;
    [SerializeField] private float maxCannonDistance = 5.0f;
    
    private Vector3 _baseTriggerPos;
    private Vector3 _baseCannonPos;
    private Vector3 _activateBaseTriggerPos;
    private Vector3 _activateBaseCannonPos;
    private Vector3 _finalActivatedTriggerPos;
    private Vector3 _finalActivatedCannonPos;
    private Vector3 _resetBaseTriggerPos;
    private Vector3 _resetBaseCannonPos;
    private Vector3 _maxCannonDistance;
    private float _activationTimer;
    private float _resetTimer;
    private bool _shouldReset;
    private bool _isResetting;
    private bool _resetCompleted;
    private bool _activated;

    void Start()
    {
        if (!trigger || !cannon)
        {
            Debug.LogError("Trigger and cannon have not been set for the cannon trigger script.");
        }
        
        _baseTriggerPos = trigger.position;
        _baseCannonPos = cannon.position;
    }

    void FixedUpdate()
    {
        if (!_isResetting && !_activated && !_resetCompleted && _shouldReset)
        {
            _isResetting = true;
            _shouldReset = false;
            _resetBaseTriggerPos = trigger.position;
            _resetBaseCannonPos = cannon.position;
            _resetTimer = 0.0f;
            launcher.ResetCannon();
        }
        
        if (_isResetting)
        {
            _resetTimer += Time.fixedDeltaTime;

            if (_resetTimer >= triggerResetTime)
            {
                _isResetting = false;
                _resetCompleted = true;
                trigger.position = _baseTriggerPos;
                cannon.position = _baseCannonPos;
            }
            else
            {
                trigger.position = Vector3.Lerp(_resetBaseTriggerPos, _baseTriggerPos, _resetTimer / triggerResetTime);
                cannon.position = Vector3.Lerp(_resetBaseCannonPos, _baseCannonPos, _resetTimer / triggerResetTime);
            }
        }
        else if (_activated)
        {
            _activationTimer += Time.fixedDeltaTime;
            float cannonDistance = (cannon.position - _baseCannonPos).magnitude;

            if (_activationTimer >= triggerActivateTime || cannonDistance >= maxCannonDistance)
            {
                if (_activationTimer >= triggerActivateTime)
                {
                    trigger.position = _finalActivatedTriggerPos;
                    cannon.position = _finalActivatedCannonPos;
                }
                
                _activated = false;
            }
            else
            {
                trigger.position = Vector3.Lerp(_activateBaseTriggerPos, _finalActivatedTriggerPos,
                                                _activationTimer / triggerActivateTime);
                cannon.position = Vector3.Lerp(_activateBaseCannonPos, _finalActivatedCannonPos,
                                               _activationTimer / triggerActivateTime);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player") || _activated || _isResetting)
        {
            return;
        }

        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (!rb || rb.velocity.y > triggerVelocityThreshold)
        {
            return;
        }

        _activated = true;
        _activationTimer = 0.0f;
        _activateBaseTriggerPos = trigger.position;
        _activateBaseCannonPos = cannon.position;
        _finalActivatedTriggerPos = _baseTriggerPos - trigger.up * maxTriggerDistance;
        _finalActivatedCannonPos = _baseCannonPos + cannon.up * maxCannonDistance;
        _resetCompleted = false;
        launcher.Activate(cannonForce);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        _shouldReset = true;
    }
}
