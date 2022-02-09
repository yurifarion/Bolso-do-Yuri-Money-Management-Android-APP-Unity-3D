using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

using UnityEngine;

public class AnaliseElement : MonoBehaviour
{
	
	private CSVWriter csvw;
	//this class control the information and display of the Elements in the Analise screen
	public float valor;
	public string data;
	public string categoria;
	public string tipo;
	public string obs;
	
	public Text valor_txt;
	public Text data_txt;
	public Text categoria_txt;
	public Text tipo_txt;
	public Text obs_txt;
	
	void Start(){
		csvw = GameObject.FindGameObjectWithTag("CSVWriter").GetComponent<CSVWriter>();
	}
	public void DeleteElement(){
		csvw.RemoveFromList(valor,data,categoria,tipo,obs);
	}
	public void AnaliseElementFill(float valorp,string datap,string categoriap,string tipop,string obsp){
		valor = valorp;
		data = datap;
		categoria = categoriap;
		tipo = tipop;
		obs = obsp;
		
		//Fill the UI
		valor_txt.text = valor+"";
		data_txt.text = data;
		categoria_txt.text = categoria;
		tipo_txt.text = tipo;
		obs_txt.text = obs;
	}

}
