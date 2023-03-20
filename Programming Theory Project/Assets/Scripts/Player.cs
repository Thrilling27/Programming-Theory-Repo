using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody playerRb;
    private float m_speed = 400;
    private GameObject focalPoint;
    private float boostPower = 5;
    private float jumpPower = 8;
    private bool onGround = true;

    //ENCAPSULATION
    public float speed
    {
        get { return m_speed; }
        set
        {
            if (value > 500)
            {
                Debug.LogError("Speed cannot exceed 500");
                m_speed = 0;
            }
            else
            {
                m_speed = value;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        Control();
        Boost();
        Jump();
    }

    //ABSTRACTION
    public void Control()
    {
        float verticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * verticalInput * speed * Time.deltaTime);
    }

    //ABSTRACTION
    public void Boost()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            playerRb.AddForce(focalPoint.transform.forward * boostPower, ForceMode.Impulse);
        }
    }

    //ABSTRACTION
    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onGround == true)
        {
            playerRb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            onGround = false;
        }
    }

    //ABSTRACTION
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
    }
}
