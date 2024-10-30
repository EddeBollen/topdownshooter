using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] int playerHealth = 5;
    [SerializeField] float invincibilityTime = 2f;
    bool incincible = false;

    void DisableInvinciblity()
    {
        incincible = false;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if(incincible == true)
            {
                return;
            }
            if (playerHealth > 0)
            {
                playerHealth--;
                incincible = true;
                Invoke("DisableInvinciblity", invincibilityTime);
                Debug.Log("Player health;" + playerHealth);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        
    }
}
