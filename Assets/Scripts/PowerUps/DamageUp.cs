using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DamageUp", menuName = "ScriptableObject/PowerUp/DamageUp")]
public class DamageUp : PowerUp
{
    public Projectile defaultProjectile;
    public Projectile powerUpProjectile;

    float cooldown = 10f;
    // Start is called before the first frame update
    public override void Apply(GameObject target){
        ProjectileController controller = target.GetComponentInChildren<ProjectileController>();
        controller.data = powerUpProjectile;
        MonoBehaviour behaviour = target.GetComponent<MonoBehaviour>();
        behaviour.StartCoroutine(RevertAfterCooldown(controller));
    }

   private IEnumerator RevertAfterCooldown(ProjectileController controller)
    {
        yield return new WaitForSeconds(cooldown);
        controller.data = defaultProjectile; // Revert to default
    }
}
