using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    private float health;
    public float maxhealth = 100f;
    public float chipSpeed = 2f;
    private float lerptimer;
    public Image frontHealthBar;
    public Image backhealthbar;
    // Start is called before the first frame update
    void Start()
    {
        health = maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        health =Mathf.Clamp(health, 0, maxhealth);
        updateHealthUI();
        /*if ( Input.GetKeyDown(KeyCode.A))
        {
            TakeDamage(Random.Range(5, 10));
        }*/
    }

    public void updateHealthUI()
    {
        Debug.Log("Health: " + health);
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        lerptimer = 0;
    }

}
