using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Enemy))]

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int MaxHitPoints = 5;
    [Tooltip("Ramp of Difficulty")]
    [SerializeField] int difficultyRound = 1;
    int currentHitPoints = 0;

    Enemy enemy;
    void OnEnable()
    {
        currentHitPoints = MaxHitPoints;
    }

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    void ProcessHit()
    {
        currentHitPoints --;
        if(currentHitPoints <= 0)
        {
            gameObject.SetActive(false);
            MaxHitPoints += difficultyRound;
            enemy.RewardGold();

        }
    }
    
}
