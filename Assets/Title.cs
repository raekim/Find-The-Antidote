using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    [SerializeField] GameObject explosioinEffect;
    [SerializeField] Transform explosionPosition;

    bool gameStarted = false;
    float startTime;
    float waitTime = 0.7f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartInPut();
        WaitAndStart();
    }

    private void StartInPut()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Instantiate(explosioinEffect, explosionPosition.position + new Vector3(0,0,-1), Quaternion.identity);
            gameStarted = true;     
        }
    }

    void WaitAndStart()
    {
        if (gameStarted)
        {
            startTime += Time.deltaTime;
            if(startTime >= waitTime)
            {
                // load the next scene in build order
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
            
    }
}
