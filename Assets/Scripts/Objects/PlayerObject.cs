using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Entity", menuName = "Entity/Player", order = 2)]
public class PlayerObject : EntityObject
{
    public int MaxHealth = 3;
    private int health;
    public GameObject hpIcon;
    public float BoostersDuration = 5f;
    public float SpeedBoost = 1;
    public Canvas PlayerOverlay;
    public GameObject HealthBar;
    public GameObject GameStateUI;
    public int Health{
        get => health;
        set => health = value;
    }
}
