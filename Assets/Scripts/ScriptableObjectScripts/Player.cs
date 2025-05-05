using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Player", menuName = "ScriptableObject/Player")]
public class Player: ScriptableObject 
{
    [SerializeField]
    float health;
    public float Health{get => health; private set => health = value;}
    
    [SerializeField]
    float speed;
    public float Speed{get => speed; private set => speed = value;}
    [SerializeField]
    int lives;
    public int Lives{get => lives; private set => lives = value;}
}
