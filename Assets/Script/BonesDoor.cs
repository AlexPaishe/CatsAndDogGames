using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BonesDoor : MonoBehaviour
{
    [SerializeField] private TextMeshPro[] _text;///����� ���������� ������
    [SerializeField] private FinishZone[] _finish;///������� ������
    private int _catBones = 0;///���������� ������� �����
    private int _dogBones = 0;///���������� ������� ������
    public int CatBones
    {
        get
        {
            return _catBones;
        }

        set
        {
            _catBones = value;
            _text[0].text = $"{_catBones}";
            if(_catBones == 0)
            {
                _finish[0].go = true;
            }
        }
    }

    public int DogBones
    {
        get
        {
            return _dogBones;
        }

        set
        {
            _dogBones = value;
            _text[1].text = $"{_dogBones}";
            if(_dogBones == 0)
            {
                _finish[1].go = true;
            }
        }
    }
}
