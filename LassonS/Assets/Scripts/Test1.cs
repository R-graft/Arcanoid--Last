using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Test1 : MonoBehaviour
{
    public Button scene;

    public Button action;

    public event Action aaa;

    private UnityAction UnityAction;

    private void Awake()
    {
        aaa += Scene;

        scene.onClick.AddListener(delegate { _= aaa; });
    }
    public void Act()
    {
        print(1);
    }

    public void Scene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}



