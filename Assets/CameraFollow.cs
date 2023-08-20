using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public float FollowSpeed = 2f;

    public Transform target;
    void Start()
    {

    }

    void Update()
    {
        Vector3 newPost = new(target.position.x, target.position.y + 4f, -10f);
        transform.position = Vector3.Slerp(transform.position, newPost, FollowSpeed * Time.deltaTime);
    }
}
