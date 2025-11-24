using UnityEngine;
using UnityEngine.InputSystem;

public enum PinType
{
    Good,
    Bad
}

/// <summary>
/// Indicates whether the pin is good or bad and handles hit detection.
/// </summary>
[RequireComponent(typeof(SpriteRenderer), typeof(Collider2D))]
public class PinController : MonoBehaviour
{
    [Header("Sprites")]
    public Sprite goodSprite;
    public Sprite badSprite;

    private SpriteRenderer sr;
    private PinType pinType;
    private bool hasBeenHit = false;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        hasBeenHit = false;

        // Assings a random type and updates the sprite
        pinType = (Random.value > 0.5f) ? PinType.Good : PinType.Bad;
        UpdateSprite();
    }

    private void Update()
    {
        // Touchscreen or mouse input detection
        bool wasPressed = false;

        if (Touchscreen.current != null)
        {
            wasPressed = Touchscreen.current.primaryTouch.press.wasPressedThisFrame;
        }

#if UNITY_EDITOR
        Mouse mouse = Mouse.current;
        if (mouse != null && mouse.leftButton.wasPressedThisFrame)
            wasPressed = true;
#endif


        if (wasPressed)
        {
            // Click or touch position
            Vector2 screenPos;
            if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
            {
                screenPos = Touchscreen.current.primaryTouch.position.ReadValue();
            }
            else
            {
                screenPos = Input.mousePosition;
            }

            Vector2 worldPos = Camera.main.ScreenToWorldPoint(screenPos);

            // Raycast in world position
            RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == this.gameObject)
            {
                HitPin();
            }
        }
    }

    /// <summary>
    /// Updates the sprite based on the pin type.
    /// </summary>
    private void UpdateSprite()
    {
        if (sr == null) sr = GetComponent<SpriteRenderer>();

        if (pinType == PinType.Good)
            sr.sprite = goodSprite;
        else
            sr.sprite = badSprite;
    }

    /// <summary>
    /// Adds or subtracts score based on pin type when hit.
    /// </summary>
    private void HitPin()
    {
        // Avoids multiple hits
        if (!gameObject.activeInHierarchy || hasBeenHit) return;

        hasBeenHit = true;

        AudioManager.Instance.BonkSound();
        if (pinType == PinType.Good)
        {
            GameManager.Instance.SetScore(
                GameManager.Instance.Score + LevelManager.Instance.GetGoodScore()
            );
        }
        else
        {
            GameManager.Instance.SetScore(
                GameManager.Instance.Score - LevelManager.Instance.GetBadScore()
            );
        }


        // Deactivates the GroupPinController
        gameObject.SetActive(false);
    }
}
