using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartnerFollow : MonoBehaviour
{
    public Transform playerTransform; 
    public float followDistance = 2.0f; 
    public float followSpeed = 5.0f;
    public float followSmoothness = 1f;

    private Vector3 targetPosition; 

    void Update()
    {
        Vector3 playerPosition = playerTransform.position;
        Vector3 offset = playerTransform.position - transform.position;
        offset = offset.normalized * followDistance;
        targetPosition = playerPosition - offset;

        Vector3 newPosition = Vector3.Lerp(transform.position, targetPosition, 1 - Mathf.Pow(1 - followSmoothness, Time.deltaTime * followSpeed));
        transform.position = newPosition;
    }
}