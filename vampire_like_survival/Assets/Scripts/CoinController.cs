using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinController : MonoBehaviour
{

    public static CoinController instance;
    public int current_coin;
    public CoinPickup coin;


    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }

 
    public void Add_Coin(int coins_to_add )
    {
        current_coin += coins_to_add;

        UIController.Instance.Update_Coins();
        SfxManager.instance.PlaySFXPitched(2);
    }


    public void Drop_Coin(Vector3 position, int value)
    {
        
        CoinPickup new_coin = Instantiate(coin, position + new Vector3(.2f, .1f, 0f), Quaternion.identity);     
        new_coin.coin_amount = value;
        new_coin.gameObject.SetActive(true);    

    }

    public void SpendCoin(int coins_to_spend)
    {
        current_coin -= coins_to_spend;
        UIController.Instance.Update_Coins();
    }

}
