using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            SceneManager.sceneLoaded += loadState;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);

        }
    }

    //Resources
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    //References
    public Player player;
    public FloatingTextManager floatingTextManager;
    public weapon weap;
    //public Weapon weapon

    //Logic
    public int coins=500;   
    public int experience;

    public void showText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    { 
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }
    public bool Upgradeweapon()
    {
        if (weaponPrices.Count <= weap.weaponLevel)
        {
            return false;
        }
        if(coins >= weaponPrices[weap.weaponLevel])
        {
            coins -= weaponPrices[weap.weaponLevel];
            weap.UpgradeWeapon();
            return true;    
        }
        return false;
    }
    private void Update()
    {
        GetCurrentLevel();
    }
    public int GetCurrentLevel()
    {
        int level = 0;
        int currentxp = 0;
        while (experience >= currentxp)
        {
            currentxp += xpTable[level];
            level++;
            if (level == xpTable.Count) return level;
        }
        return level;
    }
    public int GetXptolevel(int level)
    {
        int r = 0;
        int xp = 0;
        while (r < level)
        {
            xp += xpTable[r];
            r++;
        }
        return xp;
    }
    public void GrantXp(int xp)
    {
        int currLevel = GetCurrentLevel();
        experience += xp;
        if (currLevel < GetCurrentLevel())
        {
            OnlevelUp();
        }
    }
    public void OnlevelUp()
    {
        player.OnlevelUp();
    }
    public void saveState()
    {
        string s = " ";
        s += "0" + "|";
        s += coins.ToString() + "|";
        s += experience.ToString() + "|";
        s += weap.weaponLevel.ToString();
        PlayerPrefs.SetString("SaveState", s);
        Debug.Log("Save State");
    }
     
    public void loadState(Scene s, LoadSceneMode load)
    {
        if (!PlayerPrefs.HasKey("SaveState")) return;
        string[] data = PlayerPrefs.GetString("SaveState").Split('|');

        coins = int.Parse(data[1]);
        experience = int.Parse(data[2]);
        weap.SetWeaponLevel(int.Parse(data[3]));
        Debug.Log("Load State");
    }
}
