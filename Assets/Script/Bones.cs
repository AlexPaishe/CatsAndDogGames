using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bones : MonoBehaviour
{
    public bool cat;///����� ��� ������
    [SerializeField] private SpriteRenderer _sprite;///������ �����
    [SerializeField] private AudioSource _bonesEat;///�������� ����� ��������� ����� �������
    private bool _death = false;///������������ �����
    private BonesDoor _bones;///����� � ����������� ������
    private float _fade = 1.3f;///����� ������������
    private void Start()
    {
        _bones = FindObjectOfType<BonesDoor>();
        if(cat == true)
        {
            _bones.CatBones++;
        }
        else
        {
            _bones.DogBones++;
        }
    }

    /// <summary>
    /// ���������� ��������� ��������
    /// </summary>
    public void BonesMinus()
    {
        if (_death == false)
        {
            if (cat == true)
            {
                _bones.CatBones--;
            }
            else
            {
                _bones.DogBones--;
            }
            _death = true;
            _bonesEat.Play();
        }
    }

    private void Update()
    {
        if(_death == true)
        {
            _fade -= Time.deltaTime;
            _sprite.material.SetFloat("_Fade", _fade);
            if(_fade <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
