using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] int pixelsPerUnit;
    Dictionary<string, GameObject> GameObjectsDictionary = new Dictionary<string, GameObject>();

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
