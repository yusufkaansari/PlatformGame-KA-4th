using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float _mySpeedX;
    Rigidbody2D _myBody;
    Vector3 _defaultLocalScale;
    bool _canDoubleJump;
    float _attackDelayTime = 1f;
    float _currentDelayTime;
    bool _canAttack = false;
    Animator _animator;

    [SerializeField] float speed;
    [SerializeField] float jumpPower;
    [SerializeField] GameObject arrowPrefab;
    [SerializeField] GameObject arrowParent;
    [SerializeField] float arrowSpeed;

    public bool onGround;

    private void Start()
    {
        _myBody = GetComponent<Rigidbody2D>();
        _defaultLocalScale = transform.localScale;
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _mySpeedX = Input.GetAxis("Horizontal");
        _animator.SetFloat("Speed", Mathf.Abs(_mySpeedX));

        _myBody.velocity = new Vector2(_mySpeedX * speed, _myBody.velocity.y);
        
        SetPlayerFace(_mySpeedX);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpAction();
        }

        _currentDelayTime += Time.deltaTime;
        if (_currentDelayTime > _attackDelayTime)
        {
            _canAttack = true;
            _currentDelayTime = 0;
        }


        if (Input.GetMouseButtonDown(0))
        {
            if (_canAttack)
            {
                _animator.SetTrigger("Attack");
                Invoke("SpawnArrow", 0.5f);
                _canAttack = false;
            }
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            _animator.SetTrigger("Die");
            enabled = false;
        }

    }
    void SpawnArrow()
    {
        GameObject myArrow = Instantiate(arrowPrefab, transform.position, Quaternion.identity);
        myArrow.transform.parent = arrowParent.transform;
        if (transform.localScale.x >0)
        {
            myArrow.GetComponent<Rigidbody2D>().velocity = new Vector3(arrowSpeed, 0f);
        }
        else
        {
            myArrow.transform.localScale = new Vector3(-myArrow.transform.localScale.x, myArrow.transform.localScale.y, myArrow.transform.localScale.z);
            myArrow.GetComponent<Rigidbody2D>().velocity = new Vector3(-arrowSpeed, 0f);            
        }
        
    }
    void JumpAction()
    {
        if (onGround == true)
        {
            _animator.SetTrigger("Jump");
            _myBody.velocity = new Vector2(_myBody.velocity.x, jumpPower);
            _canDoubleJump = true;
            
        }
        else
        {
            if (_canDoubleJump == true)
            {
                _myBody.velocity = new Vector2(_myBody.velocity.x, jumpPower);
                _canDoubleJump = false;
            }
        }
    }


    void SetPlayerFace(float mySpeedX)
    {
        if (_mySpeedX > 0)
        {
            transform.localScale = new Vector3(_defaultLocalScale.x, _defaultLocalScale.y, _defaultLocalScale.z);
        }
        else if (_mySpeedX < 0)
        {
            transform.localScale = new Vector3(-_defaultLocalScale.x, _defaultLocalScale.y, _defaultLocalScale.z);
        }
    }
}
