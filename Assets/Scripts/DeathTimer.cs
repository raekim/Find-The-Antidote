using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathTimer : MonoBehaviour
{
    [SerializeField] int secondsToLive = 60;
    [SerializeField] Text timeText;
    Coroutine deathTimerCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        deathTimerCoroutine = StartCoroutine(DeathCountDown());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StopDeathTimer()
    {
        StopCoroutine(deathTimerCoroutine);
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
        GameManager.Instance.GameOver();
    }

    void UpdateTimeText()
    {
        timeText.text = secondsToLive.ToString();
    }
}
