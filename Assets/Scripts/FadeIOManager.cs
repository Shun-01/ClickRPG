using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FadeIOManager : MonoBehaviour
{
    //�V���O���g����
    public static FadeIOManager instance;
    public CanvasGroup canvasGroup;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void FadeOut()
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.DOFade(1, 1f).OnComplete(() => canvasGroup.blocksRaycasts = false);
    }
    public void FadeIn()
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.DOFade(0, 1f).OnComplete(() => canvasGroup.blocksRaycasts = false); ;
    }
    public void FadeOutToIn(TweenCallback action)
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.DOFade(1, 1f).OnComplete(() => {action(); FadeIn();}) ;  //�t�F�[�h�A�E�g���Ă��� action() �� �t�F�[�h�C�����s��
    }
}
