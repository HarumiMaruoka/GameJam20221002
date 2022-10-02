using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImEnemy : MonoBehaviour
{
    private void OnDestroy()
    {
        GameObject.FindObjectOfType<GameManager>()._howManyEnemy--;
    }
}
