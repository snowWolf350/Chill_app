using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    private int currentExp;
    private int MaxExp;
    private int level;

    [SerializeField] StatsUI StatsUI;
    [SerializeField] List<LevelSO> LevelSoList;

    const string CURRENTLEVEL = "currentLevel";
    const string CURRENTEXP = "currentExp";

    private void Start()
    {
        currentExp = PlayerPrefs.GetInt(CURRENTEXP);
        if (level == 0)
            LevelUp();
        level = PlayerPrefs.GetInt(CURRENTLEVEL);
        TaskTemplate.OnTaskCompleted += TaskTemplate_OnTaskCompleted;
        MaxExp = 100;
        StatsUI.updateExpUI(currentExp, MaxExp, level);
        foreach (LevelSO levelSO in LevelSoList)
        {
            if (level == levelSO.level)
            {
                MaxExp = levelSO.maxExp;
            }
        }
    }

    private void TaskTemplate_OnTaskCompleted(object sender, System.EventArgs e)
    {
        IncreaseExp();
        StatsUI.updateExpUI(currentExp, MaxExp, level);
    }

    public void IncreaseExp()
    {
        if (currentExp < MaxExp - 10)
        {
            currentExp += 10;
        }
        else 
        {
            LevelUp();
        }
        PlayerPrefs.SetInt(CURRENTLEVEL, level);
        PlayerPrefs.SetInt(CURRENTEXP,currentExp);
    }
    public void LevelUp()
    {
        level++;
        currentExp = 0;
        foreach (LevelSO levelSO in LevelSoList)
        {
            if (level == levelSO.level)
            {
                MaxExp = levelSO.maxExp;
            }
        }
        StatsUI.updateExpUI(currentExp, MaxExp, level);
        PlayerPrefs.SetInt(CURRENTLEVEL, level);
        PlayerPrefs.SetInt(CURRENTEXP, currentExp);
    }
    [ContextMenu("increase xp")]
    public void increaseXPMax()
    {
        currentExp = MaxExp - 20;
        StatsUI.updateExpUI(currentExp, MaxExp, level);
    }
}
