using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Torndao : MonoBehaviour
{
    [SerializeField] private Transform center;
    [SerializeField] private float force;
    [SerializeField] private float perpForceDirection;
    [SerializeField] private float refresh;

    private List<GameObject> objects = new List<GameObject> { };

    private bool pulled;

    private void OnTriggerEnter(Collider other)
    {
        if (!objects.Contains(other.gameObject))
        {
            objects.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (objects.Contains(other.gameObject))
        {
            objects.Remove(other.gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Structure")
        {
            other.GetComponent<BuildingHealth>().LoseHealth();
        }
    }

    IEnumerator PullObject(Collider collider)
    {
        while (pulled)
        {
            Vector3 forceDir = center.position - collider.transform.position;
            collider.GetComponent<Rigidbody>().AddForce(forceDir.normalized * force * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        yield return null;
    }

    private void FixedUpdate()
    {
        foreach (GameObject obj in objects)
        {
            if (obj.tag == "Fly")
            {
                Vector3 forceDir = center.position - obj.GetComponent<Collider>().transform.position;
                Vector3 perpForce = Vector3.Cross(forceDir.normalized, Vector3.up);
                obj.GetComponent<Collider>().GetComponent<Rigidbody>().AddForce((Vector3.Lerp(perpForce.normalized, forceDir.normalized, perpForceDirection)).normalized * force * Time.deltaTime);
            }
            else if (obj.tag == "NPC")
            {
                obj.GetComponent<NPCFlight>().FlyAway();
                Vector3 forceDir = center.position - obj.GetComponent<Collider>().transform.position;
                Vector3 perpForce = Vector3.Cross(forceDir.normalized, Vector3.up);
                obj.GetComponent<Collider>().GetComponent<Rigidbody>().AddForce((Vector3.Lerp(perpForce.normalized, forceDir.normalized, perpForceDirection)).normalized * force * Time.deltaTime);
            }
        }
    }
}
