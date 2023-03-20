using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//INHERITENCE
public class EnemySpeed : Enemy
{
    private Rigidbody speedRb;
    private float boostPower = 6;
    private GameObject focal;
    private float waitTime = 5;
    private bool canBoost = true;
    // Start is called before the first frame update
    void Start()
    {
        speedRb = GetComponent<Rigidbody>();
        focal = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        Boosting();
    }

    //POLYMORPHISM
    //ABSTRACTION
    public void Boosting()
    {
        if (canBoost == true)
        {
            Vector3 towardPlayer = (focal.transform.position - transform.position).normalized;
            speedRb.AddForce(towardPlayer * boostPower, ForceMode.Impulse);
            canBoost = false;
            StartCoroutine(boostCooldown());
        }
    }

    IEnumerator boostCooldown()
    {
        yield return new WaitForSeconds(waitTime);
        canBoost = true;
    }
}
