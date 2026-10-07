using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coinText;

    [Header("Level Complete")]
    [Tooltip("How many coins the player must collect to finish the level.")]
    [SerializeField] int coinsRequired = 8;
    [Tooltip("Panel shown when all coins are collected. Starts hidden.")]
    [SerializeField] GameObject levelCompletePanel;

    int coins;
    bool levelComplete;

    void Start()
    {
        if (levelCompletePanel != null)
        {
            levelCompletePanel.SetActive(false);
        }
        UpdateText();
    }

    public void IncreaseScore()
    {
        coins++;
        UpdateText();

        if (!levelComplete && coins >= coinsRequired)
        {
            ShowLevelComplete();
        }
    }

    void UpdateText()
    {
        coinText.text = "Coins: " + coins + " / " + coinsRequired;
    }

    void ShowLevelComplete()
    {
        levelComplete = true;

        if (levelCompletePanel != null)
        {
            levelCompletePanel.SetActive(true);
        }

        // pause the game so the robot stops moving behind the panel 
        Time.timeScale = 0f;

        // the third person controller locks the cursor, so free it to click the button 
        StarterAssets.StarterAssetsInputs input = FindFirstObjectByType<StarterAssets.StarterAssetsInputs>();
        if (input != null)
        {
            input.cursorLocked = false;
            input.cursorInputForLook = false;
        }
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}