using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{
	public GameObject fadeOutSideMenuReceita;
	public GameObject fadeOutSideMenuDespesa;
    // Start is called before the first frame update
    void Start()
    {
        
    }
	
    public void goToReceita(){
		fadeOutSideMenuReceita.SetActive(true);
		 
	}
	 public void goToAnalise(){
		 SceneManager.LoadScene("Analise");
	}
	 public void goToDespesa(){
		fadeOutSideMenuDespesa.SetActive(true);
		
	}
	
}
