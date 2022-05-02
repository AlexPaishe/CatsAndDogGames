using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private Portal _twoPortal;///������ ������
    [SerializeField] private SpriteRenderer _rend;///������ �������� �������
    [SerializeField] private float _speed;///�������� �������� �������
    public bool cat = false;///����� �� ��������������� ������ ������ ����
    public bool dog = false;///����� �� ��������������� ������ ������ ���
    public bool fire = false;///������������� �� ������ ������ ������
    private float _fireStrenght = 0;///�������� �������
    private int _minus = 1;///����������� �������� - ��������� ��� ��������
    private bool _down = false;///������ �������� ��� ����������� ��������
    public float FireStrenght
    {
        get
        {
            return _fireStrenght;
        }

        set
        {
            _fireStrenght = value;
            _rend.material.SetFloat("_ColorStrenght", _fireStrenght);
            if (_fireStrenght <= 1 && _fireStrenght >= 0 && _down == false)
            {
                _minus = 1;
            }
            else if(_fireStrenght <= 1 && _fireStrenght >= 0 && _down == true)
            {
                _minus = -1;
            }
            else if(_fireStrenght > 1)
            {
                _down = true;
                _minus = -1;
            }
            else if(_fireStrenght < 0)
            {
                _down = false;
                _minus = 1;
                _fireStrenght = 0;
                _rend.material.SetFloat("_ColorStrenght", _fireStrenght);
                fire = false;
            }
        }
    }
    private void Update()
    {
        if(fire == true)
        {
            FireStrenght += _minus * Time.deltaTime * _speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PortalPlayer>())
        {
            if (collision.gameObject.GetComponent<PortalPlayer>().CAT == true)
            {
                if (cat == false)
                {
                    _twoPortal.cat = true;
                    PortalPlayer players = collision.gameObject.GetComponent<PortalPlayer>();
                    fire = true;
                    players.final = _twoPortal.transform;
                    players.Go = true;
                    players.trans.position = transform.position;
                }
                else
                {
                    fire = true;
                }
            }
            else
            {
                if (dog == false)
                {
                    _twoPortal.dog = true;
                    PortalPlayer players = collision.gameObject.GetComponent<PortalPlayer>();
                    fire = true;
                    players.final = _twoPortal.transform;
                    players.Go = true;
                    players.trans.position = transform.position;
                }
                else
                {
                    fire = true;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PortalPlayer>())
        {
            if(collision.gameObject.GetComponent<PortalPlayer>().CAT == true)
            {
                cat = false;
            }
            else
            {
                dog = false;
            }
        }
    }
}
