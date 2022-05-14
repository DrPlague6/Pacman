using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using System.Threading.Tasks;

public class PlayerPowerUps : MonoBehaviour
{
    [SerializeField]
    public PlayerScript playerScript;
    public Volume PostProcessor;

     public async void SpeedPowerUP(float durationTime){
        playerScript.playerObject.SpeedBoost = 2;
        PostProcessor.weight = 0f;
        float remainingTime = durationTime;
        while(remainingTime > 0){
            if(remainingTime > durationTime * 0.6)
                PostProcessor.weight += 0.005f;
            else
            PostProcessor.weight -= 0.001f;
            remainingTime -=Time.deltaTime;
            await Task.Yield();
        }
        playerScript.playerObject.SpeedBoost = 1;
        PostProcessor.weight = 0f;
    }
    public void HealthPowerUP(){
        if(playerScript.playerObject.Health++ >= playerScript.playerObject.MaxHealth){
            playerScript.score +=10;
        }
        else{
            playerScript.playerObject.Health++;
            playerScript.CreateNewHpIcon();
        }
        
    }
}
