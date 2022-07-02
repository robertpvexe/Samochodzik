using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelColliders : MonoBehaviour
{
    
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    private float horizontalInput;
    private float verticalInput;
    private float currentSteerAngle;
    private float currentBreakForce;
    private bool isBreaking;
    private bool gearUp;
    private bool gearDown;
    private int gear = 1;
    private int maxGear = 6;
    private int[] gearForce ={0, 3500, 7500, 17500, 35000, 70000, 200000};
    
    [SerializeField] private float motorForce;
    [SerializeField] private float breakForce;
    [SerializeField] private float maxSteerAngle;
    
    [SerializeField] private WheelCollider frontRight;
    [SerializeField] private WheelCollider frontLeft;
    [SerializeField] private WheelCollider backRight;
    [SerializeField] private WheelCollider backLeft;

    [SerializeField] private Transform frontRightTransform;
    [SerializeField] private Transform frontLeftTransform;
    [SerializeField] private Transform backRightTransform;
    [SerializeField] private Transform backLeftTransform;

    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
        HandleGear();
    }

    private void UpdateWheel(WheelCollider col, Transform trans)
    {
        Vector3 position;
        Quaternion rotation;
        col.GetWorldPose(out position, out rotation);
        trans.position = position;
        trans.rotation = rotation;
    }
    private void GetInput()
    {
        horizontalInput = Input.GetAxis(HORIZONTAL);
        verticalInput = Input.GetAxis(VERTICAL);
        isBreaking = Input.GetKey(KeyCode.Space);
        gearUp = Input.GetKey(KeyCode.E);
        gearDown = Input.GetKey(KeyCode.Q);
    }
    private void HandleMotor()
    {
        frontLeft.motorTorque = verticalInput * motorForce;
        frontRight.motorTorque = verticalInput * motorForce;
        currentBreakForce = isBreaking ? breakForce : 0f;
        ApplyBreaking();       
    }
    
    private void ApplyBreaking()
    {
        frontRight.brakeTorque = currentBreakForce;
        frontLeft.brakeTorque = currentBreakForce;
        backLeft.brakeTorque = currentBreakForce;
        backRight.brakeTorque = currentBreakForce;
    }
    
    private void HandleSteering()
    {
        currentSteerAngle = maxSteerAngle * horizontalInput;
        frontLeft.steerAngle = currentSteerAngle;
        frontRight.steerAngle = currentSteerAngle;
    }
    
    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeft, frontLeftTransform);
        UpdateSingleWheel(frontRight, frontRightTransform);
        UpdateSingleWheel(backRight, backRightTransform);
        UpdateSingleWheel(backLeft, backLeftTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;       
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }

    private void HandleGear()
    {
        if (gearUp && gear < maxGear)
        {
            gearUp = false;
            gear++;
        }else if (gearDown && gear > 1)
        {
            gearDown = false;
            gear--;
        }
        
        motorForce = gearForce[gear];
    }
}
