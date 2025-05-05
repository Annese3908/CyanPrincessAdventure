using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileController : ProjectileController
{
    float coolDownMax;
    float cooldownMin = 5f;
    // Start is called before the first frame update
    protected override void Start()
    {
        coolDownMax = data.CooldownDuration;
        currCooldown = Random.Range(cooldownMin, coolDownMax);
    }

    protected override void Attack(){
        base.Attack();
        currCooldown = Random.Range(cooldownMin, coolDownMax);
    }

    // Update is called once per frame
}
