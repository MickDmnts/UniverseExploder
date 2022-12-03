using UnityEngine;

using Cinemachine;

/* [CLASS DOCUMENTATION]
 * 
 * Inspector variables: These variables must be set from the inpsector.
 * 
 * [Class behaviour]
 * The purpose of this script is to get activated when the player enters its trigger volume.
 * When the player touches this trigger area the inspector assigned cameras get disabled/enabled.
 * 
 */

public class ChangeCameraOnTriggerEnter : MonoBehaviour
{
    [Header("Set in inspector")]
    [SerializeField] CinemachineVirtualCamera toBeDisabled;
    [SerializeField] CinemachineVirtualCamera toBeEnabled;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CameraBehaviour.S.EnableCamera(toBeEnabled, toBeDisabled);
        }
    }
}
