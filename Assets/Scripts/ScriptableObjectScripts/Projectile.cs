using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewProjectile", menuName = "ScriptableObject/Projectile")]
public class Projectile : ScriptableObject 
{
    [SerializeField]
    GameObject prefab;
    public GameObject Prefab{get => prefab; private set => prefab = value;}
    [SerializeField]
    // base stats for weapons
    float damage;
    public float Damage{get => damage; private set => damage = value;}
    [SerializeField]
    float speed;
    public float Speed{get => speed; private set => speed = value;}
    [SerializeField]
    float cooldownDuration;
    public float CooldownDuration{get => cooldownDuration; private set => cooldownDuration = value;}
    [SerializeField]
    int projectileAmnt;
    public int ProjectileAmnt{get => projectileAmnt; private set => projectileAmnt = value;}
}
