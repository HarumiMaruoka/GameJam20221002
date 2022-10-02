using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵の移動の基底クラス
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public abstract class EMoveBase : MonoBehaviour
{
    protected Rigidbody _rigidbody = default;
    void Start()
    {
        Init();
    }
    void Update()
    {
        Move();
    }
    protected virtual void Init()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    /// <summary>
    /// 移動処理 : <br/>
    /// 継承先で独自の移動を記述してください。
    /// </summary>
    protected virtual void Move()
    {

    }
}
