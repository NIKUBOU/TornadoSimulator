using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillFloor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Untagged")
        {
            other.gameObject.transform.position = new Vector3(other.gameObject.transform.position.x, 100f, other.gameObject.transform.position.z);
        }
    }
}
