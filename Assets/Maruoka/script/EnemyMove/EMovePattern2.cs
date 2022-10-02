using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵の移動を制御するコンポーネント <br/>
/// パターンその2 <br/>
/// プレイヤーに向かって一定速度で向かってくる <br/>
/// </summary>
public class EMovePattern2 : EMoveBase
{
    //===== インスペクタ変数 =====//
    [Header("移動関連")]
    [Tooltip("移動速度"), SerializeField]
    float _moveSpeed = 1f;

    //===== フィールド =====//
    const string _playerTagName = "Player";
    Transform _playerTransform = default;

    protected override void Init()
    {
        base.Init();
        _playerTransform = GameObject.FindGameObjectWithTag(_playerTagName).transform;
        if (_playerTransform == null)
        {
            Debug.LogError("プレイヤーのタグを\"_playerTagName\"に設定しなおしてください！");
        }
    }
    protected override void Move()
    {
        // 移動を制御
        Vector3 targetVector = (_playerTransform.position - transform.position).normalized;
        _rigidbody.velocity =
            (Vector3.right * targetVector.x + Vector3.forward * targetVector.z) * _moveSpeed +
            Vector3.up * _rigidbody.velocity.y;

        Debug.Log(_rigidbody.velocity);

        // 向きを制御
        this.transform.LookAt(_playerTransform);
        var rotation = transform.rotation;
        rotation.z = 0f;
        rotation.x = 0f;
        transform.rotation = rotation;


    }
}
