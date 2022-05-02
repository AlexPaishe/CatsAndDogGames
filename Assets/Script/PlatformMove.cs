using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    public Rigidbody2D rb;
    [SerializeField] private Transform _trans;
    [SerializeField] private Transform[] _points;
    [SerializeField] private float _speed;
    [SerializeField] private AudioSource _kick;
    private Vector3 _target;
    private int _pos = 0;
    public int Pos
    {
        get
        {
            return _pos;
        }

        set
        {
            _pos = value;
            if(_pos > 1)
            {
                _pos = 0;
            }
            _target = _points[_pos].position;
        }
    }

    private void Awake()
    {
        Pos = 0;
    }

    private void Update()
    {
        if(_trans.position != _target)
        {
            _trans.position = Vector3.MoveTowards(_trans.position, _target, _speed * Time.deltaTime);          
        }
        else
        {
            Pos++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerMove>())
        {
            _kick.Play();
        }
    }
}
