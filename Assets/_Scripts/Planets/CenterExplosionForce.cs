using UnityEngine;

/* [CLASS DOCUMENTATION]
 * 
 * Inspector variables: These variables must be set from the inspector.
 * 
 * [Must know]
 * 1. This script is placed in a planet "core" gameobject in the middle of the moon.
 * 
 */

public class CenterExplosionForce : MonoBehaviour
{
    [Header("Set in inspector")]
    [SerializeField] GameObject dummyMoon;
    [SerializeField] float radius;
    [SerializeField] float explosionForce;
    [SerializeField] ParticleSystem moonExplosion;

    /// <summary>
    /// Call to start the moon explosion simulation and play an explosion SFX.
    /// </summary>
    public void ExplodeMoon()
    {
        //Play the SFX
        SoundManager.S.PlayOneShotAudio(GameSounds.Supernova, 0.1f);

        dummyMoon.SetActive(false);

        Vector3 explosionPos = transform.position;

        //Simulate the explosion force.
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            if (hit.CompareTag("MoonFragment"))
            {

                Rigidbody rb = hit.GetComponent<Rigidbody>();

                rb.isKinematic = false;

                if (rb != null)
                {
                    rb.AddExplosionForce(explosionForce, explosionPos, radius);
                }
            }
        }

        moonExplosion.Play();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
