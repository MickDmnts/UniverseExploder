using UnityEngine;

public class MoonExplosionController : MonoBehaviour
{
    //Private variable
    CenterExplosionForce moonCenter;

    private void Awake()
    {
        //Cache the CenterExplosionForce script - inside the moon gameobject
        moonCenter = FindObjectOfType<CenterExplosionForce>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Triggered from the player
            moonCenter.ExplodeMoon();
        }
    }
}
