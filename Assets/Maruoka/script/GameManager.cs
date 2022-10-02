using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    HitPoint _playerLife;
    [Header("ìGÇÃêî"), SerializeField]
    int _howManyEnemy = 0;

    void Start()
    {
        _playerLife = GameObject.FindGameObjectWithTag("Player").GetComponent<HitPoint>();
    }

    void Update()
    {
        if (_playerLife.MyHitPoint < 1)
        {
            SceneLoader.LoadScene("GameOver");
        }
        if (_howManyEnemy < 1)
        {
            SceneLoader.LoadScene("GameClear");
        }
    }
}
