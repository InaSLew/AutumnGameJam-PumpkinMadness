using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    public Transform followTarget;
    public Vector3 offset;
   
    private void moveCamera()
    {
        transform.position = new Vector3(followTarget.position.x + offset.x, followTarget.position.y + offset.y, followTarget.position.z + offset.z);
    }
    private void Update()
    {
        moveCamera();
    }
}
