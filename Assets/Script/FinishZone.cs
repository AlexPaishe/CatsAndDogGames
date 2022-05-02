using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishZone : MonoBehaviour
{
    public bool go = false;///������ �� ����� ������ ���������� ������
    [SerializeField] private bool _cats;///����� ����� ��� �����
    [SerializeField] private GameObject _obj;///����������� �����(����� ��� ������)
    [SerializeField] private AudioSource _finishSound;///�������� �������� 
    [SerializeField] private AudioClip[] _sound;///����� ��� � ��
    private FinishSystem _finish;///������� �������� ������
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
