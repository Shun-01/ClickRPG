using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//StageのUIを管理（ステージ数の表示・進むボタン・街に戻るボタン）
public class StageUIManager : MonoBehaviour
{
    public Text stageText;
    public GameObject clearImage;
    public GameObject nextButton;
    public GameObject gotownButton;


    private void Start()
    {
        clearImage.SetActive(false);
    }
    public void UpdateUI(int currentStage)
    {
        stageText.text = "ステージ：" + currentStage.ToString();
    }

    public void ShowButtons(bool x)
    {
        nextButton.SetActive(x);
        gotownButton.SetActive(x);

    }
    public void ShowClearText()
    {
        clearImage.SetActive(true);
        nextButton.SetActive(false);
        gotownButton.SetActive(true);
    }
}
