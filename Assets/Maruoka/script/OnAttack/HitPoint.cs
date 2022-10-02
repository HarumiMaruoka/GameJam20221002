using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ヒットポイント
/// </summary>
public class HitPoint : MonoBehaviour
{
    //===== インスペクタ変数 =====//
    [Header("体力に関わる値")]
    [Tooltip("体力"), SerializeField]
    float _hitPoint = 5f;
    [Tooltip("倒された時にプレハブを生成する"), SerializeField]
    GameObject _destroyEffect = default;

    //===== プロパティ =====//
    public float MyHitPoint { get => _hitPoint; }

    //===== publicメソッド =====//
    public void OnHitDamage(float damage)
    {
        _hitPoint -= damage;
        if (_hitPoint < 0f)
        {
#if UNITY_EDITOR
            Debug.Log($"{gameObject.name}が倒されました。消滅します。");
#endif
            // やられEffectを発生させる
            if (_destroyEffect != null)
            {
                Instantiate(_destroyEffect, transform.position, transform.rotation);
            }
            Destroy(gameObject);
        }
    }
}
