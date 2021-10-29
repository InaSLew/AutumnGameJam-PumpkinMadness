using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRotation : MonoBehaviour
{
    private GameObject player;
    private PlayerAttack weapon;
    
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        // weapon = transform.Find("PlayerWeapon").gameObject.GetComponent<PlayerAttack>();
        weapon = GetComponentInChildren<PlayerAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 0.5f,
            player.transform.position.z);
        // transform.position = player.transform.position;
        
        if (!weapon.weaponThrown)
        {
            
        
        
            Vector3 mousePos = Input.mousePosition;
        
            mousePos.z = 13;
            Vector3 worldPosition = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().ScreenToWorldPoint(mousePos);

            transform.right = worldPosition - transform.position;
        }
    }
}
