using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Player Stats")]
    public float sadnessValue = 0f;
    public float alarmValue = 0f;
    public float maxSadness = 100f;
    public float maxAlarm = 100f;

    [Header("Game Stats")]
    public float sadnessBonus = 1f;
    public float alarmIncrease = 5f;

    public delegate void SignalReceived();
    private Dictionary<string, SignalReceived> signalDictionary = new Dictionary<string, SignalReceived>();

    private string victorySceneName = "Win";
    private string loseSceneName = "Lose";

    //Sadness Event
    public void IncreaseSadness()
    {
        sadnessValue += sadnessBonus;
        Debug.Log("Sadness got increased");
    }

    //Alarm Event
    public void IncreaseAlarm()
    {
        alarmValue += alarmIncrease;
        Debug.Log("Alarm got increased");
    }


    // Call this function to simulate receiving a specific signal
    public void ReceiveSignal(string signalName)
    {
        if (signalDictionary.ContainsKey(signalName))
        {
            // Trigger the corresponding delegate
            signalDictionary[signalName]?.Invoke();
        }
    }

    // Subscribe to a signal's delegate when this object is enabled
    private void OnEnable()
    {
        // Subscribe to signals here
        SubscribeToSignal("Signal1", IncreaseSadness);
        SubscribeToSignal("Signal2", IncreaseAlarm);
    }

    // Unsubscribe from all signals when this object is disabled
    private void OnDisable()
    {
        // Create a list of signal names to avoid modifying the dictionary while iterating
        List<string> signalNames = new List<string>(signalDictionary.Keys);

        // Unsubscribe from signals here
        foreach (var signalName in signalNames)
        {
            var signalDelegate = signalDictionary[signalName];
            if (signalDelegate != null)
            {
                signalDelegate -= IncreaseAlarm;
                signalDictionary[signalName] = signalDelegate;
            }
        }
    }

    // Helper method to subscribe to a signal
    private void SubscribeToSignal(string signalName, SignalReceived signalDelegate)
    {
        // Add the delegate to the dictionary
        if (!signalDictionary.ContainsKey(signalName))
        {
            signalDictionary.Add(signalName, null);
        }

        // Subscribe to the delegate
        signalDictionary[signalName] += signalDelegate;
    }


    // Update is called once per frame
    void Update()
    {
        if (sadnessValue >= 100)
        {
            //SwitchToVictoryScene();
            SwitchToScene(victorySceneName);
        }

        if (alarmValue >= 100)
        {
            //SwitchToLoseScene();
            SwitchToScene(loseSceneName);
        }
    }

    /*void SwitchToVictoryScene()
    {
        Application.LoadLevel("Win");
    }*/

    /*void SwitchToLoseScene()
    {
        Application.LoadLevel("Lose");
    }*/
    void SwitchToScene(string sceneName)
    {
        // Load the specified scene
        Application.LoadLevel(sceneName);
    }

}

