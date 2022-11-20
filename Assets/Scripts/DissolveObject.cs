using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveObject : MonoBehaviour
{

    [SerializeField] private float noiseStrength = 0.25f;
    [SerializeField] private float objectHeight = 1.0f;
    [SerializeField] private float minHeight = Mathf.Infinity;
    private bool dissolved = false;

    private Material material;
    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().material;
        var time = Time.time * Mathf.PI * 0.25f;
        SetHeight(Mathf.Sin(time) * (objectHeight/2.0f) + transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        var time = Time.time * Mathf.PI * 0.25f;

        if (! dissolved){
            float height = transform.position.y;
            // Debug.Log(height);
            height += Mathf.Cos(time) * (objectHeight / 2.0f);
            SetHeight(height);
            if (height > minHeight){
                dissolved = true;
                gameObject.SetActive(false);
            }
            else{
                minHeight = height;
            }
        }
    }

     private void SetHeight(float height)
    {
        material.SetFloat("_CutoffHeight", height);
        material.SetFloat("_NoiseStrength", noiseStrength);
    }
}
