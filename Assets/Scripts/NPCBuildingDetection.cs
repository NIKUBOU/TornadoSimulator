using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBuildingDetection : MonoBehaviour
{
    [Header("NPC Stats")]
    [SerializeField] public float cooldownTimer;
    [SerializeField] public float cryingTime;
    [SerializeField] private bool emotional;
    [SerializeField] public bool crying;
    public GameManager gameManager;

    private float cryTime;
    private float coolTime;
    private bool addAlarm = false;

    private void Start()
    {
        cryTime = cryingTime;
        coolTime = cooldownTimer;
    }

    private void Update()
    {
        if (cooldownTimer > 0)
        {
            emotional = false;
            cooldownTimer -= Time.deltaTime;
        }
        else
            emotional = true;

        if (crying)
            Crying();
    }

    public void MakeCry()
    {
        if (emotional)
        {
            crying = true;
            addAlarm = true;
        }
    }

    private void Crying()
    {
        cryingTime -= Time.deltaTime;
        if (cryingTime <= 0)
        {
            crying = false;
            cryingTime = cryTime;
            cooldownTimer = coolTime;
        }
        if (addAlarm)
        {
            addAlarm = false;
            gameManager.ReceiveSignal("Signal2");
        }
    }
}
