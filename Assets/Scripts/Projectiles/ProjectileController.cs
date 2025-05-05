using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Class Definition for all weapons
public class ProjectileController : MonoBehaviour
{
    [Header("Projectile Stats")]
    public Projectile data;

    [HideInInspector]
    public float currCooldown;
    private float modCooldown;
    private bool isPowerUpActive = false;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        currCooldown = data.CooldownDuration;
        modCooldown = data.CooldownDuration;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        currCooldown -= Time.deltaTime;
        if (currCooldown <= 0f){
            Attack();
        }
    }
    protected virtual void Attack(){
        GameObject projectile = Instantiate(data.Prefab);
        projectile.transform.position = transform.position;
        if (!isPowerUpActive)
        {
            currCooldown = data.CooldownDuration;
        }
        else
        {
            currCooldown = modCooldown;
        }
    }

    public void FireRateBoost(float multiplier, float duration)
    {
        if (!isPowerUpActive)
        {
            modCooldown = data.CooldownDuration; // Backup original
        }

        // Apply multiplier
        modCooldown = data.CooldownDuration * multiplier;
        isPowerUpActive = true;

        // Schedule revert
        Invoke(nameof(RevertFireRate), duration);
    }

    private void RevertFireRate()
    {
        currCooldown = data.CooldownDuration;
        isPowerUpActive = false;
    }
}
