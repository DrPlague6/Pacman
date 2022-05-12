using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerScript : MonoBehaviour
{
    public GameObject HealthBar;
    public float TurnSmoothingTime = 0.1f;
    public int score;
    public PlayerObject playerObject;
    [SerializeField]
    public PlayerPowerUps playerPowerUps;
    void Start()
    {
        //add hp icons to bar
        for(int i = 0; i<playerObject.MaxHealth;i++){
           CreateNewHpIcon();
        }
        playerObject.Health = playerObject.MaxHealth;
    }
    void Update()
    {
    }
    public void CreateNewHpIcon(){
        GameObject hpIcon = new GameObject();
        Image newHpImage = hpIcon.AddComponent<Image>();
        newHpImage.sprite = playerObject.hpSprite;
        hpIcon.transform.SetParent(HealthBar.transform);
    }
    public void takeDamage(){
        playerObject.Health--;
        HealthBar.transform.GetChild(HealthBar.transform.childCount).gameObject.SetActive(false);
        if(playerObject.Health == 0)
            die();
    }
    private void die(){
        //TODO:: ENDGAME SCREEN
    }
    void OnTriggerEnter(Collider other){
        if(other.gameObject.layer == LayerMask.NameToLayer("Interactable") || other.gameObject.layer == LayerMask.NameToLayer("Enemies"))
        {
            switch (other.gameObject.tag){
                case "HealthBoost":
                    playerPowerUps.HealthPowerUP();
                    other.gameObject.SetActive(false);
                    break;
                case "SpeedBoost":
                    playerPowerUps.SpeedPowerUP();
                    other.gameObject.SetActive(false);
                    break;
                case "Enemy":
                    Debug.Log("enemy");
                    transform.position = GameObject.FindGameObjectWithTag("Respawn").transform.position;
                break;
                default:
                    score++;
                    break;
            }
        }
    }
}
