using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    public Transform followTarget;
    [SerializeField] private Vector3 offset;

    [SerializeField] private float maximumXFromCenter;
    [SerializeField] private float lowestY;
    [SerializeField] private float maximumY;

    private Vector3 targetVector3;
    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (player != null) MoveCameraV2();
    }
    
    
    
    private void MoveCameraV2()
    {
        transform.position = translateCoordinates();
    }

    
    
    private Vector3 translateCoordinates()
    {
        targetVector3 = followTarget.position;
        
        Vector3 temp = new Vector3();
        
        // Make sure the camera is set within the desired coordinates.
        // temp.x = Math.Max(Math.Min(targetVector3.x + offset.x, maximumXFromCenter), maximumXFromCenter * -1);
        // temp.y = Math.Max(Math.Min(targetVector3.y + offset.y, maximumY), lowestY);
        temp.x = Mathf.Clamp(targetVector3.x + offset.x, maximumXFromCenter * -1, maximumXFromCenter);
        temp.y = Mathf.Clamp(targetVector3.y + offset.y, lowestY, maximumY);
        temp.z = targetVector3.z + offset.z;
        return temp;
    }
}
