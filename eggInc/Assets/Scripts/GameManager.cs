using UnityEngine;
using TMPro;

/// <summary>
/// A Observer that updates its values based on objects in the scene
/// </summary>
public class GameManager : MonoBehaviour
{
    [Header("Chicken Spawning")]
    [SerializeField] private ChickenPool chickenSpawner;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform spawnPoint2;

    private bool tapInput = false;
    private bool dmgInput = false;
    private bool spawnChicken = false;
    private bool spawnCoolDown = false;

    [Header("UI Elements")] 
    [SerializeField] private TextMeshProUGUI chickenCountText;
    [SerializeField] private TextMeshProUGUI gameMoney;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerActions();
        SpawnChicken();
        SpawnCoolDown();
    }
    void PlayerActions()
    {
        if (tapInput == true && spawnCoolDown == false )
        {
            spawnChicken = true;
        }
        else
        {
            spawnChicken = false;
        }
    }

    void SpawnChicken()
    {
        if (spawnChicken == true)
        {
            var chickenSpawn = chickenSpawner.GetChicken();

            if (chickenSpawn.tag == "Evil")
            {
                var chicken = Instantiate(chickenSpawn, spawnPoint2.position, Quaternion.identity);
            }
            else
            {
                //use object pooling to pick out a chicken object
                var chicken = Instantiate(chickenSpawn, spawnPoint.position, Quaternion.identity);
            }
            spawnCoolDown = true;
        }
    }

    void SpawnCoolDown()
    {
        if (spawnCoolDown == true)
        {
            Invoke("ResetCD", 1f);
        }
    }

    void ResetCD()
    {
        spawnCoolDown = false;
    }

    public void ChickenUI(int numOfChickens)
    {
        chickenCountText.text = "Chickens: " + numOfChickens;
    }

    public void MoneyUI(float playerMoney)
    {
        gameMoney.text = "Money" + playerMoney;
    }

    public void SetPlayerInput(bool input)
    {
        tapInput = input;
    }
}
