using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public bool cats;///Кошка или собака
    public bool move = true;///Телепортируется или нет
    public Rigidbody2D rb;///Физика объекта
    public Animator anima;///Анимация объекта
    public float size = 1;///Размер Объекта
    [SerializeField] private Transform _trans;///Трансформ игрока
    [SerializeField] private float _speed;///Скорость перемещения
    [SerializeField] private float _jumpSpeed;///Сила прыжка
    [SerializeField] private SpriteRenderer[] _renders;///Рендер игрока
    private bool _jump = true;///Прыгнул ли игрок
    private float _fade = 1.5f;///Исчезновение игрока
    private bool go = false;///переместился ли игрок в следующий уровень
    private bool _plat = false;///Если игрок врезается в стену - как в главном меню

    public bool Go
    {
        get
        {
            return go;
        }

        set
        {
            go = value;
            if(go == true)
            {
                rb.isKinematic = true;
            }
        }
    }
    private void FixedUpdate()
    {
        if (move == true)
        {
            if (go == false)
            {
                if (cats == true)
                {
                    CatsMove();
                }
                else
                {
                    DogMove();
                }
            }
        }
    }

    private void Update()
    {
        if(go == true)
        {
            _fade -= Time.deltaTime;
            for(int i = 0; i < _renders.Length; i++)
            {
                _renders[i].material.SetFloat("_Fade", _fade);
            }
            if(_fade <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    /// <summary>
    /// Управление котом
    /// </summary>
    private void CatsMove()
    {
        if(Input.GetKey(KeyCode.A) && _plat == true)
        {
            if (rb.velocity.y >= 0)
            {
                rb.velocity = new Vector2(-_speed, rb.velocity.y);
                _trans.localScale = new Vector3(-1 * size, 1 * size, 1 * size);
                anima.SetBool("Run", true);
            }
            else
            {
                rb.velocity = new Vector2(-_speed / 1.3f, rb.velocity.y);
                _trans.localScale = new Vector3(-1 * size, 1 * size, 1 * size);
            }
        }
        else if(Input.GetKey(KeyCode.D) && _plat == true)
        {
            if (rb.velocity.y >= 0)
            {
                rb.velocity = new Vector2(_speed, rb.velocity.y);
                _trans.localScale = new Vector3(1 * size, 1 * size, 1 * size);
                anima.SetBool("Run", true);
            }
            else
            {
                rb.velocity = new Vector2(_speed / 1.3f, rb.velocity.y);
                _trans.localScale = new Vector3(1 * size, 1 * size, 1 * size);
            }
        }
        else if(Input.GetKey(KeyCode.A) != true && Input.GetKey(KeyCode.D) != true)
        {
            rb.velocity = new Vector2( 0 , rb.velocity.y);
            anima.SetBool("Run", false);
        }

        if(Input.GetKeyDown(KeyCode.W) && _jump == true && _plat == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, _jumpSpeed);
            _jump = false;
        }
    }

    /// <summary>
    /// Управление псом
    /// </summary>
    private void DogMove()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && _plat == true)
        {
            if (rb.velocity.y >= 0)
            {
                rb.velocity = new Vector2(-_speed, rb.velocity.y);
                _trans.localScale = new Vector3(-0.5f * size, 0.5f * size, 0.5f * size);
                anima.SetBool("Run", true);
            }
            else
            {
                rb.velocity = new Vector2(-_speed / 1.3f, rb.velocity.y);
                _trans.localScale = new Vector3(-0.5f * size, 0.5f * size, 0.5f * size);
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow) && _plat == true)
        {
            if (rb.velocity.y >= 0)
            {
                rb.velocity = new Vector2(_speed, rb.velocity.y);
                _trans.localScale = new Vector3(0.5f * size, 0.5f * size, 0.5f * size);
                anima.SetBool("Run", true);
            }
            else
            {
                rb.velocity = new Vector2(_speed / 1.3f, rb.velocity.y);
                _trans.localScale = new Vector3(0.5f * size, 0.5f * size, 0.5f * size);
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow) != true && Input.GetKey(KeyCode.LeftArrow) != true)
        {
            rb.velocity = new Vector2( 0 , rb.velocity.y);
            anima.SetBool("Run", false);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && _jump == true && _plat == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, _jumpSpeed);
            _jump = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Bones>())
        {
            Bones bones = collision.gameObject.GetComponent<Bones>();
            if(bones.cat == cats)
            {
                bones.BonesMinus();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<PlatformMove>())
        {
            _jump = true;
            if(collision.transform.position.y + (collision.transform.localScale.y - 0.1f) > _trans.position.y)
            {
                _plat = false;
            }
            else
            {
                _plat = true;
            }
            _trans.parent = collision.transform;
        }
        else
        {
            if(collision.transform.position.y > _trans.position.y)
            {
                _plat = true;
            }
            else
            {
                _plat = false;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<PlatformMove>())
        {
            _plat = true;
            _trans.parent = null;
        }
        else
        {
            _plat = true;
        }
    }
}
