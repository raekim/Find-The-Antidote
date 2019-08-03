using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGameObject : MonoBehaviour
{
    // Start is called before the first frame update
    protected void Start()
    {
        GameManager.Instance.RegisterGameObject(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
