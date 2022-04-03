using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private CharacterController Controller;
    [SerializeField] private float Speed = 12f;
    [SerializeField] private float Gravity = -9.8f;

    //FootStep Stuff
    [SerializeField] private AudioSource WalkmanL;
    [SerializeField] private AudioSource WalkmanR;
    [SerializeField] List<AudioClip> FootStepsLeft;
    [SerializeField] List<AudioClip> FootStepsRight;
    [SerializeField] float stepSoundDistance = 1f;
    private bool StepParity = false;
    private float DistanceSinceLastStepSound = 0f;
    private float[] LastPosition = new float[2];


    //Ground Stuff
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private float GroundDistance = 1f;
    [SerializeField] private LayerMask GroundMask;
    [SerializeField] private bool IsGrounded;

    Vector3 Velocity = Vector3.zero;


    // Update is called once per frame
    void Update()
    {
        IsGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance,GroundMask);

        if (IsGrounded && Velocity.y < 0)
        {
            Velocity.y = -2f;
            
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if(x != 0 && z != 0)
        {
            x = 0.8f * x;
            z = 0.8f * z;
        }

        Vector3 move = transform.right * x + transform.forward * z;

        Controller.Move(move * Speed * Time.deltaTime);

        Velocity.y += Gravity * Time.deltaTime;

        Controller.Move(Velocity * Time.deltaTime);

        //FootstepsControl
        if (DistanceSinceLastStepSound > stepSoundDistance)
        {
            DistanceSinceLastStepSound = 0f;
            int index;
            if (StepParity)
            {
                index = Random.Range(0, FootStepsLeft.Count);
                WalkmanL.clip = FootStepsLeft[index];
                WalkmanL.Play();
            }
            else
            {
                index = Random.Range(0, FootStepsRight.Count);
                WalkmanR.clip = FootStepsRight[index];
                WalkmanR.Play();
            }
            StepParity = !StepParity;
        }
        else
        {
            float distX = Mathf.Abs(transform.position.x - LastPosition[0]);
            float distY = Mathf.Abs(transform.position.z - LastPosition[1]);

            float totalDist = Mathf.Sqrt(Mathf.Pow(distX,2f) + Mathf.Pow(distY, 2f));
            DistanceSinceLastStepSound += totalDist;
            LastPosition[0] = transform.position.x;
            LastPosition[1] = transform.position.z;
        }

    }


}
