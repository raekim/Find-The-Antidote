using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathTimer : MonoBehaviour
{
    [SerializeField] int secondsToLive = 60;
    [SerializeField] Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DeathCountDown());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DeathCountDown()
    {
        for (; secondsToLive > 0; --secondsToLive)
        {
            UpdateTimeText();
            yield return new WaitForSeconds(1);
        }
        // count-down over
        UpdateTimeText();
        FindObjectOfType<Player>().GetComponent<Player>().Die();
    }

    void UpdateTimeText()
    {
        timeText.text = secondsToLive.ToString();
    }
}
