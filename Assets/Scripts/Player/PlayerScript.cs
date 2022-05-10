using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public int Health;
    public float PlayerSpeed;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void SpeedPowerUP(){
        PlayerSpeed *= 1.5f;
    }
    public void HealthPowerUP(){
        Health += 1;
    }
    public void takeDamage(){
        Health--;
        if(Health ==0)
            die();
    }
    private void die(){
        //TODO:: ENDGAME SCREEN
    }
}
