using UnityEngine;

/// <summary>
/// When spawned move the chicken towards the barn
/// </summary>
public class Chicken : MonoBehaviour
{
    public Rigidbody rb;
    public Transform barn;
    public Vector3 moveDir;
    [SerializeField] private Player player;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveDir = barn.position - transform.position;
        moveDir = moveDir.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        
    }

    public virtual void Move()
    {
        rb.AddForce(moveDir * 1f, ForceMode.Force);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Respawn")
        {
            player.IncrementAmountOfChickens();
            print("Made Money");
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Evil" && gameObject.tag != "Evil")
        {
            Destroy(gameObject);
        }
    }
}
