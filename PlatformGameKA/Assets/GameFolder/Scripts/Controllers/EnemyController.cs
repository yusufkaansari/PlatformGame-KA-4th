using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{    
    float width;
    Rigidbody2D myBody;

    [SerializeField] float speed;
    [SerializeField] LayerMask layerMask;

    static int totalEnemyNumber;
    private void Start()
    {
        totalEnemyNumber++;
        width = GetComponent<SpriteRenderer>().bounds.extents.x;
        myBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + (transform.right * width/2), Vector2.down, 2f,layerMask);
        SetOnGround(hit);

        myBody.velocity = new Vector2(transform.right.x * speed, 0f);
        
    }

    // çizgi çizmek için kullanýlan bir method.
    private void OnDrawGizmos()
    {
        Vector3 temp = transform.position;
        temp = temp + (transform.right * width / 2);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(temp, temp + new Vector3(0, -2f, 0));
    }

    void SetOnGround(RaycastHit2D hit2D)
    {
        if (hit2D.collider == null)
        {
            transform.eulerAngles += new Vector3(0, 180f, 0);
        }
    }
}
