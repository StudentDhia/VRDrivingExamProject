using UnityEngine;

[ExecuteInEditMode]
public class EasySuspension : MonoBehaviour
{
	[Range(0.1f, 20f)]
	[Tooltip("Natural frequency of the suspension springs. Describes bounciness of the suspension.")]
	public float naturalFrequency = 10;

	[Range(0f, 3f)]
	[Tooltip("Damping ratio of the suspension springs. Describes how fast the spring returns back after a bounce. ")]
	public float dampingRatio = 0.8f;

	[Range(-1f, 1f)]
	[Tooltip("The distance along the Y axis the suspension forces application point is offset below the center of mass")]
	public float forceShift = 0.03f;

	[Tooltip("Adjust the length of the suspension springs according to the natural frequency and damping ratio. When off, can cause unrealistic suspension bounce.")]
	public bool setSuspensionDistance = true;
    public float vitesse;
   public static Rigidbody m_Rigidbody;
    public bool inf = false;
    void Start ()
    {
        m_Rigidbody = GetComponent<Rigidbody> ();
    }
    
	void Update () 
    {
        //Debug.Log(m_Rigidbody.velocity.magnitude * 3.6 + "KM/H");
        // Work out the stiffness and damper parameters based on the better spring model.
        foreach (WheelCollider wc in GetComponentsInChildren<WheelCollider>()) 
        {
			JointSpring spring = wc.suspensionSpring;

            float sqrtWcSprungMass = Mathf.Sqrt (wc.sprungMass);
            spring.spring = sqrtWcSprungMass * naturalFrequency * sqrtWcSprungMass * naturalFrequency;
            spring.damper = 2f * dampingRatio * Mathf.Sqrt(spring.spring * wc.sprungMass);

			wc.suspensionSpring = spring;
            Debug.Log("temchi " + isMoving());
            //Debug.Log("KM/h " + m_Rigidbody.velocity.magnitude*1000);
            Vector3 wheelRelativeBody = transform.InverseTransformPoint(wc.transform.position);
            float distance = m_Rigidbody.centerOfMass.y - wheelRelativeBody.y + wc.radius;
           // Debug.Log("vitesse " + m_Rigidbody.velocity.magnitude);
            if (m_Rigidbody.velocity.magnitude > 15)
            {
                Debug.Log("alert vitesse");
            }
            if (m_Rigidbody.velocity.magnitude < 3)
            {
                inf = true;
                Debug.Log(inf);
            }
            else
            {
                inf = false;
                Debug.Log(inf);
            }
            vitesse = m_Rigidbody.velocity.magnitude;
          //  Debug.Log(vitesse);
            wc.forceAppPointDistance = distance - forceShift;
           // Debug.Log(""+ wc.forceAppPointDistance);
            // Make sure the spring force at maximum droop is exactly zero
            if (spring.targetPosition > 0 && setSuspensionDistance)
				wc.suspensionDistance = wc.sprungMass * Physics.gravity.magnitude / (spring.targetPosition * spring.spring);
		}

       // var go = GameObject.Find("Track");

       // Debug.Log("Terrain Near : " + Vector3.Distance(transform.position, go.transform.position));
    }

    public bool isMoving()
    {
        return m_Rigidbody.velocity.magnitude < 1 ? false : true ;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.transform.name == "Terrain") || (collision.transform.name == "WaterPlane"))
        {
            Debug.Log("hi");
        }
        if (collision.transform.name == "Stop")
        {
            Debug.Log("hi From Stop");
        }
        if(collision.transform.name == "Stop" && !isMoving())
        {
            Debug.Log("Stop true");
        }
        if (collision.transform.hasChanged)
        {
            Debug.Log("collision");
        }
    }
    // Uncomment this to observe how parameters change.
    /*
    void OnGUI()
    {
        foreach (WheelCollider wc in GetComponentsInChildren<WheelCollider>()) {
            GUILayout.Label (string.Format("{0} sprung: {1}, k: {2}, d: {3}", wc.name, wc.sprungMass, wc.suspensionSpring.spring, wc.suspensionSpring.damper));
        }

        GUILayout.Label ("Inertia: " + m_Rigidbody.inertiaTensor);
        GUILayout.Label ("Mass: " + m_Rigidbody.mass);
        GUILayout.Label ("Center: " + m_Rigidbody.centerOfMass);
    }
    */

}
