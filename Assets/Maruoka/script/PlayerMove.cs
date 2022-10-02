using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour
{
    //===== インスペクタ変数 =====//
    [Header("移動関連")]
    [Tooltip("移動速度"), SerializeField]
    float _moveSpeed = 1f;
    [Tooltip("ジャンプ力"), SerializeField]
    float _jumpPower = 5f;
    [Tooltip("回転速度"), SerializeField]
    float _rotationSpeed = 600f;

    [Header("接地判定")]
    [Tooltip("接地判定エリアをデバッグ表示するかどうか"), SerializeField]
    bool _isDrawGizmo = true;
    [Tooltip("デバッグ表示エリアの色"), SerializeField]
    Color _gizmoColor = default;
    [Tooltip("接地判定エリアのオフセット"), SerializeField]
    Vector3 _groundCheckPosOffset = default;
    [Tooltip("接地判定エリアサイズ"), SerializeField]
    Vector3 _groundCheckAreaSize = default;
    [Tooltip(""), SerializeField]
    LayerMask _groundCheckLayerMask = default;


    //===== フィールド =====//
    /// <summary> リジッドボディ </summary>
    Rigidbody _rigidbody = default;
    Quaternion _targetRotation = default;

    //===== Unityメッセージ =====//
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        Move();
    }
    void OnDrawGizmos()
    {
        if (_isDrawGizmo)
        {
            Gizmos.color = _gizmoColor;
            Gizmos.DrawCube(transform.position + _groundCheckPosOffset, _groundCheckAreaSize);
        }
    }

    //===== privateメソッド =====//
    /// <summary>
    /// 移動処理
    /// </summary>
    void Move()
    {
        float speed = 0f;
        Vector3 newVelocity =
            new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

        //　メインカメラを基準に方向を決める。
        newVelocity = Camera.main.transform.TransformDirection(newVelocity);
        // 移動方向を向く
        if (newVelocity.magnitude > 0.5f)
        {
            _targetRotation = Quaternion.LookRotation(newVelocity, Vector3.up);
            speed = Input.GetKey(KeyCode.LeftShift) ? 2 : 1;
        }
        transform.rotation = Quaternion.RotateTowards(transform.rotation, _targetRotation, _rotationSpeed * Time.deltaTime);

        var rotation = transform.rotation;
        rotation.x = 0f;
        rotation.z = 0f;
        transform.rotation = rotation;


        //速度を与える
        newVelocity.y = 0;
        _rigidbody.velocity =
            newVelocity * _moveSpeed * speed +
            Vector3.up * _rigidbody.velocity.y;

        // ジャンプ処理
        if (GetIsGround() && Input.GetButtonDown("Jump"))
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.velocity = Vector3.up * _jumpPower;
        }
    }

    //===== publicメンバー関数 =====//
    /// <summary> 接地判定 </summary>
    /// <returns> 接地していればtrueを返す。そうでなければfalseを返す。 </returns>
    public bool GetIsGround()
    {
        Vector3 overLapBoxCenter = transform.position + _groundCheckPosOffset;
        Collider[] collision = Physics.OverlapBox(
            overLapBoxCenter,
            _groundCheckAreaSize,
            Quaternion.identity,
            _groundCheckLayerMask);
        if (collision.Length != 0)
        {
            return true;
        }
        return false;
    }
}
