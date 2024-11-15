using UnityEngine;

public class Player : MonoBehaviour
{
    private float playerMoney;
    private int playerChickens;
    [SerializeField] private GameManager gm;
    
    // Update is called once per frame
    void Update()
    {
        UpdateGameManager();
    }

    void UpdateGameManager()
    {
        UpdatePlayerMoney();
        
        gm.ChickenUI(playerChickens);
        gm.MoneyUI(playerMoney);
    }
    
    public void IncrementAmountOfChickens()
    {
        playerChickens++;
    }
    
    void UpdatePlayerMoney()
    {
        playerMoney += playerChickens / 1;
    }
}
