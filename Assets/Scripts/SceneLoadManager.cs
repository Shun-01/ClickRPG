using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    public void LoadTo(string sceneName)
    {
        FadeIOManager.instance.FadeOutToIn(() => Load(sceneName)); //action()の部分がLoad(sceneName)になっている
        
    }
    void Load(string sceneName)
    {
        SoundManager.instance.PlayBGM(sceneName); //遷移先のシーンのBGMを鳴らしたいので、シングルトンを使う
        SceneManager.LoadScene(sceneName);
    }
}
