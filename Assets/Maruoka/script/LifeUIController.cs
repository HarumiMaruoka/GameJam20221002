using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// LifeUI�𐧌䂷��R���|�[�l���g
/// </summary>
public class LifeUIController : MonoBehaviour
{
    [Header("�n�[�g�̃X�v���C�g : �v���n�u"), SerializeField] GameObject _heartSpritePrefab;
    HitPoint _playerHitPoint;
    [Header("player�̃^�O"), SerializeField] string _playerTagName;

    void Start()
    {
        _playerHitPoint = GameObject.FindGameObjectWithTag("Player").GetComponent<HitPoint>();
        //�n�[�g�𐶐�����B
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
