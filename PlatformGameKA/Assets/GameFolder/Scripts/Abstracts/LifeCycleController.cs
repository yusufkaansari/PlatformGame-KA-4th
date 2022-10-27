using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LifeCycleController : MonoBehaviour
{
    [SerializeField] protected float maxLifeTime = 1f;

    float _currentTime;

    private void Update()
    {
        _currentTime += Time.deltaTime;
        if (_currentTime > maxLifeTime)
        {
            Destroy(this.gameObject);
        }
    }
}
