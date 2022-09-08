using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateCollider : MonoBehaviour
{
    public static bool isActive = false;
    private Collider m_ObjectCollider;
    void Start()
    {
        m_ObjectCollider = GetComponent<Collider>();  
    }

    // Update is called once per frame
    void Update()
    {

        if(isActive == true)
        {
            gameObject.GetComponent<Renderer> ().material.color = Color.green;
            m_ObjectCollider.isTrigger = true;
        }
    
    }
}
