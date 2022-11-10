using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Transform orientation;
    public Battery battery;
    public GameOverLabel gameOverLabel;
    public ParticleSystem playerParticle;

    [Header("Movement")]
    public float speed = 20.0f;
    public float groundDrag = 2.0f;
    public float airDrag = 0.5f;
    public float groundInputScale = 1.0f;
    public float airInputScale = 0.1f;
    public float maxDisableTime = 4.0f;
    public bool grounded = true;
    public LayerMask groundLayers = -1;
    [SerializeField] private float groundedDistance = 0.1f;
    private Vector3 _moveDirection;
    private Vector3 _groundNormal;
    private bool isMovementDisabled = false;
    private float disableMovementTimer = 0.0f;
    private float disableMovementTime = 1.0f;

    public float rotationSpeed;

    private Rigidbody _rb;
    private InputController _input;

    private Vector3 lastPosition;
    private float totalDistance;
    private AnalyticsManager analytics;

    private Animator _animator;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.centerOfMass = Vector3.zero;
        _rb.inertiaTensorRotation = Quaternion.identity;
        _input = GetComponent<InputController>();
        playerParticle = GetComponentInChildren<ParticleSystem>();
        if(playerParticle != null)
        {
            playerParticle.Stop();
        }
        lastPosition = transform.position;
        analytics = new AnalyticsManager();
        _animator = GetComponentInChildren<Animator>();
    }

    void FixedUpdate()
    {

        GroundedCheck();

        if (isMovementDisabled)
        {
            disableMovementTimer += Time.fixedDeltaTime;
            if (disableMovementTimer >= disableMovementTime)
            {
                isMovementDisabled = false;
                disableMovementTimer = 0.0f;
            }
            else
            {
                return;
            }
        }

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
        } if (_moveDirection != Vector3.zero)
        {
            //Vector3 _turnDirection = new Vector3(_moveDirection.x, -_moveDirection.y, _moveDirection.z);
            //print(_moveDirection);
            //Quaternion toRotation = Quaternion.LookRotation(_turnDirection, Vector3.up);
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            transform.right = -_moveDirection;
        }
        _rb.AddForce(_moveDirection * (speed * inputScale), ForceMode.Force);
        _animator.SetFloat("Speed", _rb.velocity.magnitude);

    }

    private void Update()
    {
       
        float distance = Vector3.Distance(lastPosition, transform.position);
        totalDistance += distance;
        PlayerPrefs.SetFloat("distance", totalDistance);
        lastPosition = transform.position;
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

        grounded = Physics.SphereCast(transform.position, 0.1f, Vector3.down, out RaycastHit hit,
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

        if (playerParticle != null && collision.gameObject.tag == "powerUp" && playerParticle.isPlaying == false)
        {
            Debug.Log("Power Up!");
            #if UNITY_WEBGL
                StartCoroutine(analytics.GetRequests(PlayerPrefs.GetInt("currentScene")-2, 4));
            #endif
            changeWallColor();
            playerParticle.Play();
            gameObject.GetComponent<Renderer>().material.color = new Color32(10, 233, 203, 100);
        }

        if (playerParticle != null && collision.gameObject.tag == "wall" && playerParticle.isPlaying == true)
        {
            GameObject wall = collision.gameObject;
            Destroy(wall);
        }
    }

    private void changeWallColor()
    {
        Color newWallColor = new Color32(10, 233, 203, 100);
        Color currentWallColor = new Color(0, 156, 255, 107);
        GameObject []walls = GameObject.FindGameObjectsWithTag("wall");
        foreach(GameObject singleWall in walls)
        {
            singleWall.GetComponent<Renderer>().material.color = newWallColor;
        }
    }

    public void DisableMovement(float duration)
    {
        if (duration >= maxDisableTime)
        {
            duration = maxDisableTime;
        }

        isMovementDisabled = true;
        disableMovementTime = duration;
    }
}
