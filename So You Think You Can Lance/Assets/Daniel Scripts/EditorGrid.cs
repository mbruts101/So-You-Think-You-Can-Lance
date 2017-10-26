using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class EditorGrid : MonoBehaviour {

//Daniel Cole
//1870787
//cole149@mail.chapman.edu
//Level Design II 344
//So You Think You Can Lance
//http://answers.unity3d.com/questions/148812/is-there-a-toggle-for-snap-to-grid.html

	public float cell_size = 1f; //size of cell
	private float x, y, z;

	void Start() {
		x = 0f;
		y = 0f;
		z = 0f;

	}

	void Update () {
		x = Mathf.Round(transform.position.x / cell_size) * cell_size;
		y = Mathf.Round(transform.position.y / cell_size) * cell_size;
		z = transform.position.z;
		transform.position = new Vector3(x, y, z);
	}

}
