using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int movePixel = 128;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    // moves the player. if player bumps into another block then return that block.
    void Move()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += (Vector3)Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += (Vector3)Vector2.right;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.position += (Vector3)Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.position += (Vector3)Vector2.down;
        }
    }
}
