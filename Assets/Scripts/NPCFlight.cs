using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCFlight : MonoBehaviour
{
    [SerializeField] private float characterHeight;
    [SerializeField] private bool groundCheck;
    [SerializeField] private LayerMask groundMask;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        groundCheck = Physics.Raycast(transform.position, Vector3.down, characterHeight * 0.5f + 0.2f, groundMask);

        if (groundCheck)
        {
            if (gameObject.tag == "Untagged")
            {
                gameObject.GetComponent<NPCMovement>().ReWarp();
            }
            gameObject.tag = "NPC";
            gameObject.GetComponent<NavMeshAgent>().enabled = true;
            gameObject.GetComponent<NPCMovement>().enabled = true;
        }
        else
        {
            gameObject.tag = "Untagged";
        }
    }

    public void FlyAway()
    {
        gameObject.GetComponent<NPCMovement>().enabled = false;
        gameObject.GetComponent<NavMeshAgent>().enabled = false;
        gameManager.ReceiveSignal("Signal2");
    }
}
