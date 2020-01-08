using UnityEngine;

public class SporeController : MonoBehaviour
{
    public float sporeMaxSpeed;
    public float sporeMinSpeed;
    public float sporeAngle;
    public float sporeTorqueAngle;

    Rigidbody2D sporeRB2D;

    // Start is called before the first frame update
    void Start()
    {
        sporeRB2D = GetComponent<Rigidbody2D>();
        sporeRB2D.AddForce(new Vector2(Random.Range(-sporeAngle, sporeAngle), Random.Range(sporeMinSpeed, sporeMaxSpeed)), ForceMode2D.Impulse);
        sporeRB2D.AddTorque(Random.Range(-sporeTorqueAngle, sporeTorqueAngle));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
