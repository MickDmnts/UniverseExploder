using UnityEngine;

public class MarsPusher : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Add an INSTANT force to the player
            Player.S.GetRigidbody().AddForce(Vector3.right * 10f, ForceMode.Impulse);
        }
    }
}
