using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownManager : MonoBehaviour
{
    private void Start()
    {
        DialogTextManager.instance.SetScenarios(new string[] { "äXÇ…íÖÇ¢ÇΩÅB" });

    }
    public void ClickToQuestButton()
    {
        SoundManager.instance.PlaySE(0);
    }
}
