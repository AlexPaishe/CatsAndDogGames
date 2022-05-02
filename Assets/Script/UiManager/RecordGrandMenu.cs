using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordGrandMenu : MonoBehaviour
{
    [SerializeField] private Text[] _recordText;///текст рекордов
    [SerializeField] private GameObject[] _level;///Кнопки блокирующие выбор уровня

    private void Awake()
    {
        for(int i = 0; i < _recordText.Length; i++)
        {
            float record = PlayerPrefs.GetFloat($"Record{i + 1}");
            record = Mathf.Round(record);
            if (record != 0)
            {
                _recordText[i].text = record.ToString();
            }
            else
            {
                _recordText[i].text = "";
            }
        }
    }

    private void Start()
    {
        int level = PlayerPrefs.GetInt("Level");
        for (int i = 0; i < _level.Length; i++)
        {
            if (i < level)
            {
                _level[i].SetActive(false);
            }
        }
    }

    /// <summary>
    /// Реализация нового уровня
    /// </summary>
    public void NewGame()
    {
        for(int i = 1; i < 6; i++)
        {
            PlayerPrefs.SetFloat($"Timer{i}", 0);
        }
    }
}
