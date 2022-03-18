using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMenu : MonoBehaviour
{
    //Text field
    public Text levelText, hitpointText, coinsText, upgradeCostText, xpText;

    //Logic
    private int currentCharacterSelection = 0;
    public Image characterSelectionSprite;
    public Image weaponSprite;
    public RectTransform xpBar; 

    //Character Selection
    public void OnArrowClick(bool right)
    {
        if (right)
        {
            currentCharacterSelection++;
            if (currentCharacterSelection == GameManager.Instance.playerSprites.Count)
            {
                currentCharacterSelection = 0;
            }
            OnselectionChange();
        }
        else
        {
            currentCharacterSelection--;
            if (currentCharacterSelection < 0)
            {
                currentCharacterSelection = GameManager.Instance.playerSprites.Count-1;
            }
            OnselectionChange();
        }
    }
    private void OnselectionChange()
    {
        characterSelectionSprite.sprite = GameManager.Instance.playerSprites[currentCharacterSelection];
        GameManager.Instance.player.SwapSprite(currentCharacterSelection);
    }
    //Weapon Upgrade
    public void OnUpgradeClick()
    {
        if (GameManager.Instance.Upgradeweapon())
        {
            UpdateMenu();
        }
    }
    public void UpdateMenu()
    {
        weaponSprite.sprite = GameManager.Instance.weaponSprites[GameManager.Instance.weap.weaponLevel ];
        if (GameManager.Instance.weap.weaponLevel == GameManager.Instance.weaponPrices.Count)
        {
            upgradeCostText.text = "Max";

        }
        else
        {
            upgradeCostText.text = GameManager.Instance.weaponPrices[GameManager.Instance.weap.weaponLevel].ToString();
        }
        levelText.text = GameManager.Instance.GetCurrentLevel().ToString();
        hitpointText.text = GameManager.Instance.player.hitpoint.ToString()+"/" +GameManager.Instance.player.maxHitpoint;
        coinsText.text = GameManager.Instance.coins.ToString();
        int currentlevel = GameManager.Instance.GetCurrentLevel();
        if (currentlevel == GameManager.Instance.xpTable.Count)
        {
            xpText.text = GameManager.Instance.experience.ToString()+" Total experience points";
            xpBar.localScale = Vector3.one;
        }
        else
        {
            int prelevelxp = GameManager.Instance.GetXptolevel(currentlevel-1);
            int currentlevelxp= GameManager.Instance.GetXptolevel(currentlevel);
            int diff = currentlevelxp - prelevelxp;
            int currXpIntoLevel = GameManager.Instance.experience - prelevelxp;
            float completionRatio = (float)currXpIntoLevel / (float)diff;
            xpBar.localScale = new Vector3(completionRatio, 1, 1);
            xpText.text = currXpIntoLevel.ToString() + "/" + diff;
        }
    }
}
