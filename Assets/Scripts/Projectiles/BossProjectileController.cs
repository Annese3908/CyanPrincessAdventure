using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectileController : MonoBehaviour
{
    enum SpawnerType {Straight, Spin};
    public Projectile data;
    [SerializeField] private SpawnerType spawnerType;
    float fireRate;

    float coolDownMax = 10;
    float coolDownMin = 5;
    float coolDown;

    // Start is called before the first frame update
    void Awake()
    {
        fireRate = data.CooldownDuration;
        coolDown = Random.Range(coolDownMin, coolDownMax);
    }

    // Update is called once per frame

    void Start(){
        StartCoroutine(AttackPattern());
    }
    IEnumerator AttackPattern(){
        while (true){
            // Attack phase
            while (coolDown > 0)
            {
                if (fireRate <= 0f)
                {
                    Attack();
                }
                fireRate -= Time.deltaTime;
                coolDown -= Time.deltaTime;
                yield return null;
            }

            // Cooldown phase
            coolDown = coolDownMax;
            yield return new WaitForSeconds(coolDown);
        }
    }
    void Update()
    {
        if(spawnerType == SpawnerType.Spin){
            transform.eulerAngles = new Vector3(0f,0f,transform.eulerAngles.z+1f);
        }
    }

    void Attack(){
        GameObject projectile = Instantiate(data.Prefab);
        projectile.transform.position = transform.position;
        projectile.transform.rotation = transform.rotation;
        fireRate = data.CooldownDuration;
    }
}
