using UnityEngine;

public class BulletImpact : MonoBehaviour
{
    [Header("Settings")]
    public GameObject impactPrefab;
    public int damage = 1;

    private void OnTriggerEnter(Collider other)
    {
        // Spawn impact effect
        if (impactPrefab)
        {
            Instantiate(impactPrefab, transform.position, Quaternion.identity);
        }

        // Apply damage
        TargetHealth target = other.GetComponent<TargetHealth>();
        if (target != null)
        {
            target.TakeDamage(damage);
        }

        // Destroy bullet
        Destroy(gameObject);
    }
}
