using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//INHERITENCE
public class EnemyJump : Enemy
{
    [SerializeField] bool onGround = true;
    private Rigidbody jumpRb;
    private float jumpForce = 6;
    // Start is called before the first frame update
    void Start()
    {
        jumpRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Jumping();
    }

    //POLYMORPHISM
    //ABSTRACTION
    public void Jumping()
    {
        if (onGround == true)
        {
            jumpRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            onGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
    }
}
