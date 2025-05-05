using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObject/Enemy")]
public class Enemy: ScriptableObject 
{
    [SerializeField]
    float damage;
    public float Damage{get => damage; private set => damage = value;}
    [SerializeField]
    float health;
    public float Health{get => health; private set => health = value;}

    [SerializeField]
    float speed;
    public float Speed{get => speed; private set => speed = value;}
    
    [SerializeField]
    int score;
    public int Score{get => score; private set => score = value;}
}
