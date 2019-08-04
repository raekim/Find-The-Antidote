using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackEffect : MonoBehaviour
{
    [SerializeField] float effectDuration = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, effectDuration);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
