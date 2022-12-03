using UnityEngine;

using Cinemachine;

/* [CLASS BEHAVIOUR]
 * 
 * THIS CLASS HAS A SINGLETON
 * 
 * Inspector variables: These variables must be set from the inspector.
 * Private variables: These variables are changed in runtime.
 * 
 * [Class flow]
 * This script is responsible for the earth countdown sequence that starts the whole "domino-effect" level.
 * 
 * [Must know]
 * 1. Inside the update method the countdown text gets automatically updated.
 * 
 */
public class TakeOffManager : MonoBehaviour
{
    public static TakeOffManager S;

    #region INSPECTOR_VARIABLES
    [Header("Set take off cameras")]
    [SerializeField] CinemachineVirtualCamera toBeEnabled;
    [SerializeField] CinemachineVirtualCamera toBeDisabled;
    #endregion

    #region PRIVATE_VARIABLES
    bool startTakeOff = false;
    float takeOffTime = 4f;
    float remainingTime;
    #endregion

    private void Awake()
    {
        if (S == null || S != this)
        {
            S = this;
        }

        remainingTime = takeOffTime;
    }

    /// <summary>
    /// Call to initiate the player upward push sequence.
    /// </summary>
    public void StartTakeOff()
    {
        startTakeOff = true;
        CameraBehaviour.S.EnableCamera(toBeEnabled, toBeDisabled);

        UI_Manager.S.ClearTakeOffHint();
        SoundManager.S.PlayOneShotAudio(GameSounds.Countdown, 0.1f);
    }

    private void Update()
    {
        //Continue only if startTakeOff is true.
        if (startTakeOff)
        {
            remainingTime -= Time.deltaTime;

            UI_Manager.S.UpdateTakeOffText(GetRemainingTime());

            if (remainingTime <= 0f)
            {
                Player.S.PushPlayerUp();
                startTakeOff = false;

                UI_Manager.S.ClearTakeOffText();
            }
        }
    }

    /// <summary>
    /// Call to get the remaining timer time casted as an INT.
    /// </summary>
    int GetRemainingTime()
    {
        return (int)remainingTime;
    }

    private void OnDestroy()
    {
        S = null;
    }
}
