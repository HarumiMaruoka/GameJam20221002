using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 攻撃処理
/// </summary>
public class OnAttack : MonoBehaviour
{
    [Header("攻撃処理に関わる値")]
    [Tooltip("攻撃力 : 相手に与えるダメージ量"), SerializeField]
    float _damage = 1f;
    [Tooltip("攻撃のインターバル"), SerializeField]
    float _attackInterval = 1f;

    //===== フィールド =====//
    bool _isAttack = true;

    private void OnTriggerEnter(Collider other)
    {
        // 攻撃可能かつ 相手がヒットポイントを持っており かつ 同類でなければ
        // 相手のライフを減らす。
        if (_isAttack &&
            other.TryGetComponent(out HitPoint hitPoint) &&
            gameObject.tag != other.tag)
        {
            hitPoint.OnHitDamage(_damage);
        }
    }

    IEnumerator WaitAttackInterval()
    {
        _isAttack = false;
        yield return new WaitForSeconds(_attackInterval);
        _isAttack = true;
    }
}
