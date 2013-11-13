﻿using UnityEngine;
using System.Collections;
using InControl;

public class UpdateInputManager : MonoBehaviour {

	void Start()
	{
		InputManager.Setup();
	}
	
	void Update()
	{
		InputManager.Update();
	}

}
