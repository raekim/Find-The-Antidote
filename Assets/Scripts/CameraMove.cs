using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] Camera camera;
    [SerializeField] GameObject gameObjectToFollow;
    [SerializeField] float leftLimit;
    [SerializeField] float rightLimit;
    [SerializeField] float upLimit;
    [SerializeField] float downLimit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveCamera();
    }

    public void MoveCamera()
    {
        Vector3 targetObjectPos = camera.WorldToViewportPoint(gameObjectToFollow.transform.position);

        if(targetObjectPos.x < leftLimit - 0.1f)
        {
            camera.transform.position += (Vector3)Vector2.left;
        }
        if (targetObjectPos.x > rightLimit + 0.1f)
        {
            camera.transform.position += (Vector3)Vector2.right;
        }
        if (targetObjectPos.y > upLimit + 0.1f)
        {
            camera.transform.position += (Vector3)Vector2.up;
        }
        if (targetObjectPos.y < downLimit - 0.1f)
        {
            camera.transform.position += (Vector3)Vector2.down;
        }
        
    }
}
