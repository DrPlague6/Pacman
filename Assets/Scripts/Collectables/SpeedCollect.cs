using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedCollect : MonoBehaviour
{
    [SerializeField] GameEvent _speedBoostCollectd;
    void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            PlayerCollect();
        }
    }
    void PlayerCollect(){
        _speedBoostCollectd?.Invoke();
        gameObject.SetActive(false);
    }
}
