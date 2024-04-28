using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NPCWaypoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NPC")
        {
            Debug.Log("NPC Contact");
            NPCMovement movement = other.GetComponent<NPCMovement>();
            if (gameObject.transform.position == movement.GetTargetTransform().position)
            {
                movement.ChangeTarget(gameObject.transform);
            }
        }
    }
}
