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
        currentExp = PlayerPrefs.GetInt(CURRENTEXP,0);
        level = PlayerPrefs.GetInt(CURRENTLEVEL,1);
        TaskTemplate.OnTaskCompleted += TaskTemplate_OnTaskCompleted;

        foreach (LevelSO levelSO in LevelSoList)
        {
            if (level == levelSO.level)
            {
                MaxExp = levelSO.maxExp;
                break;
            }
        }
        StatsUI.updateExpUI(currentExp, MaxExp, level);
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
        PlayerPrefs.Save();
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
        PlayerPrefs.Save();
    }
    [ContextMenu("increase xp")]
    public void increaseXPMax()
    {
        currentExp = MaxExp - 20;
        StatsUI.updateExpUI(currentExp, MaxExp, level);
    }
}
