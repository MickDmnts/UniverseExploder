using UnityEngine;

public class PushAlien : MonoBehaviour
{
    [Header("Set in inspector")]
    [SerializeField] RagdollController ragdollController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Push the alien to theopposite direction of the player
            Vector3 direction = transform.position - other.transform.position;

            ragdollController.EnableRagdoll(direction);
        }
    }
}
