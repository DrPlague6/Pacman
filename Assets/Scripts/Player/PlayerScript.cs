using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] public float TurnSmoothingTime = 0.1f;
    public int score;
    private int maxCoins;
    private int collectedCoins;
    public PlayerObject playerObject;
    [SerializeField] public PlayerPowerUps playerPowerUps;
    void Start()
    {
        //add hp icons to bar
        // for(int i = 0; i<playerObject.MaxHealth;i++){
        //    CreateNewHpIcon();
        // }
        // playerObject.Health = playerObject.MaxHealth;
        maxCoins = GameObject.FindGameObjectsWithTag("Coin").Length;
    }
    void Update()
    {
    }
    public void takeDamage(){
        playerObject.Health--;
        if(playerObject.Health == 0)
            die();
        transform.position = GameObject.FindGameObjectWithTag("Respawn").transform.position;
        Debug.Log(playerObject.Health);
    }
    private void die(){

        Time.timeScale = 0;
    }
    void OnTriggerEnter(Collider other){
        if(other.gameObject.layer == LayerMask.NameToLayer("Enemies"))
            takeDamage();
    }
    public void CoinCollected(){
        score++;
        collectedCoins++;
        if(collectedCoins >= maxCoins){
            // win();
        }
    }
}
