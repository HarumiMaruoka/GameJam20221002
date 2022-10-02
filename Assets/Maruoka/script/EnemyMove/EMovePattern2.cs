using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �G�̈ړ��𐧌䂷��R���|�[�l���g <br/>
/// �p�^�[������2 <br/>
/// �v���C���[�Ɍ������Ĉ�葬�x�Ō������Ă��� <br/>
/// </summary>
public class EMovePattern2 : EMoveBase
{
    //===== �C���X�y�N�^�ϐ� =====//
    [Header("�ړ��֘A")]
    [Tooltip("�ړ����x"), SerializeField]
    float _moveSpeed = 1f;

    //===== �t�B�[���h =====//
    const string _playerTagName = "Player";
    Transform _playerTransform = default;

    protected override void Init()
    {
        base.Init();
        _playerTransform = GameObject.FindGameObjectWithTag(_playerTagName).transform;
    }
    protected override void Move()
    {
        Vector3 targetVector = (_playerTransform.position - transform.position).normalized;
        _rigidbody.velocity = targetVector * _moveSpeed;
    }
}
