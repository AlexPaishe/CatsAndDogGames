using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GrandMenu : MonoBehaviour
{
    [SerializeField] private GameObject[] _windowMenu;///������ ����
    [SerializeField] private AudioSource _click;///���� �������� ������� �� �������
    [SerializeField] private Slider[] _sliders;///�������� ������
    [SerializeField] private Image[] _sliderFones;///������ ��� ��������
    [SerializeField] private string[] _sliderName;///��� �������� ��� ���������� �������� ����� �������
    [SerializeField] private AudioMixerGroup[] _mixer;///������ ������
    [SerializeField] private RecordGrandMenu _record;///������ ������

    private void Awake()
    {
        for (int i = 0; i < _windowMenu.Length; i++)
        {
            if (i == 1)
            {
                _windowMenu[i].SetActive(true);
            }
            else
            {
                _windowMenu[i].SetActive(false);
            }
        }

        Time.timeScale = 1;
        for (int i = 0; i < _sliders.Length; i++)
        {
            _sliders[i].value = PlayerPrefs.GetFloat(_sliderName[i]);
            _sliderFones[i].fillAmount = (_sliders[i].value + 50) / 50;
        }
    }

    private void Start()
    {
        for (int i = 0; i < _mixer.Length; i++)
        {
            _mixer[i].audioMixer.SetFloat(_sliderName[i], PlayerPrefs.GetFloat(_sliderName[i]));
        }
    }

    /// <summary>
    /// ���������� ��������� ����
    /// </summary>
    /// <param name="val"></param>
    public void Title(int val)
    {
        for (int i = 0; i < _windowMenu.Length; i++)
        {
            if (i == val)
            {
                _windowMenu[i].SetActive(true);
            }
            else
            {
                _windowMenu[i].SetActive(false);
            }
        }
    }

    /// <summary>
    /// ���������� ��������� ������� ������
    /// </summary>
    /// <param name="val"></param>
    public void PlayGame(int val)
    {
        _record.NewGame();
        SceneManager.LoadScene(val);
    }

    /// <summary>
    /// ���������� ���������� ����
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }

    /// <summary>
    /// ���������� ����� �����
    /// </summary>
    public void Click()
    {
        _click.Play();
    }

    /// <summary>
    /// ���������� �������� ������
    /// </summary>
    /// <param name="val"></param>
    public void MusicSlider(float val)
    {
        PlayerPrefs.SetFloat(_sliderName[1], val);
        _mixer[1].audioMixer.SetFloat(_sliderName[1], val);
        _sliderFones[1].fillAmount = (val + 50) / 50;
    }

    /// <summary>
    /// ���������� �������� ��������
    /// </summary>
    /// <param name="val"></param>
    public void EffectSlider(float val)
    {
        PlayerPrefs.SetFloat(_sliderName[0], val);
        _mixer[0].audioMixer.SetFloat(_sliderName[0], val);
        _sliderFones[0].fillAmount = (val + 50) / 50;
    }
}
