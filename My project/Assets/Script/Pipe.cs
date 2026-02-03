using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] private AudioSource _Coinaudio;
    [SerializeField] private GameObject _pipe;
    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private Transform _pipeTF;

    void Start()
    {
        Events.Instance.Pidgeon.PointsChanged += HandlePointsChanged;
        Events.Instance.Pidgeon.GameOver += HandleGameOver;
    }
    // Update is called once per frame
    private void Update()
    {
        if (_pipe != null)
        {
            _pipeTF.Translate(Vector2.left * _speed * Time.deltaTime, Space.Self);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject _collided = collision.gameObject;
        if (_collided.CompareTag("Collider"))
        {
            Destroy(_pipe);
        }
    }
    public void HandlePointsChanged()
    {
        _Coinaudio.Play();
    }
    public void HandleGameOver()
    {
        Destroy(_pipe);
    }
}
