using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;

public class NPCMovement : MonoBehaviour
{
    [Header("AI Nav Agent")]
    [SerializeField] private NavMeshAgent agent;

    [Space(10)]
    [Header("AI Waypoints")]
    [SerializeField] private List<Transform> firstRow;
    [SerializeField] private List<Transform> secondRow;
    [SerializeField] private List<Transform> thirdRow;

    private Transform currentTarget;
    private bool crying = false;
    private bool groundCheck;

    // Start is called before the first frame update
    void Start()
    {
        int ranNum = Random.Range(0, 3);
        if (ranNum == 0)
        {
            ranNum = Random.Range(0, firstRow.Count);
            currentTarget = firstRow[ranNum];
        }
        else if(ranNum == 1)
        {
            ranNum = Random.Range(0, secondRow.Count);
            currentTarget = firstRow[ranNum];
        }
        else if (ranNum == 2)
        {
            ranNum = Random.Range(0, thirdRow.Count);
            currentTarget = firstRow[ranNum];
        }
    }

    // Update is called once per frame
    void Update()
    {
        crying = gameObject.GetComponent<NPCBuildingDetection>().crying;

        if (!crying)
            MoveNPC();
        else
            agent.SetDestination(gameObject.transform.position);
    }

    public Transform GetTargetTransform()
    { 
        return currentTarget; 
    }

    public void ChangeTarget(Transform transform)
    {
        foreach (Transform t in firstRow)
        {
            if (t == transform)
            {
                SetTargetFromRowOne(firstRow.IndexOf(t));
                break;
            }
        }

        foreach (Transform t in secondRow)
        {
            if (t == transform)
            {
                SetTargetFromRowTwo(secondRow.IndexOf(t));
                break;
            }
        }

        foreach (Transform t in thirdRow)
        {
            if (t == transform)
            {
                SetTargetFromRowThree(thirdRow.IndexOf(t));
                break;
            }
        }
    }

    private void SetTargetFromRowOne(int index)
    {
        if (index == 0)
        {
            int ranNum = Random.Range(0, 2);
            if (ranNum == 0)
            {
                currentTarget = firstRow[index + 1];
            }
            else if (ranNum == 1)
            {
                currentTarget = secondRow[index];
            }
        }
        else if (index == 1)
        {
            int ranNum = Random.Range(0, 3);
            if (ranNum == 0)
            {
                currentTarget = firstRow[index + 1];
            }
            else if (ranNum == 1)
            {
                currentTarget = firstRow[index - 1];
            }
            else if (ranNum == 2)
            {
                currentTarget = secondRow[index];
            }
        }
        else if (index == 2)
        {
            int ranNum = Random.Range(0, 2);
            if (ranNum == 0)
            {
                currentTarget = firstRow[index - 1];
            }
            else if (ranNum == 1)
            {
                currentTarget = secondRow[index];
            }
        }
    }

    private void SetTargetFromRowTwo(int index)
    {
        if (index == 0)
        {
            int ranNum = Random.Range(0, 3);
            if (ranNum == 0)
            {
                currentTarget = secondRow[index + 1];
            }
            else if (ranNum == 1)
            {
                currentTarget = firstRow[index];
            }
            else if (ranNum == 2)
            {
                currentTarget = thirdRow[index];
            }
        }
        else if (index == 1)
        {
            int ranNum = Random.Range(0, 4);
            if (ranNum == 0)
            {
                currentTarget = secondRow[index + 1];
            }
            else if (ranNum == 1)
            {
                currentTarget = secondRow[index - 1];
            }
            else if (ranNum == 2)
            {
                currentTarget = firstRow[index];
            }
            else if (ranNum == 3)
            {
                currentTarget = thirdRow[index];
            }
        }
        else if (index == 2)
        {
            int ranNum = Random.Range(0, 3);
            if (ranNum == 0)
            {
                currentTarget = secondRow[index - 1];
            }
            else if (ranNum == 1)
            {
                currentTarget = firstRow[index];
            }
            else if (ranNum == 2)
            {
                currentTarget = thirdRow[index];
            }
        }
    }

    private void SetTargetFromRowThree(int index)
    {
        if (index == 0)
        {
            int ranNum = Random.Range(0, 2);
            if (ranNum == 0)
            {
                currentTarget = thirdRow[index + 1];
            }
            else if (ranNum == 1)
            {
                currentTarget = secondRow[index];
            }
        }
        else if (index == 1)
        {
            int ranNum = Random.Range(0, 3);
            if (ranNum == 0)
            {
                currentTarget = thirdRow[index + 1];
            }
            else if (ranNum == 1)
            {
                currentTarget = thirdRow[index - 1];
            }
            else if (ranNum == 2)
            {
                currentTarget = secondRow[index];
            }
        }
        else if (index == 2)
        {
            int ranNum = Random.Range(0, 2);
            if (ranNum == 0)
            {
                currentTarget = thirdRow[index - 1];
            }
            else if (ranNum == 1)
            {
                currentTarget = secondRow[index];
            }
        }
    }

    private void MoveNPC()
    {
        agent.SetDestination(currentTarget.position);
    }

    public void ReWarp()
    {
        NavMeshHit navMeshHit;
        if(NavMesh.SamplePosition(gameObject.GetComponent<Rigidbody>().position, out navMeshHit, 0.5f, NavMesh.AllAreas)) 
        {
            agent.Warp(navMeshHit.position);
            agent.updatePosition = true;
            agent.SetDestination(navMeshHit.position);
        }
    }
}
