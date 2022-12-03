using UnityEngine;

/* [CLASS DOCUMENTATION]
 * 
 * This script is used on a gameObject that's placed very close to the takeoff platform and pushes the player to the right.
 * 
 */

public class RotateMidAir : MonoBehaviour
{
    //Private variables
    bool activated = false;
    Ray ray;

    private void Start()
    {
        //Create the ray
        ray = new Ray(transform.position, Vector3.right);
    }

    private void Update()
    {
        if (activated) return;

        RaycastHit hit;
        //If the ray hits the player...
        if (Physics.Raycast(ray, out hit, 10f))
        {
            if (hit.collider.CompareTag("Player"))
            {
                //Call th player.PushRight method.
                Player.S.PushRight(25f);
                activated = true;
            }
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, Vector3.right * 10f);
    }
#endif
}
