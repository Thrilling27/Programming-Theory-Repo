using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody enemyRb;
    private GameObject m_player;
    public float speed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        m_player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Travel();

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }

    //ENCAPSULATION
    public GameObject player
    {
        get { return m_player; }
    }

    public virtual void Travel()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed);
    }
}
