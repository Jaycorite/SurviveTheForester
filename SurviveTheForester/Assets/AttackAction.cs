using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AttackAction : AIAction
{
    PlayerController player;
    public int dmg;
    float attackInterval = 2f;
    float lastChange = 0;

    public override void TakeAction()
    {

        player = FindObjectOfType<PlayerController>();
        Debug.Log(Time.time);
        if (Time.time - lastChange > attackInterval)
        {
            
            if (player.Health > 0)
                player.Health -= dmg;
            else
            {
                Destroy(player.gameObject);
                SceneManager.LoadScene(0);
            }
            lastChange = Time.time;
        }
    }
}
