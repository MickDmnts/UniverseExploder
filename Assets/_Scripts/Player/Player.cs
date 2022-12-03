using UnityEngine;

/* [CLASS BEHAVIOUR]
 * 
 * THIS CLASS HAS A SINGLETON
 * 
 * Inspector variables: These variables must be set from the inspector.
 * Private variables: These variables are changed in runtime.
 * 
 * [Class flow]
 * This sscript haves public methods that control the players RigidBody behaviour.
 */

public class Player : MonoBehaviour
{
    public static Player S;

    [Header("Set in inspector")]
    [SerializeField] float takeOffForce;

    //Private variables
    Rigidbody playerRB;
    bool tookOff = false;

    private void Awake()
    {
        if (S == null || S != this)
        {
            S = this;
        }

        //Cache the players rb
        playerRB = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !tookOff)
        {
            InitiateTakeOff();
        }
    }

    /// <summary>
    /// Call to invoke the TakeOffManager.StartTakeOff() method and set tookOff to true.
    /// </summary>
    void InitiateTakeOff()
    {
        tookOff = true;

        TakeOffManager.S.StartTakeOff();
    }

    /// <summary>
    /// Call to push add an INSTANT upwards force (world-position) to the player.
    /// </summary>
    public void PushPlayerUp()
    {
        playerRB.AddForce(Vector3.up * takeOffForce, ForceMode.Impulse);
    }

    /// <summary>
    /// Call to push add an INSTANT right "pushForce" (world-position) to the player.
    /// </summary>
    public void PushRight(float pushForce)
    {
        playerRB.AddForce(Vector3.right * pushForce, ForceMode.Impulse);
    }

    /// <summary>
    /// Call to set the players rb velocity to Vector3.zero.
    /// </summary>
    public void StopOnPoint()
    {
        playerRB.velocity = Vector3.zero;
    }

    /// <summary>
    /// Call to apply a forward instant torque rotation to the players RB.
    /// </summary>
    public void ApplyTorqueRotation()
    {
        playerRB.AddTorque(Vector3.forward, ForceMode.Impulse);
    }

    /// <summary>
    /// Call to get a reference to the players RB.
    /// </summary>
    /// <returns></returns>
    public Rigidbody GetRigidbody() => playerRB;

    private void OnDestroy()
    {
        S = null;
    }
}
