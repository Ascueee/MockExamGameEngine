using UnityEngine;

/// <summary>
/// An Observer that waits for player input to then update the GameManager Singleton
/// </summary>
public class GameInput : MonoBehaviour
{
    private bool isPressed = false;
    private bool damagePressed = false;
    [SerializeField] GameManager gm;
    
    /// <summary>
    /// Uses a singleton to detect player input and send it to a manager to spawn a chicken
    /// </summary>
    /// <returns></returns>
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
    }


    void PlayerInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isPressed = true;
        }
        else
        {
            isPressed = false;
        }
        
        
        gm.SetPlayerInput(isPressed);
    }
}
