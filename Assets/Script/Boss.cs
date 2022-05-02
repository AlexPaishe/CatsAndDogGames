using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private Transform[] _points; ///Точки перемещения
    [SerializeField] private Transform _trans;///Сам босс
    [SerializeField] private float _speed;///Скорость босса
    [SerializeField] private float _timer;///Время остановки на точке
    private float _timerStep = 0;///Таймер остановки
    private bool _forward = true;///Направление перемещения
    private int _step = 0;///На какой точке находится босс
    private Vector3 _target;///Расположение следующей точки перемещения

    public int Step
    {
        get
        {
            return _step;
        }

        set
        {
            _step = value;
            _target = _points[_step].position;
        }
    }

    public float TimerStep
    {
        get
        {
            return _timerStep;
        }

        set
        {
            _timerStep = value;
            if(_timerStep <= 0)
            {
                if(_forward == true && _step < _points.Length - 1)
                {
                    Step++;
                    _timerStep = _timer;
                }
                else if(_forward == true && _step == _points.Length - 1)
                {
                    _forward = false;
                    _trans.localScale = new Vector3(-1, 1, 1);
                    Step--;
                    _timerStep = _timer;
                }
                else if(_forward == false && _step > 0)
                {
                    Step--;
                    _timerStep = _timer;
                }
                else if(_forward == false && _step == 0)
                {
                    _forward = true;
                    _trans.localScale = Vector3.one;
                    Step++;
                    _timerStep = _timer;
                }
            }
        }
    }

    private void Update()
    {
        if(_trans.position == _target)
        {
            TimerStep -= Time.deltaTime;
        }
        else
        {
            _trans.position = Vector2.MoveTowards(_trans.position, _target, _speed * Time.deltaTime);
        }
    }

    private void Awake()
    {
        Step = 0;
    }
}
