using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingStatus : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == "Destroyed" && other.tag == "NPC")
        {
            other.GetComponent<NPCBuildingDetection>().MakeCry();
        }
    }
}
