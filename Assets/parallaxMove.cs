using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallaxMove : MonoBehaviour
{
    public Transform parentObject;  // Reference to the parent object
    public float delay = 0.5f;      // Delay in seconds
    public float overshootFactor = 1.2f;  // Factor for overshooting the target
    public float smoothSpeed = 5f;   // Speed of smoothing (controls how quickly the child catches up)
    
    private List<Vector3> positionHistory; // To store past positions

    void Start()
    {
        positionHistory = new List<Vector3>(); // Initialize the position history
    }

    void Update()
    {
        // Record the parent's position every frame
        positionHistory.Add(parentObject.position);

        // Calculate how many frames to delay based on the delay time and frame rate
        int frameDelay = Mathf.RoundToInt(delay / Time.deltaTime);

        // Ensure there are enough recorded frames in the position history
        if (positionHistory.Count > frameDelay)
        {
            // Get the target position (parent's position from "delay" seconds ago)
            Vector3 targetPosition = positionHistory[0];

            // Remove the oldest recorded position from the history
            positionHistory.RemoveAt(0);

            // Overshoot logic: Calculate the distance between the current position and the target
            Vector3 directionToTarget = targetPosition - transform.position;

            // Overshoot the target by multiplying the direction vector by the overshoot factor
            Vector3 overshootPosition = transform.position + directionToTarget * overshootFactor;

            // Smoothly move the child towards the overshoot position
            transform.position = Vector3.Lerp(transform.position, overshootPosition, smoothSpeed * Time.deltaTime);
        }
    }
}
