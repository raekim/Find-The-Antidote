using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text restartText;
    [SerializeField] Text winText;
    Dictionary<string, GameObject> GameObjectsDictionary = new Dictionary<string, GameObject>();
    bool isGameOver = false;
    bool isGameWon = false;

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
        GoToNextStage();
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

    public void StartGame()
    {
        winText.gameObject.SetActive(false);
    }
    
    public void GameOver()
    {
        StopGame();

        // player dies
        FindObjectOfType<Player>().Die();

        // display "press (r) to restart" text
        restartText.text = "Press (R) to restart";
    }

    private void StopGame()
    {
        FindObjectOfType<DeathTimer>().StopDeathTimer();
        isGameOver = true;
        FindObjectOfType<Player>().enabled = false;
    }

    public void WinGame()
    {
        StopGame();
        FindObjectOfType<Player>().TakeAntidote();
        winText.gameObject.SetActive(true);
        isGameWon = true;

        
    }

    void GoToNextStage()
    {
        if (isGameWon)
        {
            // press enter to load the next scene
            if (Input.GetKeyDown(KeyCode.Return))
            {
                // load the next scene in build order
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }

    void RestartGame()
    {
        if (!isGameWon && Input.GetKeyDown(KeyCode.R))
        {
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
