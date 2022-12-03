using UnityEngine;
using TMPro;

/* [CLASS BEHAVIOUR]
 * 
 * THIS CLASS HAS A SINGLETON
 * 
 * Private variables: These variables are changed in runtime.
 * 
 * [Class flow]
 * This script is responsible for the UI text changing aspect of the demo and haves only public methods.
 */
public class UI_Manager : MonoBehaviour
{
    public static UI_Manager S;

    #region PRIVATE_VARIABLES
    TextMeshProUGUI takeOffText;
    TextMeshProUGUI initiateText;
    TextMeshProUGUI alienBattleText;
    #endregion

    private void Awake()
    {
        if (S == null || S != this)
        {
            S = this;
        }

        takeOffText = GameObject.FindGameObjectWithTag("TakeOffText").GetComponent<TextMeshProUGUI>();
        initiateText = GameObject.FindGameObjectWithTag("InitiateText").GetComponent<TextMeshProUGUI>();
        alienBattleText = GameObject.FindGameObjectWithTag("AlienBattleText").GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    /// <summary>
    /// Call to set the takeOfText field to the passed string.
    /// </summary>
    /// <param name="time"></param>
    public void UpdateTakeOffText(int time)
    {
        takeOffText.SetText(time.ToString());
    }

    /// <summary>
    /// Call to set the takeOfText field to String.Empty.
    /// </summary>
    public void ClearTakeOffText()
    {
        takeOffText.SetText(System.String.Empty);
    }

    /// <summary>
    /// Call to set the initiateText field to String.Empty.
    /// </summary>
    public void ClearTakeOffHint()
    {
        initiateText.SetText(System.String.Empty);
    }

    /// <summary>
    /// Call to set the alienBattleText field to the passed string.
    /// </summary>
    public void UpdateAlienBattleText(string text)
    {
        alienBattleText.SetText(text);
    }

    /// <summary>
    /// Call to set the takeOfText field to the passed string.
    /// </summary>
    public void ClearAlienBattleText()
    {
        alienBattleText.SetText(System.String.Empty);
    }

    private void OnDestroy()
    {
        S = null;
    }
}
