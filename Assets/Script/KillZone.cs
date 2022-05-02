using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillZone : MonoBehaviour
{
    private TimerLevel _timer;///Время сессии

    private void Awake()
    {
        _timer = FindObjectOfType<TimerLevel>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerMove>())
        {
            _timer.NextLive();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
