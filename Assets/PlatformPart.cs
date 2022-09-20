using UnityEngine;

public class PlatformPart : MonoBehaviour
{
    [SerializeField] private bool controllerInParent;
    
    private PlatformController _controller;

    void Start()
    {
        if (controllerInParent)
        {
            _controller = GetComponentInParent<PlatformController>();
        }
        else
        {
            _controller = GetComponent<PlatformController>();
        }
    }

    public PlatformController GetController()
    {
        return _controller;
    }
}
