using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject _pipePrefab;
    [SerializeField] private GameObject _Button;
    [SerializeField] private AudioSource _Deadaudio;
    [SerializeField] private float _time = 0.0f;
    [SerializeField] private Transform _spawnTF;
    [SerializeField] private TMP_Text _pointText;
    private Vector2 spawn;
    public int _points = 0;
    // Start is called before the first frame update
    void Start()
    {
        spawn = _spawnTF.position;
        Events.Instance.Pidgeon.PointsChanged += HandlePointsChanged;
        Events.Instance.Pidgeon.GameOver += HandleGameOver;
    }

    // Update is called once per frame
    private void Update()
    {
        if (_time > 0.0f)
        {
            _time -= Time.deltaTime;
        }
        else
        {
            spawn = new Vector2(_spawnTF.position.x, _spawnTF.position.y + UnityEngine.Random.Range(-0.75f, 0.75f));
            Instantiate(_pipePrefab, spawn, Quaternion.identity);
            _time = 5.0f;
        }
    }
    public void HandlePointsChanged()
    {
        _points += 1;
        string points = _points.ToString();
        _pointText.text = $"{points}";
    }
    public void HandleGameOver()
    {
        _points = 0;
        string points = _points.ToString();
        _pointText.text = $"{points}";
        _Deadaudio.Play();
        _Button.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
