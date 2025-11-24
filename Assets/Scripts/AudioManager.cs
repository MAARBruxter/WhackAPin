using UnityEngine;

/// <summary>
/// Manages audio playback for the game.
/// </summary>
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Sources")]

    [Tooltip("Audio source for fruit collection sound.")]
    [SerializeField] private AudioSource bonkAudio;

    private void Awake()
    {
        //In case there was a different Instance created, is destroyed and a new one is created
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    /// <summary>
    /// Loads and plays the fruitAudio.
    /// </summary>
    public void BonkSound() => bonkAudio.Play();
}
