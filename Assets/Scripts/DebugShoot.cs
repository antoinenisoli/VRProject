using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DebugShoot : MonoBehaviour
{
    public LayerMask Targets;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    public void Fire()
    {
        Debug.Log("shoot");
        Ray rayShoot = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(rayShoot, out hit, Mathf.Infinity, Targets, QueryTriggerInteraction.Collide))
        {           
            hit.collider.gameObject.GetComponent<Target>().Hit = true;
        }
    }
}
