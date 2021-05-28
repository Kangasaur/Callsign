using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public float acceleration = 30;
    public float maxSpeed = 2440;
    public float baseSpeed = 300;
    public float stallSpeed = 120;
    public float response = 0.2f;
    public float mobility = 72f;

    private float inputPitch;
    private float inputRoll;
    private float inputYaw;
    private float inputThrust;
    private float movePitch;
    private float moveRoll;
    private float moveYaw = 0f;
    private float speed;

    private float KmphToMps = 0.27777777f;

    void Start()
    {
        speed = baseSpeed;
    }

    void Update()
    {
        inputThrust = Input.GetAxisRaw("Vertical");
        inputPitch = Input.GetAxisRaw("Mouse Y");
        inputRoll = Input.GetAxisRaw("Mouse X");

        speed += inputThrust * acceleration * Time.deltaTime;
        speed = Mathf.Clamp(speed, stallSpeed, maxSpeed);
        movePitch = inputPitch * mobility * Time.deltaTime;
        moveRoll = inputRoll * mobility * Time.deltaTime;

        transform.Translate(Vector3.forward * speed * Time.deltaTime * KmphToMps);
        transform.Rotate(movePitch, moveYaw, moveRoll);
    }
}
