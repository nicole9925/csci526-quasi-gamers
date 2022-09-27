using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Transform orientation;
    public Battery battery;
    public GameOverLabel gameOverLabel;

    [Header("Movement")]
    public float speed = 30.0f;
    public float groundDrag = 2.0f;
    public float airDrag = 0.5f;
    public float groundInputScale = 1.0f;
    public float airInputScale = 0.1f;
    public bool grounded = true;
    public LayerMask groundLayers = -1;
    [SerializeField] private float groundedDistance = 0.1f;
    private Vector3 _moveDirection;
    private Vector3 _groundNormal;
    
    private Rigidbody _rb;
    private InputController _input;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _input = GetComponent<InputController>();
    }

    void FixedUpdate()
    {
        GroundedCheck();

        float inputScale = groundInputScale;
        if (grounded)
        {
            _rb.drag = groundDrag;
        }
        else
        {
            _rb.drag = airDrag;
            inputScale = airInputScale;
        }

        _moveDirection = Vector3.ClampMagnitude(orientation.forward * _input.move.y + orientation.right * _input.move.x, 1.0f);
        if (grounded)
        {
            _moveDirection = Vector3.ProjectOnPlane(_moveDirection, _groundNormal).normalized * _moveDirection.magnitude;
        }

        _rb.AddForce(_moveDirection * (speed * inputScale), ForceMode.Force);

        if (!_moveDirection.Equals(Vector3.zero))
        {
            if (battery)
            {
                battery.UseEnergy();
            }
        }

    }

    private void Update()
    {
        if (transform.position.y < -10)
        {
            if (gameOverLabel)
            {
                gameOverLabel.showLabel();
            }
        }
    }

    private void GroundedCheck()
    {
        grounded = false;

        grounded = Physics.SphereCast(transform.position, 0.25f, Vector3.down, out RaycastHit hit,
                                      1.0f, groundLayers, QueryTriggerInteraction.Ignore);
        if (grounded)
        {
            _groundNormal = hit.normal;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position + Vector3.down * groundedDistance, 0.25f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            gameOverLabel.showLabel();
        }
    }
}
