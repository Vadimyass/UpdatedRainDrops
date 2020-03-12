using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUp : MonoBehaviour
{
    [SerializeField] private Image LevelProgressBar = null;
    [SerializeField] private GameObject AchievementImage = null;
    [SerializeField] private TextMeshProUGUI LevelText = null;
    [SerializeField] private TextMeshProUGUI PointsToNextLevelUI = null;
    [SerializeField] private TextMeshProUGUI AchievementLvl = null;
    
    
    private static float GlobalExp;
    private static float Exp { get; set; }
    private static int Level = 1;
    private void Update()
    {
        LevelUping();
        if (LevelProgressBar.fillAmount > 0.999f)
        {
            StartCoroutine(LevelUI());
        }
        PointsToNextLevelUI.text = $"{Convert.ToInt32(Mathf.Abs(Exp*Level*100 - Level*100))} : to next level";
    }
    public static void GainExp(float exp)
    {
        Exp += (exp / (Level)) / 100;
        GlobalExp += exp;
    }

    public void LevelUping()
    {
        LevelProgressBar.fillAmount = Exp;
    }
    IEnumerator LevelUI()
    {
        LevelProgressBar.fillAmount = 0;
        Exp = 0;
        Level += 1;
        print(Level);
        LevelText.text = $"Level{Level}";
        print(GlobalExp);
        AchievementImage.SetActive(true);
        AchievementLvl.text = $"Congratz!!!! You reached {Level} level!!";
        yield return null;
    }
    public void CloseWindow()
    {
        AchievementImage.SetActive(false);
    }
    public void dada()
    {
        GainExp(10);
        print(Exp);
    }
}
