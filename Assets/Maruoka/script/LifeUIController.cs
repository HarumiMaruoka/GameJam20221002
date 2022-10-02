using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// LifeUIを制御するコンポーネント
/// </summary>
public class LifeUIController : MonoBehaviour
{
    [Header("ハートのスプライト : プレハブ"), SerializeField] GameObject _heartSpritePrefab;
    HitPoint _playerHitPoint;
    [Header("playerのタグ"), SerializeField] string _playerTagName;

    void Start()
    {
        _playerHitPoint = GameObject.FindGameObjectWithTag("Player").GetComponent<HitPoint>();
        //ハートを生成する。
        for (int i = 0; i < _playerHitPoint.MyHitPoint; i++)
        {
            Instantiate(_heartSpritePrefab, transform);
        }
    }

    void Update()
    {
        if (transform.childCount != _playerHitPoint.MyHitPoint)
        {
            if (transform.childCount < _playerHitPoint.MyHitPoint)
            {
                for (int i = 0; i < Mathf.Abs(transform.childCount - _playerHitPoint.MyHitPoint); i++)
                {
                    Instantiate(_heartSpritePrefab, transform);
                }
            }

            else if (transform.childCount > _playerHitPoint.MyHitPoint)
            {
                for (int i = 0; i < Mathf.Abs(transform.childCount - _playerHitPoint.MyHitPoint); i++)
                {
                    Destroy(transform.GetChild(i).gameObject);
                }
            }
        }
    }
}
