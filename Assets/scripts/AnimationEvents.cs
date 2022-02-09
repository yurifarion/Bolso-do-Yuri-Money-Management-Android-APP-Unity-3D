using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    public void ChangeSceneDespesa(){
		Application.LoadLevel("MainDespesa");
	}
	public void ChangeSceneReceita(){
		Application.LoadLevel("MainReceita");
	}
}
