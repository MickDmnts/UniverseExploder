using UnityEngine;

public class RagdollController : MonoBehaviour
{
    [Header("Set in inspector")]
    [SerializeField] Rigidbody[] rigidbodies;

    //Private variable
    bool isRagdolled;

    private void Awake()
    {
        EntrySetup();
    }

    /// <summary>
    /// Call to correctly setup the attached gameobject and script.
    /// </summary>
    void EntrySetup()
    {
        isRagdolled = false;

        rigidbodies = GetComponentsInChildren<Rigidbody>();

        for (int i = 0; i < rigidbodies.Length; i++)
        {
            rigidbodies[i].isKinematic = true;
        }
    }

    /// <summary>
    /// Call to make all the attached rigidBodies of THIS gameObject non-kinematic and add an INSTANT forward force.
    /// </summary>
    /// <param name="hitDirection"></param>
    public void EnableRagdoll(Vector3 hitDirection)
    {
        if (isRagdolled) return;

        for (int i = 0; i < rigidbodies.Length; i++)
        {
            rigidbodies[i].isKinematic = false;
            rigidbodies[i].AddForce(transform.forward * 50f, ForceMode.Impulse);
        }

        isRagdolled = true;
    }
}
