using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesManager : MonoBehaviour
{
    public int maxLives = 3;
    public int currentLives;

    public Text livesText;

    public GameManager gameManager;

    private bool isDead;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        currentLives = maxLives;
        UpdateLivesUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoseLife()
    {
        if(currentLives > 0)
        {
            currentLives--;
            UpdateLivesUI();
        }

        if(currentLives <= 0 && !isDead)
        {
            isDead = true;
            player.SetActive(false);
            gameManager.gameOver();
            Debug.Log("Game Over!");
        }
        else
        {
            Debug.Log("Player lost a life. Remaining lives: " + currentLives);
        }
    }

    public void UpdateLivesUI()
    {
        if(livesText != null)
        {
            livesText.text = "Lives: " + currentLives;
        }
    }
}
