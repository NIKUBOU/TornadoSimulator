using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingHealth : MonoBehaviour
{
    [Header("Building Parts")]
    [SerializeField] private List<GameObject> structures;
    [SerializeField] private GameObject property;

    [Space(10)]
    [Header("Structure Stats")]
    [SerializeField] private float health = 100f;
    [SerializeField] private float healthLossRate = 0.5f;

    public void LoseHealth()
    {
        health -= Time.deltaTime * healthLossRate;
    }

    void Update()
    {
        if (health <= 50f)
        {
            structures[0].tag = "Fly";
        }
        if (health <= 25f)
        {
            structures[1].tag = "Fly";
        }
        if (health <= 0f)
        {
            structures[2].tag = "Fly";
            property.tag = "Destroyed";
        }
    }
}
