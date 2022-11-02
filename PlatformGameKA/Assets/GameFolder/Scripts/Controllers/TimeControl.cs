using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeControl : MonoBehaviour
{
    [SerializeField] Text timeValue;
    [SerializeField] float time;
    private bool gameActive;
    private void Start()
    {
        gameActive = true;
        timeValue.text = time.ToString();
    }
    private void Update()
    {
        if (gameActive == true)
        {
            time -= Time.deltaTime;
            timeValue.text = ((int)time).ToString();
        }
        if (time < 0)
        {
            time = 5;
            gameActive = false;
            GetComponent<PlayerController>().Die();
        }
    }
}
