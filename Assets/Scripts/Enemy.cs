using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] int damage;
    [SerializeField] bool isAFighter;
    [SerializeField] GameObject attackEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetEnemyAttackEffect()
    {
        if (isAFighter)
        {
            return attackEffect;
        }
        else
        {
            return null;
        }
    }

    public int GetEnemyDamage()
    {
        if (isAFighter)
        {
            return damage;
        }
        else
        {
            return 0;
        }
    }

    // can this enemy fight back?
    public bool IsFighter()
    {
        return isAFighter;
    }

    public void TakeHit(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            // Enemy dies
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
