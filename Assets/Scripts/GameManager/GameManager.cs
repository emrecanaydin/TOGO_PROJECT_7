using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    [Header("General Settings")]
    public bool isGameStarted = false;
    public bool isGameOver = false;

    [Header("Player Transform")]
    public Transform player;
    public Transform playerReflect;
    public Transform playerGhost;
    public Material playerTransparentMaterial;
    public Material playerMergedMaterial;
    public bool isPlayersMerged;

    [Header("Player Settings")]
    public float playerMoveSpeed;
    public float collectedHotdog;
    public float collectedHamburger;

    [Header("Score Panel References")]
    public TextMeshProUGUI hotdogText;
    public TextMeshProUGUI hamburgerText;

    [Header("Win Panel References")]
    public TextMeshProUGUI winPanelScoreText;

    [Header("Game Panels")]
    public GameObject winPanel;
    public GameObject lostPanel;

    void Update()
    {
        CheckClickAndStartGame();
        UpdateScore();
    }

    void CheckClickAndStartGame()
    {
        if (Input.GetMouseButton(0) && !isGameOver)
        {
            isGameStarted = true;
        }
    }

    void UpdateScore()
    {
        hotdogText.text = collectedHotdog.ToString();
        hamburgerText.text = collectedHamburger.ToString();
    }

    public void IncreaseCollectedByType(string type)
    {
        if(type == "CollectableHotDog")    { collectedHotdog = collectedHotdog + 1; }
        if(type == "CollectableHamburger") { collectedHamburger = collectedHamburger + 1; }
    }
    
    public float GetCollectedCount()
    {
        return collectedHotdog + collectedHamburger;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

}