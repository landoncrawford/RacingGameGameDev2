using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverMotorNew : MonoBehaviour
{
    public float threshold;
    public Transform playerSpawnPoint = null;


    public float forwardAcceleration = 100f;
    public float forwardMaxSpeed = 200f;
    public float brakeSpeed = 200f;
    public float turnSpeed = 50f;
    
    public float pitchSmooth = 5f;

    private Vector3 _prevUp;
    public float yaw;
    private float _smoothY;
    private float _currentSpeed;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _currentSpeed += (_currentSpeed >= forwardMaxSpeed) ? 0f : forwardAcceleration * Time.deltaTime;
        }
        else
        {
            if (_currentSpeed > 0)
                _currentSpeed -= brakeSpeed * Time.deltaTime;
            else
            {
                _currentSpeed = 0f;
            }
        }

        yaw += turnSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        _prevUp = transform.up;
        transform.rotation = Quaternion.Euler(0, yaw, 0);
        transform.position += transform.forward * (_currentSpeed * Time.deltaTime);
    }

        private void FixedUpdate()
    {
        if (transform.position.y < threshold)
        {
            transform.position = playerSpawnPoint.position;
        }
    }
}
