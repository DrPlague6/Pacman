using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public int MaxHealth = 3;
    private int health;
    public float PlayerSpeed;
    public float TurnSmoothingTime = 0.1f;

    public GameObject HealthBar;
    public Sprite hpSprite;
    public int score;
    public float SpeedBoost = 1;
    public float BoostersDuration = 100;
    private float boosterTimeExp = 0;
    void Start()
    {
        //add hp icons to bar
        for(int i =0; i<MaxHealth;i++){
           createNewHpIcon();
        }
        health = MaxHealth;
    }

    void Update()
    {
        if(Time.time > boosterTimeExp){
            SpeedBoost = 1;
        }
    }
    public void SpeedPowerUP(){
        SpeedBoost = 2;
    }
    public void HealthPowerUP(){
        if(health++ >= MaxHealth){
            score +=10;
        }
        else{
            health++;
            createNewHpIcon();
        }
        
    }
    private void createNewHpIcon(){
        GameObject hpIcon = new GameObject();
        Image newHpImage = hpIcon.AddComponent<Image>();
        newHpImage.sprite = hpSprite;
        hpIcon.transform.SetParent(HealthBar.transform);
    }
    public void takeDamage(){
        health--;
        if(health == 0)
            die();
    }
    private void die(){
        //TODO:: ENDGAME SCREEN
    }
    void OnTriggerEnter(Collider other){
        if(other.gameObject.layer == LayerMask.NameToLayer("Collectables"))
        {
            switch (other.gameObject.tag){
                case "HealthBoost":
                    HealthPowerUP();
                    break;
                case "SpeedBoost":
<<<<<<< Updated upstream
                    SpeedPowerUP();
                    boosterTimeExp = Time.time + BoostersDuration;
=======
                    playerPowerUps.SpeedPowerUP(playerObject.BoostersDuration);
>>>>>>> Stashed changes
                    break;
                default:
                    score++;
                    break;
            }
            Destroy(other.gameObject);
            Debug.Log("playerhit");
        }
    }
}
