using UnityEngine;
using System.Collections;

[DisallowMultipleComponent]
public class AIDeath : MonoBehaviour
{
    AICore core;
    bool isDead = false;

    void Start()
    {
        core = GetComponent<AICore>();
        isDead = false;
    }

    public void Death()
    {
        if (!isDead)
        {
            if (!core.instaDeath)
            {
                StartCoroutine("Die");
            }
            else
            {
                InstantiateBloodSpatter();
                Destroy(gameObject);
            }
        }
    }

    IEnumerator Die()
    {
        isDead = true;
        if (!core.tracker.ConstantUpdate)
        {
            core.targetting.RemoveFromTracker();
        }
        gameObject.tag = "Untagged";
        AISpawner spawner = core.stats.spawner;
        bool isSpawned = core.stats.isSpawned;
        if (!core.instaDeath)
        {
            core.animator.isDead();
        }
        yield return new WaitForSeconds(0.1f);
        core.ragdoll.activateRagdoll();
        yield return new WaitForSeconds(0.01f);
        if (core.stats.instantiateBlood && core.objects.bloodpool)
        {
         InstantiateBloodpool();
        }
        //  GameObject myloot = InstantiateMyLoot();
        yield return new WaitForSeconds(0.01f);
        core.deactivator.DestroyComponents();
        yield return new WaitForSeconds(120f);
        if (isSpawned)
        {
            spawner.Spawn();
        }
        //    Destroy(myloot);
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }   

    void InstantiateBloodpool()
    {
        GameObject Bloodpool = core.objects.bloodpool;
        Instantiate(Bloodpool, transform.position, transform.rotation);
    }

    void InstantiateBloodSpatter()
    {
        GameObject Bloodspatter = core.objects.bloodSpatter;
        Instantiate(Bloodspatter, transform.position, transform.rotation);
    }
}
