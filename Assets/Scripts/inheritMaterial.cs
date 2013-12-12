using UnityEngine;
using System.Collections;

public class inheritMaterial : MonoBehaviour {

	Transform parentTransform;

	void Start () {
		parentTransform = transform.parent;
	}

	// Update is called once per frame
	void Update () {
		transform.renderer.material = parentTransform.renderer.material;
	}
}
