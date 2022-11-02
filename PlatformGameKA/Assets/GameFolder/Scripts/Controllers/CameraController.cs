using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform playerTransform;
    [SerializeField] float minX, maxX;

    private void Start()
    {
        playerTransform = GameObject.Find("Player").transform;
    }
    private void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(playerTransform.position.x, minX, maxX), transform.position.y, transform.position.z);
    }
}
