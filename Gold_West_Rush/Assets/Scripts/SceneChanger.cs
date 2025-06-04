using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string sceneName = "SceneName";

    void Start()
    {
    }

    public void OnClick()
    {
        SceneManager.LoadScene(sceneName);
    }
}