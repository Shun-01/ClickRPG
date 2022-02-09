using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    public void LoadTo(string sceneName)
    {
        FadeIOManager.instance.FadeOutToIn(() => Load(sceneName)); //action()�̕�����Load(sceneName)�ɂȂ��Ă���
        
    }
    void Load(string sceneName)
    {
        SoundManager.instance.PlayBGM(sceneName); //�J�ڐ�̃V�[����BGM��炵�����̂ŁA�V���O���g�����g��
        SceneManager.LoadScene(sceneName);
    }
}
