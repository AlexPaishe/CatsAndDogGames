using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerLevel : MonoBehaviour
{
    public bool go = true;
    [SerializeField] private Text _timerText;///Текст таймера
    [SerializeField] private Text _scoreText;///Текст очков
    [SerializeField] private Text _recordText;///Текст очков рекорда
    [SerializeField] private Text _recordTitle;///Текст таблички рекорда
    private float _timer;
    private float _record;

    public float Timer
    {
        get
        {
            return _timer;
        }

        set
        {
            _timer = value;
            float _t = Mathf.Round(_timer);
            _timerText.text = _t.ToString();
            _scoreText.text = _t.ToString();
        }
    }

    void Start()
    {
        Timer = PlayerPrefs.GetFloat($"Timer{SceneManager.GetActiveScene().buildIndex}");
        _record = PlayerPrefs.GetFloat($"Record{SceneManager.GetActiveScene().buildIndex}");
        if(_record == 0)
        {
            _recordText.text = "";
        }
        else
        {
            _record = Mathf.Round(_record);
            _recordText.text = _record.ToString();
        }
    }

    private void Update()
    {
        if (go == true)
        {
            Timer += Time.deltaTime;
        }
    }

    /// <summary>
    /// Реализация времени после смерти
    /// </summary>
    public void NextLive()
    {
        PlayerPrefs.SetFloat($"Timer{SceneManager.GetActiveScene().buildIndex}", Timer);
    }

    /// <summary>
    /// Реализация обнуления таймера
    /// </summary>
    public void NewLive()
    {
        PlayerPrefs.SetFloat($"Timer{SceneManager.GetActiveScene().buildIndex}", 0);
    }

    /// <summary>
    /// Реализация нового рекорда
    /// </summary>
    public void RecordSearch()
    {
        go = false;
        if(Timer < _record || _record == 0)
        {
            PlayerPrefs.SetFloat($"Record{SceneManager.GetActiveScene().buildIndex}", Timer);
            _recordTitle.text = "New Record";
        }
    }
}
