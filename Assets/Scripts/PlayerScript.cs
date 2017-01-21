using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
    public float moveSpeed;
    public float turnSpeed;
    public float resetRotationTimeLimit;
    public float WorldBoundary_Bottom;

    private float UnalignedTime = 0;
    private Vector3 RestorePoint = new Vector3(0,0,0);


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    private void FixedUpdate()
    {
        PlayerMovement();
        CheckBoundaryViolation();
        CheckAlignment();
    }

    private void CheckAlignment()
    {
        if (System.Math.Abs(transform.rotation.eulerAngles.x) > 45 || (System.Math.Abs(transform.rotation.eulerAngles.z) > 45))
        {
            UnalignedTime += (float).02;

            if (UnalignedTime > resetRotationTimeLimit)
            {
                ResetAlignment();
                UnalignedTime = 0;
            }
        }
        else
        {
            UnalignedTime = 0;
        }
    }
    private void PlayerMovement()
    {
        float MoveForward = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float MoveRotate = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
        transform.Translate(Vector3.forward * MoveForward);
        transform.Rotate(0, MoveRotate, 0);
    }
    private void CheckBoundaryViolation()
    {
        if (transform.position.y < WorldBoundary_Bottom)
        {
            ResetPosition();
            ResetAlignment();
        }
    }


    private void ResetAlignment()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
    private void ResetPosition()
    {
        transform.position = RestorePoint;
    }
}
