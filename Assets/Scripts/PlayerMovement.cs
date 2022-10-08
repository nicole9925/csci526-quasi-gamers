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

    private AnalyticsManager analytics;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _input = GetComponent<InputController>();
        playerParticle = GetComponentInChildren<ParticleSystem>();
        if(playerParticle != null)
        {
            playerParticle.Stop();
        }

        analytics = new AnalyticsManager();
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

        if(playerParticle != null && collision.gameObject.tag == "powerUp" && playerParticle.isPlaying == false)
        {
            Debug.Log("Power Up!");
            StartCoroutine(analytics.GetRequests(PlayerPrefs.GetInt("currentScene")-2, 4));
            
            changeWallColor();
            playerParticle.Play();
            gameObject.GetComponent<Renderer>().material.color = new Color32(10, 233, 203, 100);
        }

        if(playerParticle != null && collision.gameObject.tag == "wall" && playerParticle.isPlaying == true)
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
}
