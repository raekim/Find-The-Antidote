using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject PlayerAttackEffect;
    [SerializeField] int health;
    [SerializeField] int damage = 1;
    [SerializeField] Sprite normalSprite;   // sprite of the character after taking the antidote
    [SerializeField] Text healthText;
    [SerializeField] bool isHealthStage;
    CameraMove playerCamera;

    private void Start()
    {
        playerCamera = GetComponent<CameraMove>();
        if(isHealthStage)
            UpdateHealthText();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    // moves the player. if player bumps into another block then return that block.
    void Move()
    {
        Vector3 newPosVector = transform.position;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            newPosVector += (Vector3)Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            newPosVector += (Vector3)Vector2.right;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            newPosVector += (Vector3)Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            newPosVector += (Vector3)Vector2.down;
        }

        if(newPosVector != transform.position)
        {
            ProcessMovingToNewPosition(newPosVector);
            playerCamera.MoveCamera();
        }
        
    }

    private void ProcessMovingToNewPosition(Vector3 newPosVector)
    {
        // get the object that is in the way of the player
        GameObject objectInTheWay = GameManager.Instance.GetGameObjectAt(GameManager.Instance.MakeDictionaryKey(newPosVector.x, newPosVector.y));
        Debug.Log(objectInTheWay);
        if (objectInTheWay == null)
        {
            // walking into the air
            // object below the target
            GameObject objectBelow = GameManager.Instance.GetGameObjectAt(GameManager.Instance.MakeDictionaryKey(newPosVector.x, newPosVector.y - 1));
            if (objectBelow != null && (objectBelow.tag == "Wall" || objectBelow.tag == "Walkable"))
            {
                MovePlayerToPosition(newPosVector);
            }
        }
        else
        {
            switch (objectInTheWay.tag)
            {
                case "Wall":
                    // player cannot move in the direction of a wall
                    break;
                case "Attackable":
                    // attack the other object
                    Attack(objectInTheWay);
                    break;
                case "Walkable":
                case "Antidote":
                    MovePlayerToPosition(newPosVector);
                    if(objectInTheWay.tag == "Antidote")
                    {
                        Destroy(objectInTheWay);
                        if (objectInTheWay.GetComponent<Antidote>().isRealAntidote())
                        {
                            GameManager.Instance.WinGame();
                        }
                        else
                        {
                            GameManager.Instance.GameOver();
                        }
                    }
                    break;
                default:                  
                    break;
            }
        }
        
    }

    private void Attack(GameObject objectInTheWay)
    {
        Enemy enemy = objectInTheWay.GetComponent<Enemy>();
        // player attack effect
        Instantiate(PlayerAttackEffect, objectInTheWay.transform.position + new Vector3(0, 0, -1), Quaternion.identity);
        //  deal damage to the enemy
        enemy.TakeHit(damage);

        // take damage from the enemy
        if (enemy.IsFighter())
        {
            // enemy attack effect
            Instantiate(enemy.GetEnemyAttackEffect(), transform.position + new Vector3(0, 0, -1), Quaternion.identity);
            TakeHit(enemy.GetEnemyDamage());
        }
    }

    void TakeHit(int damage)
    {
        health -= damage;
        UpdateHealthText();
        if (health <= 0)
        {
            GameManager.Instance.GameOver();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void TakeAntidote()
    {
        // go back to normal
        GetComponent<SpriteRenderer>().sprite = normalSprite;
    }

    private void MovePlayerToPosition(Vector3 newPosVector)
    {
        transform.position = newPosVector;
    }

    void UpdateHealthText()
    {
        healthText.text = "HP : " + health.ToString();
    }
}
