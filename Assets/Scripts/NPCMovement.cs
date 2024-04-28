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
    [SerializeField] private List<Transform> fourthRow;
    [SerializeField] private List<Transform> fifthRow;
    [SerializeField] private List<Transform> sixthRow;
    [SerializeField] private List<Transform> seventhRow;

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

        foreach (Transform t in fourthRow)
        {
            if (t == transform)
            {
                SetTargetFromRowFour(fourthRow.IndexOf(t));
                break;
            }
        }

        foreach (Transform t in fifthRow)
        {
            if (t == transform)
            {
                SetTargetFromRowFive(fifthRow.IndexOf(t));
                break;
            }
        }

        foreach (Transform t in sixthRow)
        {
            if (t == transform)
            {
                SetTargetFromRowSix(sixthRow.IndexOf(t));
                break;
            }
        }

        foreach (Transform t in seventhRow)
        {
            if (t == transform)
            {
                SetTargetFromRowSeven(seventhRow.IndexOf(t));
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
                currentTarget = secondRow[1];
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
                currentTarget = thirdRow[4];
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
                currentTarget = thirdRow[5];
            }
        }
    }

    private void SetTargetFromRowTwo(int index)
    {
        if (index == 0)
        {
            int ranNum = Random.Range(0, 2);
            if (ranNum == 0)
            {
                currentTarget = secondRow[index + 1];
            }
            else if (ranNum == 1)
            {
                currentTarget = thirdRow[1];
            }
        }
        else if (index == 1)
        {
            int ranNum = Random.Range(0, 3);
            if (ranNum == 0)
            {
                currentTarget = firstRow[0];
            }
            else if (ranNum == 1)
            {
                currentTarget = secondRow[index - 1];
            }
            else if (ranNum == 2)
            {
                currentTarget = thirdRow[3];
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
                currentTarget = fourthRow[0];
            }
        }
        else if (index == 1)
        {
            int ranNum = Random.Range(0, 4);
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
                currentTarget = secondRow[0];
            }
            else if (ranNum == 3)
            {
                currentTarget = fourthRow[1];
            }
        }
        else if (index == 2)
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
                currentTarget = fourthRow[2];
            }
        }
        else if (index == 3)
        {
            int ranNum = Random.Range(0, 4);
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
                currentTarget = secondRow[1];
            }
            else if (ranNum == 3)
            {
                currentTarget = fourthRow[3];
            }
        }
        else if (index == 4)
        {
            int ranNum = Random.Range(0, 4);
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
                currentTarget = firstRow[1];
            }
            else if (ranNum == 3)
            {
                currentTarget = fourthRow[4];
            }
        }
        else if (index == 5)
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
                currentTarget = firstRow[2];
            }
        }
        else if (index == 6)
        {
            int ranNum = Random.Range(0, 2);
            if (ranNum == 0)
            {
                currentTarget = fourthRow[5];
            }
            else if (ranNum == 1)
            {
                currentTarget = thirdRow[index - 1];
            }
        }
    }

    private void SetTargetFromRowFour(int index)
    {
        if (index == 0)
        {
            int ranNum = Random.Range(0, 3);
            if (ranNum == 0)
            {
                currentTarget = thirdRow[0];
            }
            else if (ranNum == 1)
            {
                currentTarget = fourthRow[index + 1];
            }
            else if (ranNum == 2)
            {
                currentTarget = sixthRow[0];
            }
        }
        else if (index == 1)
        {
            int ranNum = Random.Range(0, 4);
            if (ranNum == 0)
            {
                currentTarget = fourthRow[index + 1];
            }
            else if (ranNum == 1)
            {
                currentTarget = fourthRow[index - 1];
            }
            else if (ranNum == 2)
            {
                currentTarget = thirdRow[1];
            }
            else if (ranNum == 3)
            {
                currentTarget = fifthRow[0];
            }
        }
        else if (index == 2)
        {
            int ranNum = Random.Range(0, 4);
            if (ranNum == 0)
            {
                currentTarget = fourthRow[index + 1];
            }
            else if (ranNum == 1)
            {
                currentTarget = fourthRow[index - 1];
            }
            else if (ranNum == 2)
            {
                currentTarget = thirdRow[2];
            }
            else if (ranNum == 2)
            {
                currentTarget = fifthRow[1];
            }
        }
        else if (index == 3)
        {
            int ranNum = Random.Range(0, 4);
            if (ranNum == 0)
            {
                currentTarget = fourthRow[index + 1];
            }
            else if (ranNum == 1)
            {
                currentTarget = fourthRow[index - 1];
            }
            else if (ranNum == 2)
            {
                currentTarget = thirdRow[3];
            }
            else if (ranNum == 3)
            {
                currentTarget = fifthRow[2];
            }
        }
        else if (index == 4)
        {
            int ranNum = Random.Range(0, 4);
            if (ranNum == 0)
            {
                currentTarget = fourthRow[index + 1];
            }
            else if (ranNum == 1)
            {
                currentTarget = fourthRow[index - 1];
            }
            else if (ranNum == 2)
            {
                currentTarget = thirdRow[4];
            }
            else if (ranNum == 3)
            {
                currentTarget = fifthRow[3];
            }
        }
        else if (index == 5)
        {
            int ranNum = Random.Range(0, 2);
            if (ranNum == 0)
            {
                currentTarget = thirdRow[6];
            }
            else if (ranNum == 1)
            {
                currentTarget = fourthRow[index - 1];
            }
        }
    }

    private void SetTargetFromRowFive(int index)
    {
        if (index == 0)
        {
            int ranNum = Random.Range(0, 2);
            if (ranNum == 0)
            {
                currentTarget = fifthRow[index + 1];
            }
            else if (ranNum == 1)
            {
                currentTarget = fourthRow[1];
            }
        }
        else if (index == 1)
        {
            int ranNum = Random.Range(0, 4);
            if (ranNum == 0)
            {
                currentTarget = fifthRow[index + 1];
            }
            else if (ranNum == 1)
            {
                currentTarget = fifthRow[index - 1];
            }
            else if (ranNum == 2)
            {
                currentTarget = fourthRow[2];
            }
            else if (ranNum == 3)
            {
                currentTarget = sixthRow[1];
            }
        }
        else if (index == 2)
        {
            int ranNum = Random.Range(0, 4);
            if (ranNum == 0)
            {
                currentTarget = fifthRow[index + 1];
            }
            else if (ranNum == 1)
            {
                currentTarget = fifthRow[index - 1];
            }
            else if (ranNum == 2)
            {
                currentTarget = fourthRow[3];
            }
            else if (ranNum == 3)
            {
                currentTarget = sixthRow[2];
            }
        }
        else if (index == 3)
        {
            int ranNum = Random.Range(0, 3);
            if (ranNum == 0)
            {
                currentTarget = fifthRow[index + 1];
            }
            else if (ranNum == 1)
            {
                currentTarget = fifthRow[index - 1];
            }
            else if (ranNum == 2)
            {
                currentTarget = fourthRow[4];
            }
        }
        else if (index == 4)
        {
            int ranNum = Random.Range(0, 2);
            if (ranNum == 0)
            {
                currentTarget = sixthRow[3];
            }
            else if (ranNum == 1)
            {
                currentTarget = fifthRow[index - 1];
            }
        }
    }

    private void SetTargetFromRowSix(int index)
    {
        if (index == 0)
        {
            int ranNum = Random.Range(0, 2);
            if (ranNum == 0)
            {
                currentTarget = sixthRow[index + 1];
            }
            else if (ranNum == 1)
            {
                currentTarget = fourthRow[0];
            }
        }
        else if (index == 1)
        {
            int ranNum = Random.Range(0, 4);
            if (ranNum == 0)
            {
                currentTarget = sixthRow[index + 1];
            }
            else if (ranNum == 1)
            {
                currentTarget = sixthRow[index - 1];
            }
            else if (ranNum == 2)
            {
                currentTarget = fifthRow[1];
            }
            else if (ranNum == 3)
            {
                currentTarget = seventhRow[0];
            }
        }
        else if (index == 2)
        {
            int ranNum = Random.Range(0, 4);
            if (ranNum == 0)
            {
                currentTarget = sixthRow[index + 1];
            }
            else if (ranNum == 1)
            {
                currentTarget = sixthRow[index - 1];
            }
            else if (ranNum == 2)
            {
                currentTarget = fifthRow[2];
            }
            else if (ranNum == 3)
            {
                currentTarget = seventhRow[1];
            }
        }
        else if (index == 3)
        {
            int ranNum = Random.Range(0, 2);
            if (ranNum == 0)
            {
                currentTarget = fifthRow[4];
            }
            else if (ranNum == 1)
            {
                currentTarget = sixthRow[index - 1];
            }
        }
    }

    private void SetTargetFromRowSeven(int index)
    {
        if (index == 0)
        {
            int ranNum = Random.Range(0, 2);
            if (ranNum == 0)
            {
                currentTarget = seventhRow[index + 1];
            }
            else if (ranNum == 1)
            {
                currentTarget = sixthRow[1];
            }
        }
        else if (index == 1)
        {
            int ranNum = Random.Range(0, 2);
            if (ranNum == 0)
            {
                currentTarget = seventhRow[index - 1];
            }
            else if (ranNum == 1)
            {
                currentTarget = sixthRow[2];
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
