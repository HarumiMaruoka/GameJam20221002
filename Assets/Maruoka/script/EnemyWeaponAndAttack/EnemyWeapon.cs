using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵の攻撃を制御するコンポーネント
/// </summary>
public class EnemyWeapon : MonoBehaviour
{
    //===== インスペクタ変数 =====//
    [Header("攻撃に関するパラメータ")]
    [Tooltip("弾のプレハブ"), SerializeField]
    GameObject _bullet = default;
    [Tooltip("攻撃のインターバル"), SerializeField]
    float _fireInterval = 1f;
    [Tooltip("戦闘開始距離"), SerializeField]
    float _fightDistance = 10f;

    //===== フィールド =====//
    Transform _playerTransform = default;
    bool _isFire = false;
    bool _isFight = false;


    void Start()
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        // 戦闘開始処理
        if (Vector3.Distance(_playerTransform.position, transform.position) < _fightDistance && !_isFight)
        {
            _isFight = true;
            _isFire = true;
            StartCoroutine(WaitFireInterval());
        }
        // 戦闘終了処理
        if (Vector3.Distance(_playerTransform.position, transform.position) > _fightDistance && _isFight)
        {
            _isFight = false;
            _isFire = false;
        }

        // 向きを制御
        this.transform.LookAt(_playerTransform);
        var rotation = transform.rotation;
        transform.rotation = rotation;

        // 攻撃処理
        if (_isFire)
        {
            Instantiate(_bullet, transform.position, transform.rotation);
            StartCoroutine(WaitFireInterval());
        }
    }



    IEnumerator WaitFireInterval()
    {
        _isFire = false;
        yield return new WaitForSeconds(_fireInterval);
        _isFire = true;
    }
}
