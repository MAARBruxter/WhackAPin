using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Manages a group of pins that activate randomly over time.
/// </summary>
public class GroupPinController : MonoBehaviour
{
    [SerializeField] private GameObject[] pinGroup;
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private float delayTime = 1f;

    [SerializeField] private int MaxPins;

    private float timer;

    private void Update()
    {
        if (levelManager.IsGameOver)
        {

            // Deactivates all pins
            foreach (GameObject pin in pinGroup)
            {
                pin.SetActive(false);
            }

        } else {
            
            timer += Time.deltaTime;

            if (timer >= delayTime)
            {
                ActivateRandomPins();
                timer = 0f;
            }

        }
            
    }

    /// <summary>
    /// Activates a random number of pins from the group.
    /// </summary>
    private void ActivateRandomPins()
    {
        if (pinGroup.Length == 0) return;

        // Deactivates all pins first
        foreach (GameObject pin in pinGroup)
        {
            pin.SetActive(false);
        }

        // Decides how many pins to activate
        int pinsToActivate = Random.Range(1, Mathf.Min(MaxPins, pinGroup.Length) + 1);

        // List of indexes available for activation
        List<int> availableIndices = new List<int>();
        for (int i = 0; i < pinGroup.Length; i++)
            availableIndices.Add(i);

        // Activates random pins
        for (int i = 0; i < pinsToActivate; i++)
        {
            if (availableIndices.Count == 0) break;

            int randomListIndex = Random.Range(0, availableIndices.Count);
            int pinIndex = availableIndices[randomListIndex];
            availableIndices.RemoveAt(randomListIndex);

            pinGroup[pinIndex].SetActive(true);
        }
    }
}
