using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bones : MonoBehaviour
{
    public bool cat;///Кошка или собака
    [SerializeField] private SpriteRenderer _sprite;///Рендер кости
    [SerializeField] private AudioSource _bonesEat;///Источних звука собирания кости игроком
    private bool _death = false;///Исчезновение кости
    private BonesDoor _bones;///Дверь с количеством костей
    private float _fade = 1.3f;///число исчезновения
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
    /// Реализация подымания косточки
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
