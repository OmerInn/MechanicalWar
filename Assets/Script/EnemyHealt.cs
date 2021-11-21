using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealt : MonoBehaviour
{
    public float enemyHealth = 20f;
    public void DeductHealth(float deductHealth)
    {
        enemyHealth -= deductHealth;
        if (enemyHealth <= 0 ) { EnemyDead(); }
       
        void EnemyDead()
        {
            Destroy(gameObject);
        }
    }


}
