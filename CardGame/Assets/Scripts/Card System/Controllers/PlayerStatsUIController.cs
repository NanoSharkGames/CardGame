using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsUIController : MonoBehaviour
{
    [SerializeField] Player player;

    [SerializeField] Text hpText;
    [SerializeField] Text actionPointText;
    [SerializeField] Text damageBonusText;

    public void FillUIStats()
    {
        int playerMaxHP = player.GetMaxHP();
        int playerHP = player.GetHP();

        int playerMaxAP = player.GetMaxAP();
        int playerAP = player.GetAP();

        int damageBonus = player.GetDamageBonus();

        hpText.text = "HP: " + playerHP.ToString() + "/" + playerMaxHP.ToString();

        actionPointText.text = "AP: " + playerAP.ToString() + "/" + playerMaxAP.ToString();

        damageBonusText.text = "Damage Bonus: " + damageBonus.ToString();
    }
}
