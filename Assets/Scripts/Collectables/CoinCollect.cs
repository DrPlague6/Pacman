using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    [SerializeField] GameEvent _coinCollected;
    void Awake(){

    }
    void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            PlayerCollect();
        }
    }
    void PlayerCollect(){
        _coinCollected?.Invoke();
        this.gameObject.SetActive(false);
    }
    void OnDestroy(){

    }
}
