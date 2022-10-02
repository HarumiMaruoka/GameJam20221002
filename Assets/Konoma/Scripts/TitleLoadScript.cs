using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleLoadScript : MonoBehaviour
{
    [SerializeField] string _sceneName;
    public void OnLoad()
    {
        SceneManager.LoadScene(_sceneName);
    }
}
