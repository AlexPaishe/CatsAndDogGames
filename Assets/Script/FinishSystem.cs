using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishSystem : MonoBehaviour
{
    [SerializeField] private UiManager _ui;///Скрипт игрового меню
    [SerializeField] private GameObject _menu;///Меню окончания игры
    [SerializeField] private TimerLevel _timer;///Время сессии
    private int _final = 0;///В сколько ворот прошёл игрок
    public int Final
    {
        get
        {
            return _final;
        }

        set
        {
            _final = value;
            if(_final == 2)
            {
                _ui.go = true;
                _menu.SetActive(true);
                Time.timeScale = 1;
                _timer.RecordSearch();
                PlayerPrefs.SetInt("Level", SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    public void Next()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /// <summary>
    /// Переигрывание текущего уровня
    /// </summary>
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
