using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torndao : MonoBehaviour
{
    [SerializeField] private Transform center;
    [SerializeField] private float force;
    [SerializeField] private float refresh;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fly")
        {
            StartCoroutine(PullObject(other, true));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Fly")
        {
            StartCoroutine(PullObject(other, false));
        }
    }

    IEnumerator PullObject(Collider collider, bool pulled)
    {
        if (pulled)
        {
            Vector3 forceDir = center.position - collider.transform.position;
            collider.GetComponent<Rigidbody>().AddForce(forceDir.normalized * force * Time.deltaTime);
            yield return refresh;
            StartCoroutine(PullObject(collider, pulled));
        }
    }
}
