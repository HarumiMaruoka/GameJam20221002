using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    HitPoint _playerLife;
    [Header("敵の数"), SerializeField]
    public int _howManyEnemy = 0;
    [Header("ゲームオーバーのシーン名"), SerializeField]
    string _gameOverSceneName = "GameOver";
    [Header("ゲームクリアーのシーン名"), SerializeField]
    string _gameClearSceneName = "GameClear";

    void Start()
    {
        _playerLife = GameObject.FindGameObjectWithTag("Player").GetComponent<HitPoint>();
    }

    void Update()
    {
        if (_playerLife.MyHitPoint < 1)
        {
            SceneLoader.LoadScene(_gameOverSceneName);
        }
        if (_howManyEnemy < 1)
        {
            SceneLoader.LoadScene(_gameClearSceneName);
        }
    }
}
