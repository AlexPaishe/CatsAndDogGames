using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishSystem : MonoBehaviour
{
    [SerializeField] private UiManager _ui;///������ �������� ����
    [SerializeField] private GameObject _menu;///���� ��������� ����
    [SerializeField] private TimerLevel _timer;///����� ������
    private int _final = 0;///� ������� ����� ������ �����
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
    /// ������������� �������� ������
    /// </summary>
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
