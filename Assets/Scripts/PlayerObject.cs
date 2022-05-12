using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Entity", menuName = "Entity/Player", order = 2)]
public class PlayerObject : EntityObject
{
    public int MaxHealth = 3;
    private int health;
    public Sprite hpSprite;
    public float BoostersDuration = 5f;
    public float SpeedBoost = 1;
    public int Score=0;

    // Start is called before the first frame update
    public int Health{
        get => health;
        set => health = value;
    }
}
