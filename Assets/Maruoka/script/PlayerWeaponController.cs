using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 弾の発射を制御するコンポーネント
/// </summary>
public class PlayerWeaponController : MonoBehaviour
{
    //===== インスペクタ変数 =====//
    [Header("攻撃関連")]
    [Tooltip("左クリックで放つ弾のプレハブ"), SerializeField]
    GameObject _bullet = default;
    [Tooltip("左クリックによる攻撃のインターバル"), SerializeField]
    float _fire1Interval = 0.5f;


    //===== フィールド =====//
    bool _isFire1 = true;


    //===== Unityメッセージ =====//
    void Update()
    {
        OnFire1();
    }
    //===== privateメソッド =====//
    /// <summary>
    /// 左クリックで弾を放つ
    /// </summary>
    void OnFire1()
    {
        if (Input.GetButtonDown("Fire1") && _isFire1)
        {
            Instantiate(_bullet, transform.position, transform.rotation);
        }
    }

    IEnumerator OnFire1Interval()
    {
        _isFire1 = false;
        yield return new WaitForSeconds(_fire1Interval);
        _isFire1 = true;
    }
}
