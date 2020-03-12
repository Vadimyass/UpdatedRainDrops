using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Engine : MonoBehaviour
{
    [NonSerialized]public int Score = 0;

    public event Action<Engine> OnUpdate;
    public static Engine ScoreText { get; private set; }

    private float _speed = 1f;


    public void Awake()
    {
        ScoreText = this;
    }
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        transform.position += Vector3.down * Time.deltaTime * _speed; 

        gameObject.transform.Translate(moveHorizontal * 0.15f, moveVertical * 0.15f, 0.0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<ColliderScript>(out ColliderScript collider))
        {
            if(transform.localScale.x > 0.175f)
            {
                transform.localScale -= new Vector3(0.025f,0.025f);
            }
        }
        if (collision.TryGetComponent<Raindrops>(out Raindrops raindrops))
        {
            if (transform.localScale.x < 0.3f)
            {
                transform.localScale += new Vector3(0.01f, 0.01f);
                _speed += 0.1f;
                LevelUp.GainExp(10);
            }
        }
    }
    public void AddScore()
    {
        Score = Score + 1;
        OnUpdate(this);
    }
    private void OnDestroy()
    {
        ScoreText = null;
    }
}

