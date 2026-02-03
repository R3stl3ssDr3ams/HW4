using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pigeon : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _jump = 1f;
    [SerializeField] private AudioSource _Flapaudio;
    [SerializeField] private GameController _gameController;
    public delegate void EmptyDelegate();
    public event EmptyDelegate PointsChanged;
    public event EmptyDelegate GameOver;
    float _jumpRate = 0.0f;

    void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _jumpRate -= Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) && _jumpRate <= 0)
        {
            _rigidbody.AddForce(transform.up * _jump, ForceMode2D.Impulse);
            _jumpRate = 0.3f;
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            _Flapaudio.Play();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject _collided = collision.gameObject;
        if (_collided.CompareTag("Score"))
        {
            Debug.Log("You work!");
            Pint();
        }
        else if (_collided.CompareTag("Pipe"))
        {
            GameOver?.Invoke();
        }
    }
    private void Pint()
    {
        Debug.Log("You work!");
        PointsChanged?.Invoke();
    }
}
