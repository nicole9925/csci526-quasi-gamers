using UnityEngine;

public class PlatformPart : MonoBehaviour
{
    [SerializeField] private bool controllerInParent;
    [SerializeField] private PlatformController controller;

    void Start()
    {
        if (!controller)
        {
            if (controllerInParent)
            {
                controller = GetComponentInParent<PlatformController>();
            }
            else
            {
                controller = GetComponent<PlatformController>();
            }
        }
        
    }

    public PlatformController GetController()
    {
        return controller;
    }
}
