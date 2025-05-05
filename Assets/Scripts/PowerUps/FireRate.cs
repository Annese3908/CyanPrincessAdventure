using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "FireRate", menuName = "ScriptableObject/PowerUp/FireRate")]
public class FireRate : PowerUp
{
    float cooldown = 10f;
    float multiplier = 0.25f;
    public override void Apply(GameObject target){
        ProjectileController controller = target.GetComponentInChildren<ProjectileController>();
        controller.FireRateBoost(multiplier, cooldown);
    }
}
