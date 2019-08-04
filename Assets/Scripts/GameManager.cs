using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] int pixelsPerUnit;
    [SerializeField] Text restartText;
    Dictionary<string, GameObject> GameObjectsDictionary = new Dictionary<string, GameObject>();
    bool isGameOver = false;

    static GameManager _instance;
    static public GameManager Instance { get { return _instance; } }

    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    void Start()
    {
        StartGame();
    }

    private void Update()
    {
        RestartGame();
    }

    public GameObject GetGameObjectAt(string keyString)
    {
        GameObject obj;
        if (GameObjectsDictionary.TryGetValue(keyString, out obj))
        {
            return obj;
        }
        else
        {
            return null as GameObject;
        }
    }

    public void RegisterGameObject(GameObject obj)
    {
        GameObjectsDictionary.Add(MakeDictionaryKey(obj.transform.position.x, obj.transform.position.y), obj);
    }

    public string MakeDictionaryKey(float xPos, float yPos)
    {
        string keyString = "x" + xPos.ToString() + "y" + yPos.ToString();
        return keyString;
    }

    public int GetPixelsPerUnit()
    {
        return pixelsPerUnit;
    }

    public void StartGame()
    {
        restartText.gameObject.SetActive(false); ;
    }
    
    public void GameOver()
    {
        StopAllCoroutines();
        isGameOver = true;

        // player dies
        FindObjectOfType<Player>().Die();

        // display "press (r) to restart" text
        restartText.gameObject.SetActive(true);
    }

    void RestartGame()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("R pressed");
            if (!isGameOver)
            {
                FindObjectOfType<Player>().Die();
                GameOver();
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            } 
        }
    }
}
