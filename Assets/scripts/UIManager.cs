using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	//dropdown menu of the category
	/*
	0 - moradia
	1 - alimentação
	2 - trasnporte
	3 - saúde
	4 - Lazer/informação
	5 - Outros gastos
	*/
	public Dropdown categoria_dm;
	public Dropdown moradia_dm;
	public Dropdown alimentacao_dm;
	public Dropdown transporte_dm;
	public Dropdown saude_dm;
	public Dropdown lazer_dm;
	public Dropdown outros_dm;
	
	public InputField valor_if;
	public InputField obs_if;
	
	public float valor;
	public string categoria;
	public string tipo;
	public string obs = " ";
	
	public GameObject alertOFfillment;
    // Start is called before the first frame update
    void Start()
    {
        
    }
	//pick all the dropdown menus and set to false
	void setAllFalse(){
		moradia_dm.gameObject.SetActive(false);
		alimentacao_dm.gameObject.SetActive(false);
		transporte_dm.gameObject.SetActive(false);
		saude_dm.gameObject.SetActive(false);
		lazer_dm.gameObject.SetActive(false);
		outros_dm.gameObject.SetActive(false);
	}
	//check if all data is inputed
	public bool isDataFilled(){
		bool result = (valor_if.text == "") || (categoria == null)
					  || (tipo == null);
					  
		return !result;
	}
	
    // Update is called once per frame
    void Update()
    {
		alertOFfillment.SetActive(!isDataFilled());
		if(isDataFilled()){
			
			valor = float.Parse(valor_if.text); //update valor info
			categoria = categoria_dm.options[categoria_dm.value].text;//update categoria info
			
			if(obs_if.text != "") obs = obs_if.text; // uptade obs if it have some kind of value
		}
		//depending on the category value it will change with dropdown menu it will show
        switch(categoria_dm.value){
			case 0:
			if(!moradia_dm.gameObject.activeSelf){//check if it is already selected
				setAllFalse();
				moradia_dm.gameObject.SetActive(true);
			}
			tipo = moradia_dm.options[moradia_dm.value].text;//uptade tipo;
				break;
			case 1:
			if(!alimentacao_dm.gameObject.activeSelf){//check if it is already selected
				setAllFalse();
				alimentacao_dm.gameObject.SetActive(true);
				}
			tipo = alimentacao_dm.options[alimentacao_dm.value].text;//uptade tipo;
				break;
			
			case 2:
			if(!transporte_dm.gameObject.activeSelf){//check if it is already selected
				setAllFalse();
				transporte_dm.gameObject.SetActive(true);
				}
			tipo = transporte_dm.options[transporte_dm.value].text;//uptade tipo;
				break;
			
			case 3:
			if(!saude_dm.gameObject.activeSelf){//check if it is already selected
				setAllFalse();
				saude_dm.gameObject.SetActive(true);
				}
			tipo = saude_dm.options[saude_dm.value].text;//uptade tipo;
				break;
			
			case 4:
			if(!lazer_dm.gameObject.activeSelf){//check if it is already selected
				setAllFalse();
				lazer_dm.gameObject.SetActive(true);
				}
			tipo = lazer_dm.options[lazer_dm.value].text;//uptade tipo;
				break;
			
			case 5:
			if(!outros_dm.gameObject.activeSelf){//check if it is already selected
				setAllFalse();
				outros_dm.gameObject.SetActive(true);
				}
			tipo = outros_dm.options[outros_dm.value].text;//uptade tipo;
				break;
			
			 default:
			 if(!outros_dm.gameObject.activeSelf){//check if it is already selected
				setAllFalse();
				outros_dm.gameObject.SetActive(true);
				}
			tipo =  outros_dm.options[outros_dm.value].text;//uptade tipo;
				break;
			 
		}
    }
}
