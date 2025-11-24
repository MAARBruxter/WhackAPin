using UnityEngine;

/// <summary>
/// Keeps the game state (score and total kegels) across scenes
/// Singleton pattern + DontDestroyOnLoad so can be read in other scenes
/// </summary>
[DefaultExecutionOrder(-100)] //Ensure this initialize before other scripts 
public class GameManager : MonoBehaviour
{
    //Singleton public read-only
    public static GameManager Instance { get; private set; }
    

    private int score;

    //public Read-only accesors
    [HideInInspector]
    public int Score => score;

    private void Awake()
    {
        //Singleton pattern
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    

    /// <summary>
    /// Sets the score, used when the kegel enters in the win box area
    /// </summary>
    /// <param name="value"></param>
    public void SetScore(int value)
    {
        score = value;
    }

    /// <summary>
    /// Reset the game values
    /// </summary>
    public void ResetGame()
    {
        score = 0;
    }
}
