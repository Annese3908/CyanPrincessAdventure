using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "SpeedUp", menuName = "ScriptableObject/PowerUp/SpeedUp")]
public class SpeedMultiplier : PowerUp
{
    float cooldown = 10f;
    public float multiplier = 1.5f;
    public override void Apply(GameObject target){
        target.GetComponent<PlayerMovement>().SpeedBoost(multiplier, cooldown);
    }
}
