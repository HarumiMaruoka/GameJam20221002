using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImEnemy : MonoBehaviour
{
    GameManager _gameManager;
    private void Start()
    {
        _gameManager = GameObject.FindObjectOfType<GameManager>();
    }
    private void OnDestroy()
    {
        _gameManager._howManyEnemy--;
    }

}
