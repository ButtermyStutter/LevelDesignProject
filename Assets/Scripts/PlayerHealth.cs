using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float playerHealth;
    public Text healthText;
    public float playerMaxHealth = 100;

    // THIS SCRIPT ALSO CONTAINS RESPAWN INFO FOR THE PLAYER
    //public GameObject currentCheckpoint;
    public float respawnDelay = 3.0f;
    public Respawner respawn;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = playerMaxHealth;
        healthText.text = "Health: " + playerHealth;
        //currentCheckpoint = GameObject.FindGameObjectWithTag("StartPoint");
    }

    // Update is called once per frame
    void Update()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + playerHealth;

            if (playerHealth <= 0)
            {
                playerHealth = 0;
                playerDeath();
            }
        }
    }

    public void playerDeath()
    {
        // death stuff
        // Set a delay
        Invoke("RespawnFromDeath", respawnDelay);

    }

    void RespawnFromDeath()
    {
        respawn.RespawnPlayer();
        playerHealth = playerMaxHealth;
    }
}
