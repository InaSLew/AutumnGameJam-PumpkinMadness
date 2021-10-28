using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 mousePos = Input.mousePosition;
            {
                // Debug.Log(mousePos.x);
                // Debug.Log(mousePos.y);
                mousePos.z = -13;
                Vector2 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
                Debug.Log($"X = {worldPosition.x}");
                Debug.Log($"Y = {worldPosition.y}");
                transform.position = worldPosition;
            }
        }
    }
}
