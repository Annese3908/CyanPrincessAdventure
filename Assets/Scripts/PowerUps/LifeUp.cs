using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LifeUp", menuName = "ScriptableObject/PowerUp/LifeUp")]
public class LifeUp : PowerUp
{
    public override void Apply(GameObject target){
    target.GetComponent<PlayerStats>().AddLife();
   }
}
