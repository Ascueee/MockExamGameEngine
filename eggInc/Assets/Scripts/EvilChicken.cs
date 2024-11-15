using UnityEngine;

public class EvilChicken : Chicken
{
    private int health = 1;
    private Transform target;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Destroy(gameObject, 3f);

        if (health == 0)
            Destroy(gameObject);
    }


    public void Dmg()
    {

        if (Input.GetKeyDown(KeyCode.M))
        {
            health = health - 1;
        }

    }

    public override void Move()
    {
        if(GameObject.FindGameObjectWithTag("Chicken") is not null)
            target = GameObject.FindGameObjectWithTag("Chicken").transform;
        if (target is not null)
        {
            moveDir = target.position - transform.position;
            moveDir = moveDir.normalized;

            if (target is not null)
            {
                rb.AddForce(moveDir * 1f, ForceMode.Force);
            }
            else
            {
                print("No Target");
            }
        }

    }
}
