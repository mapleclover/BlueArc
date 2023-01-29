using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoad : Singleton<SceneLoad>
{
    private bool isChange = false;
    
    public void ChangeScene(int i)
    {
        if (!isChange)
        {
            StartCoroutine(Loading(i));
        }
    }

    public void ChangeScene(string i)
    {
        if (!isChange)
        {
            StartCoroutine(Loading(i));
        }
    }
    
    IEnumerator Loading(int i)
    {
        isChange = true;
        yield return SceneManager.LoadSceneAsync("00.Loading");
        GameObject obj = GameObject.Find("LoadingGauge");
        Slider slider = obj.GetComponent<Slider>();
        slider.value = 0.0f;
        StartCoroutine(LoadingTarget(slider, i));
        isChange = false;
    }

    public IEnumerator Loading(string mapName)
    {
        isChange = true;
        yield return SceneManager.LoadSceneAsync("00.Loading");
        GameObject obj = GameObject.Find("LoadingGauge");
        Slider slider = obj.GetComponent<Slider>();
        slider.value = 0.0f;
        StartCoroutine(LoadingTarget(slider, mapName));
        isChange = false;
    }

    IEnumerator LoadingTarget(Slider slider, int i)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(i);
        ao.allowSceneActivation = false;
        while (!ao.isDone)
        {
            slider.value = ao.progress / 0.9f;
            if (Mathf.Approximately(slider.value, 1.0f))
            {
                yield return new WaitForSeconds(1.0f);
                // 씬로딩 끝
                ao.allowSceneActivation = true;
            }

            yield return null;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    IEnumerator LoadingTarget(Slider slider, string mapName)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(mapName);
        ao.allowSceneActivation = false;
        while (!ao.isDone)
        {
            slider.value = ao.progress / 0.9f;
            if (Mathf.Approximately(slider.value, 1.0f))
            {
                yield return new WaitForSeconds(1.0f);
                // 씬로딩 끝
                ao.allowSceneActivation = true;
            }

            yield return null;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
