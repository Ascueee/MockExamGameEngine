using UnityEngine;

public class ChickenPool : MonoBehaviour
{
    [SerializeField] private GameObject[] chickens;
    
    //returns a random chicken object from the object pool
    public GameObject GetChicken()
    {
        int randInt = Random.Range(0, chickens.Length);
        return chickens[randInt];
    }
}
