using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEffect : MonoBehaviour
{
    [SerializeField] float effectDuration = 0.5f;
    [SerializeField] AudioClip explosionSound;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, effectDuration);
        AudioSource.PlayClipAtPoint(explosionSound, Camera.main.transform.position);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
