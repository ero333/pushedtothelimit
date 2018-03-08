using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour {
	public float G = 0.06674f;

	public static List<Attractor> Attractors;

	public Rigidbody2D rb;


    void FixedUpdate()
    {
        foreach (Attractor attractor in Attractors)
        {
			if ((attractor != this) && (attractor.transform.parent == null)) {
				Attract (attractor);
			}
        }
    }

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Start()
	{
		if (Attractors == null)
			Attractors = new List<Attractor>();

		Attractors.Add(this);
	}
    
	void OnDestroy()
	{
		Attractors.Remove(this);
	}
  
    void Attract (Attractor objToAttract)
	{
		Rigidbody2D rbToAttract = objToAttract.rb;

		Vector2 direction = rb.position - rbToAttract.position;
		float distance = direction.magnitude;
        float forceMagnitude;

        if (distance == 0f)
			return;
			
			forceMagnitude = G * (rb.mass * rbToAttract.mass) / Mathf.Pow (distance, 2);
			Vector2 force = direction.normalized * forceMagnitude;
			rbToAttract.AddForce (force * Time.fixedDeltaTime);

	}
}
