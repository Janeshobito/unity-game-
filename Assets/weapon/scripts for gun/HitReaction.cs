using UnityEngine;

public class HitReactionHandler : MonoBehaviour
{
    public void ApplyHitReaction(Transform hitBone, Vector3 hitDirection)
    {
        Rigidbody rb = hitBone.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(hitDirection * 5f, ForceMode.Impulse);
        }

        Debug.Log("Hit reaction applied to " + hitBone.name);
    }
}
