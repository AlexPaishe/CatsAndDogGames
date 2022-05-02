using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public bool go = false;
    [SerializeField] private GameObject[] _menus;///Меню в игре
    [SerializeField] private Slider[] _sliders;///Слайдеры звуков
    [SerializeField] private Image[] _sliderFones;///Задний фон слайдеров
    [SerializeField] private AudioSource _click;///Звук клика
    [SerializeField] private string[] _sliderName;///Имя слайдеров для сохранения значений между сценами
    [SerializeField] private AudioMixerGroup[] _mixer;///Микшер звуков 

    private void Awake()
    {
        Time.timeScale = 1;
        for(int i = 0; i < _sliders.Length; i++)
        {
            _sliders[i].value = PlayerPrefs.GetFloat(_sliderName[i]);
            _sliderFones[i].fillAmount = (_sliders[i].value + 50) / 50;
        }
    }

    private void Start()
    {
        for(int i = 0; i < _mixer.Length; i++)
        {
            _mixer[i].audioMixer.SetFloat(_sliderName[i], PlayerPrefs.GetFloat(_sliderName[i]));
        }
    }

    /// <summary>
    /// Реализация клика
    /// </summary>
    public void Click()
    {
        _click.Play();
    }

    /// <summary>
    /// Реализация включения и выключения меню настроек
    /// </summary>
    /// <param name="var"></param>
    public void Setting(int var)
    {
        for (int i = 0; i < _menus.Length; i++)
        {
            if (i == var)
            {
                _menus[i].SetActive(true);
            }
            else
            {
                _menus[i].SetActive(false);
            }
        }
    }

    /// <summary>
    /// Реализация возвращение в игру
    /// </summary>
    public void PlayGame()
    {
        _menus[0].SetActive(false);
        Time.timeScale = 1;
    }

    /// <summary>
    /// Реализация слайдера музыки
    /// </summary>
    /// <param name="val"></param>
    public void MusicSlider(float val)
    {
        PlayerPrefs.SetFloat(_sliderName[1], val);
        _mixer[1].audioMixer.SetFloat(_sliderName[1], val);
        _sliderFones[1].fillAmount = (val + 50) / 50;
    }

    /// <summary>
    /// Реализация слайдера эффектов
    /// </summary>
    /// <param name="val"></param>
    public void EffectSlider(float val)
    {
        PlayerPrefs.SetFloat(_sliderName[0], val);
        _mixer[0].audioMixer.SetFloat(_sliderName[0], val);
        _sliderFones[0].fillAmount = (val + 50) / 50;
    }

    /// <summary>
    /// Выход в главное меню
    /// </summary>
    public void Quit()
    {
        SceneManager.LoadScene(0);
    }

    private void Update()
    {
        if (go == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape) && _menus[0].activeSelf == false && _menus[1].activeSelf == false)
            {
                Time.timeScale = 0;
                _menus[0].SetActive(true);
            }
            else if (Input.GetKeyDown(KeyCode.Escape) && _menus[0].activeSelf || Input.GetKeyDown(KeyCode.Escape) && _menus[1].activeSelf)
            {
                Time.timeScale = 1;
                for (int i = 0; i < _menus.Length; i++)
                {
                    _menus[i].SetActive(false);
                }
            }
        }
    }
}
