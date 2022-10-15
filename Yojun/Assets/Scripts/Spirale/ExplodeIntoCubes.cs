using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeIntoCubes : MonoBehaviour
{
   public int cubesPerAxis = 4;
	public float delay = 1f;
	public float force = 10f;
	public float radius = 0.05f;


    void Start()
    {
    Invoke ("Main", delay);
        
    }

	void Update()
	{

		//if (Input.GetKeyDown("space"))
		//{
		//	Main();
		//}
	}

	void Main(){
		for (int x = 0; x < cubesPerAxis; x++)
		{
			for (int y = 0; y < cubesPerAxis; y++)
			{
				for (int z = 0; z < cubesPerAxis /2f; z++)
				{
					CreateCube(new Vector3(x, y, z));
				}
			}
		}
		//Destroy(gameObject);
    }

	void CreateCube(Vector3 coordinates) {

		GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

		Renderer rd = cube.GetComponentInChildren<Renderer>();
		rd.material = GetComponentInChildren<Renderer>().material;

		cube.transform.localScale = transform.localScale / cubesPerAxis;

		Vector3 firstCube = transform.position - transform.localScale / 2 + cube.transform.localScale / 2;
		cube.transform.position = firstCube + Vector3.Scale(coordinates, cube.transform.localScale);
		cube.transform.localScale = cube.transform.localScale / 4;

		Rigidbody rb = cube.AddComponent<Rigidbody>();
		rb.useGravity = false;
		rb.AddExplosionForce(force, transform.position, radius);

	}

}
