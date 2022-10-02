using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadImage : MonoBehaviour
{
    [SerializeField]
    Image _image;

    [SerializeField]
    Sprite[] _moonImage;

    [SerializeField]
    float _span;

    float _currentTime = 0f;

    int _iD;

    void Update()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime > _span)
        {
            //Debug.LogFormat("{0}ïbåoâﬂ", _span);

            _image.sprite = _moonImage[_iD];
            _iD++;
            _currentTime = 0f;
        }

        if (_iD == _moonImage.Length) { _iD = 0; }
    }
}
