using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishZone : MonoBehaviour
{
    public bool go = false;///Собрал ли игрок нужное количество костей
    [SerializeField] private bool _cats;///Дверь кошек или собак
    [SerializeField] private GameObject _obj;///Обозначение двери(кость над дверью)
    [SerializeField] private AudioSource _finishSound;///Звуковой источник 
    [SerializeField] private AudioClip[] _sound;///Звуки нет и да
    private FinishSystem _finish;///Система финишных дверей
    private void Awake()
    {
        _finish = FindObjectOfType<FinishSystem>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMove>())
        {
            if (collision.gameObject.GetComponent<PlayerMove>().cats == _cats && go == true)
            {
                _finish.Final++;
                PlayerMove player = collision.gameObject.GetComponent<PlayerMove>();
                player.Go = true;
                player.rb.isKinematic = true;
                player.anima.speed = 0;
                _obj.SetActive(false);
                _finishSound.clip = _sound[0];
                _finishSound.Play();
            }
            else if (collision.gameObject.GetComponent<PlayerMove>())
            {
                _finishSound.clip = _sound[1];
                _finishSound.Play();
            }
        }
    }
}
