using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalPlayer : MonoBehaviour
{
    public bool CAT;
    [SerializeField] private PlayerMove _player;///������ ������
    public Transform trans;///��������� ������
    public Transform final;///��������� ����� ������������
    [SerializeField] private float _speed;///�������� ����������
    private bool _go = false;///����������� ����� ��� ��������
    private Vector3 _size;///������ ������
    private float _sizeDown = 1;///������ ������ � �������� ����������
    private int _minus = -1;///����������� ���������� ��� �����
    private bool _down = true;///������ �������� ��� ����������
    public bool Go
    {
        get
        {
            return _go;
        }

        set
        {
            _go = value;
            if(_go == true)
            {
                _player.rb.isKinematic = true;
                _player.rb.velocity = Vector2.zero;
                _player.anima.speed = 0;
                _size = trans.localScale;
                _player.move = false;
            }
            else
            {
                _player.rb.isKinematic = false;
                _player.anima.speed = 1;
                _player.move = true;
            }
        }
    }

    public float SizeDown
    {
        get
        {
            return _sizeDown;
        }

        set
        {
            _sizeDown = value;
            if(_sizeDown <= 1 && _sizeDown >= 0 && _down == true)
            {
                _minus = -1;
            }
            else if(_sizeDown <= 1 && _sizeDown >= 0 && _down == false)
            {
                _minus = 1;
            }
            else if(_sizeDown < 0)
            {
                _sizeDown = 0;
                _down = false;
                trans.position = final.position;
                _minus = 1;
            }
            else if(_sizeDown > 1)
            {
                _sizeDown = 1;
                _down = true;
                _minus = -1;
                Go = false;
            }
        }
    }

    private void Update()
    {
        if(Go == true)
        {
            SizeDown += _minus * Time.deltaTime * _speed;
            Vector3 SizeD = _size * SizeDown;
            trans.localScale = SizeD;
        }
    }
}
