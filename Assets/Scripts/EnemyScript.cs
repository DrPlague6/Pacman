using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyScript : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform Player;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = Player.position;
    }

    void Update()
    {
        
    }
}
