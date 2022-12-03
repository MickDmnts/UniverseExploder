using System.Collections;
using UnityEngine;

public class MarsSequence : MonoBehaviour
{
    //Private variable
    bool isActivated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (isActivated) return;

        //Activated only from the player.
        if (other.CompareTag("Player"))
        {
            isActivated = true;
            StartCoroutine(InitiateMarsActions());
        }
    }

    /// <summary>
    /// Call to initiate the mars KAMEHAMEHA sequence along with the sound effect.
    /// </summary>
    /// <returns></returns>
    IEnumerator InitiateMarsActions()
    {
        Player.S.StopOnPoint();

        yield return new WaitForSeconds(1f);

        SoundManager.S.PlayOneShotAudio(GameSounds.NANI, 0.5f);

        yield return new WaitForSeconds(0.5f);

        UI_Manager.S.UpdateAlienBattleText("NANI");

        yield return new WaitForSeconds(2f);

        Player.S.ApplyTorqueRotation();

        SoundManager.S.PlayOneShotAudio(GameSounds.GOKU, 0.5f);

        yield return new WaitForSeconds(1f);

        UI_Manager.S.UpdateAlienBattleText("KAME-");

        yield return new WaitForSeconds(2f);

        UI_Manager.S.UpdateAlienBattleText("HAME-");

        yield return new WaitForSeconds(1f);

        UI_Manager.S.UpdateAlienBattleText("-HAAA");

        Player.S.PushRight(100f);
    }
}
