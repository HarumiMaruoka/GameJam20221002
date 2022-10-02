using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵が放つ弾を制御するコンポーネント
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class EnemyBullet : MonoBehaviour
{
    [Header("移動速度"), SerializeField]
    float _moveSpeed = 5f;
    [Header("破壊までの時間"), SerializeField]
    float _destroyTime = 1f;

    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * _moveSpeed;
        StartCoroutine(WaitDestroy());
    }

    IEnumerator WaitDestroy()
    {
        yield return new WaitForSeconds(_destroyTime);
        Destroy(gameObject);
    }
}
