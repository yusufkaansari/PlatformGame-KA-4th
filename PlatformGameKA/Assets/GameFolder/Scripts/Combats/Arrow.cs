using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : LifeCycleController
{
    [SerializeField] GameObject dieEffect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            Instantiate(dieEffect, collision.gameObject.transform.position, Quaternion.identity);
        }
        if (collision.gameObject.tag == "Obstacle")
        {
            Destroy(gameObject);
        }
    }
}
