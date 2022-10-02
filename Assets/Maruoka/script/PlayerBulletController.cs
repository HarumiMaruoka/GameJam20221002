using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーが撃つ弾を制御するコンポーネント
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class PlayerBulletController : MonoBehaviour
{
    //===== インスペクタ変数 =====//
    [Header("弾の制御関連")]
    [Tooltip("弾の速度"),SerializeField]
    float _moveSpeed = 10f;
    [Tooltip("弾の生存時間"), SerializeField]
    float _lifeTime = 1f;

    //===== フィールド =====//
    Rigidbody _rigidbody;

    //===== Unityメッセージ =====//
    void Start()
    {
        // 正面に向かってまっすぐ飛ぶ
        GetComponent<Rigidbody>().velocity = transform.forward * _moveSpeed;
        // 生存時間を設定する。
        StartCoroutine(BulletLifeTimer());
    }
    void OnTriggerEnter(Collider other)
    {

    }

    //===== privateメソッド =====//
    private void Init()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    //===== コルーチン =====//
    IEnumerator BulletLifeTimer()
    {
        yield return new WaitForSeconds(_lifeTime);
        Destroy(gameObject);
    }
}
