using UnityEngine;

public class EarthRotator : MonoBehaviour
{
    //Private variable
    Rigidbody earthRB;

    private void Awake()
    {
        //Cache the earths RB.
        earthRB = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        //Simulate the planets rotation.
        earthRB.AddTorque(Vector3.up * 50f, ForceMode.Acceleration);
    }
}
