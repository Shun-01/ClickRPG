using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //シングルトン
    //ゲーム内に1つしか存在しないもの（音を管理するものとか）
    //利用場所：シーン間でのオブジェクト共有
    //書き方
    public static SoundManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }　//ここまでがシングルトン

    public AudioSource audioSourceBGM; //BGMのスピーカー
    public AudioClip[] audioClipsBGM; //BGMの素材　(0:Title 1:Town 2:Quest 3:Battle)
    public AudioSource audioSourceSE;//SEのスピーカー
    public AudioClip[] audioClips; //SEの素材
    public void PlayBGM(string sceneName)
    {
        audioSourceBGM.Stop();
        switch (sceneName)
        {
            default:
            case "TitleScene":
                audioSourceBGM.clip = audioClipsBGM[0];
                break;

            case "TownScene":
                audioSourceBGM.clip = audioClipsBGM[1];
                break;

            case "QuestScene":
                audioSourceBGM.clip = audioClipsBGM[2];
                break;

            case "Battle":
                audioSourceBGM.clip = audioClipsBGM[3];
                break;

            case "Gameover":
                audioSourceBGM.clip = audioClipsBGM[4];
                break;
        }
        audioSourceBGM.Play();
    }
    public void PlaySE(int index)
    {
        audioSourceSE.PlayOneShot(audioClips[index]);
    }
}
