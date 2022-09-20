using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformContact : MonoBehaviour
{
    public bool inContact = false;
    [SerializeField] private LayerMask platformLayers = -1;
    [SerializeField] private float checkDistance = 0.35f;
    [SerializeField] private float checkRadius = 0.15f;

    private PlatformController _platformInContact;

    void FixedUpdate()
    {
        RaycastHit[] hits = Physics.SphereCastAll(transform.position, checkRadius, Vector3.down,
                                                  checkDistance, platformLayers, QueryTriggerInteraction.Ignore);

        bool foundPlatform = false;
        foreach (RaycastHit hit in hits)
        {
            PlatformPart part = hit.collider.GetComponent<PlatformPart>();
            if (part)
            {
                _platformInContact = part.GetController();
                if (_platformInContact)
                {
                    foundPlatform = true;
                    if (!inContact)
                    {
                        _platformInContact.AddToObjectsInContact(gameObject);
                        inContact = true;
                        break;
                    }
                }
            }
        }

        if (!foundPlatform)
        {
            if (inContact)
            {
                inContact = false;
                if (_platformInContact)
                {
                    _platformInContact.RemoveFromObjectsInContact(gameObject);
                    _platformInContact = null;
                }
            }
        }
    }
}
