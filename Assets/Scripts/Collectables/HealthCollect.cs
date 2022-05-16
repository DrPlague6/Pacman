using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollect : MonoBehaviour
{
    [SerializeField] GameEvent _healthCollected;
    void OnTriggerEnter(Collider other){
        if(other.tag == "Player")
        {
            _healthCollected?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
