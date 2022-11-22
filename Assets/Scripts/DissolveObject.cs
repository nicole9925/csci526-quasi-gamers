using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveObject : MonoBehaviour
{

    [SerializeField] private float noiseStrength = 0.25f;
    [SerializeField] private float objectHeight = 1.0f;
    [SerializeField] private float base_time = 0f;
    [SerializeField] private float minHeight = Mathf.Infinity;
    // private bool dissolved = false;
    private Material material;
    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().material;
        base_time = Time.time;
        SetHeight(Mathf.Cos(0 * Mathf.PI * 0.25f) * (objectHeight/2.0f) + transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(base_time);
        var time = (Time.time - base_time) * Mathf.PI * 0.25f;
        // Debug.Log(time);
        //var time = Time.time* Mathf.PI * 0.5f;
        
            float height = transform.position.y;
            // Debug.Log(height);

            height += Mathf.Cos(time) * (objectHeight / 2.0f);
            
            
            
            if (height > minHeight){
                // dissolved = true;
                //gameObject.SetActive(false);
            }
            else{
                minHeight = height;
                SetHeight(height);
            }

    }

     private void SetHeight(float height)
    {
        material.SetFloat("_CutoffHeight", height);
        material.SetFloat("_NoiseStrength", noiseStrength);
    }
}
