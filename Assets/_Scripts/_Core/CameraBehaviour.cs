using UnityEngine;

using Cinemachine;

/*[CLASS DOCUMENTATION]
 * 
 *  THIS CLASS HAVES A SINGLETON
 *  
 *  [Class Flow]
 *  The sole purpose of this script is to have a public method that accepts a camera to disable and a camera to enable.
 *  The transition is handled from Cinemachine.
 *  
 */

public class CameraBehaviour : MonoBehaviour
{
    public static CameraBehaviour S;

    private void Awake()
    {
        if (S == null || S != this)
        {
            S = this;
        }
    }

    /// <summary>
    /// Call to enable the first passed camera and disable the second one.
    /// </summary>
    /// <param name="enableCam"></param>
    /// <param name="disableCam"></param>
    public void EnableCamera(CinemachineVirtualCamera enableCam, CinemachineVirtualCamera disableCam)
    {
        enableCam.gameObject.SetActive(true);
        disableCam.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        S = null;
    }
}
