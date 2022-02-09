using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //�V���O���g��
    //�Q�[������1�������݂��Ȃ����́i�����Ǘ�������̂Ƃ��j
    //���p�ꏊ�F�V�[���Ԃł̃I�u�W�F�N�g���L
    //������
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
    }�@//�����܂ł��V���O���g��

    public AudioSource audioSourceBGM; //BGM�̃X�s�[�J�[
    public AudioClip[] audioClipsBGM; //BGM�̑f�ށ@(0:Title 1:Town 2:Quest 3:Battle)
    public AudioSource audioSourceSE;//SE�̃X�s�[�J�[
    public AudioClip[] audioClips; //SE�̑f��
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
