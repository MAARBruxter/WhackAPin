using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages the mute function of the game, muting the audio of the game by pressing the sound icon.
/// </summary>
public class AudioToggleButtonController : MonoBehaviour
{
    [Header("UI Elements")]
    public Image audioIconImage;

    [Header("Icons")]
    public Sprite soundOnSprite;
    public Sprite soundOffSprite;

    /// <summary>
    /// Called when the object is first initialized. Ensures the icon matches the current audio state.
    /// </summary>
    void Start()
    {
        UpdateIcon();
    }

    /// <summary>
    /// Public function that should be called when the UI button is pressed. Toggles the audio between muted and unmuted.
    /// </summary>
    public void ToggleAudio()
    {
        AudioListener.volume = (AudioListener.volume == 0f) ? 1f : 0f;
        UpdateIcon();
    }

    /// <summary>
    /// Updates the UI icon according to the current audio state. Shows the "sound off" sprite when muted and the "sound on" sprite when unmuted.
    /// </summary>
    private void UpdateIcon()
    {
        if (AudioListener.volume == 0f)
            audioIconImage.sprite = soundOffSprite;
        else
            audioIconImage.sprite = soundOnSprite;
    }
}
