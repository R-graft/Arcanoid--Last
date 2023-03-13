using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : Singleton<ScenesManager>, IService
{
    [SerializeField] private LoadPanel _loadPanel;

    private AsyncOperation _loadingScene;

    private SCENELIST currentScene;

    private float _minLoadingTime;

    public Action<SCENELIST> OnLoadScene;

    public Action OnSceneIsLoaded;

    public void Init()
    {
        SingleInit();

        _loadPanel.gameObject.SetActive(false);
    }
    public void LoadScene(SCENELIST targetScene)
    {
        currentScene = targetScene;

        StartCoroutine(SceneLoadCoroutine(targetScene));
    }

    private IEnumerator SceneLoadCoroutine(SCENELIST targetScene)
    {
        _minLoadingTime = 0.8f;

        _loadingScene = SceneManager.LoadSceneAsync(targetScene.ToString());

        _loadPanel.InAnimation();

        _loadingScene.allowSceneActivation = false;

        while (_minLoadingTime > 0)
        {
            yield return new WaitForFixedUpdate();

            _minLoadingTime -= Time.fixedDeltaTime;
        }
        
        _loadingScene.allowSceneActivation = true;

        while (!_loadingScene.isDone)
        {
            yield return null;
        }

        _loadPanel.OutAnimation();

        OnLoadScene?.Invoke(currentScene);
    }
}
public enum SCENELIST
{
    StartScene,
    PackScene,
    GameScene,
}
