using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using System.IO;

public class CSVWriter : MonoBehaviour
{
	string filename = "";

	public UIManager ui_manager;
	public Menu menu_;
	public GameObject analiseElement_prefab;//model that we use to build the list in the Analise scene
	public GameObject slide;//it serve as a reference to instantiate the analiselement
	
	
	[System.Serializable]
	public class Despesa
	{
		public string categoria;
		public string data;
		public string tipo;
		public string obs;
		public float valor;
		
		public Despesa(float valorp,string datap, string categoriap, string tipop, string obsp){
			valor = valorp;
			data = datap;
			categoria = categoriap;
			tipo = tipop;
			obs = obsp;
			
		}
	}
	public List<Despesa> despesas = new List<Despesa>();
    // Start is called before the first frame update
    void Start()
    {
        filename = Application.persistentDataPath +"confidencialFile.csv";
		
		//if it is analise it will populate the list of despesas with all data
		if(SceneManager.GetActiveScene().name == "Analise"){
			BuildAnaliseElements();// it will fill the list of despesas
		}
    }
	//Write all lines of Data to Excell
	public void WriteCSV(){
		//Check if file is empty
		bool fileExist = File.Exists(filename) ? true : false;
		
			if(!fileExist){//file is empty
				Debug.Log("No data in File, starting new one...");
				
				if(ui_manager.isDataFilled()){//check if data was filled
					TextWriter tw = new StreamWriter(filename,false);
					tw.WriteLine("Valor; Data; Categoria; Tipo; Obs");
					tw.Close();
					
					tw = new StreamWriter(filename,true);
					tw.WriteLine(ui_manager.valor +";"+System.DateTime.Now.ToString("dd/MM/yyyy HH:mm")+";"+ui_manager.categoria+";"+ui_manager.tipo+";"+ui_manager.obs);//Write each line of Excell
					
					Debug.Log("All data saved");
					 menu_.goToDespesa();
					tw.Close();
				}
				else Debug.Log("No data to be saved");
			}
			else{//file is not empty
			
				if(ui_manager.isDataFilled()){//check if data was filled
					TextWriter tw = new StreamWriter(filename,true);
					
					if(ui_manager.isDataFilled())//check if all data is there
					{
						
						tw.WriteLine(ui_manager.valor +";"+System.DateTime.Now.ToString("dd/MM/yyyy HH:mm")+";"+ui_manager.categoria+";"+ui_manager.tipo+";"+ui_manager.obs);//Write each line of Excell
					}
					Debug.Log("All data saved");
					 menu_.goToDespesa();
					tw.Close();
				}
				else Debug.Log("No data to be saved");
			}
		
	}

	//Read all lines of file from excell
	public void ReadCSV(){
		StreamReader strReader = new StreamReader(filename);
		bool endOfFile = false;
		if(despesas.Count <= 0){//it means that the list has not been created yet
			while(!endOfFile){
					string data_string = strReader.ReadLine();
					if(data_string == null){
						endOfFile = true;
						break;
					}
					string[] data_values = data_string.Split(';');
					Debug.Log(data_values[0]+" "+data_values[1]+" "+data_values[2]+" "+data_values[3]);
					
					if(data_values[0] != "Valor"){// it will be the first line
						//Create a despesa object from each line of the excell and add it to the list
						Despesa d = new Despesa(float.Parse(data_values[0]),data_values[1].ToString(),data_values[2].ToString(),data_values[3].ToString(),data_values[4].ToString()); // create a object Despesa to be added in the list
						despesas.Add(d);
						 //the variables of AnaliseElement class and apply to the prefab
						 
					}
			}
		}
		strReader.Close();
	}
	public void BuildAnaliseElements(){
		ReadCSV();
		int c = 0;//control the elements numbers
		foreach(Despesa d in despesas){
			GameObject o = Instantiate(analiseElement_prefab);
			o.transform.parent = slide.transform;		
			RectTransform rt = o.GetComponent<RectTransform>();//we use to adjust the position of the element
			rt.anchoredPosition  = new Vector3(-4.07f,-180 - (+120*c),0); // it will list them with a space of 120
			rt.localScale  = new Vector3(1,1,1);
			o.GetComponent<AnaliseElement>().AnaliseElementFill(d.valor,d.data,d.categoria,d.tipo,d.obs);// define
			c++;
		}
	}
	public void RemoveFromList(float valorp,string datap,string categoriap,string tipop,string obsp){
		//find the right object that need to match will all elements and remove it from the list
		foreach(Despesa d in despesas){
			if(d.valor == valorp &&d.data == datap && d.categoria == categoriap && d.tipo == tipop && d.obs == obsp){
				despesas.Remove(d);
				break;
			}
		}
		// and then i will rewrite all the excell file again withou this element
		TextWriter tw = new StreamWriter(filename,false);
		tw.WriteLine("Valor; Data; Categoria; Tipo; Obs");
		tw.Close();
		
		tw = new StreamWriter(filename,true);
		foreach(Despesa d in despesas){
			tw.WriteLine(d.valor +";"+d.data+";"+d.categoria+";"+d.tipo+";"+d.obs);//Write each line of Excell
			Debug.Log("All data saved");
		}
		tw.Close();
		  SceneManager.LoadScene("Analise");//reload scene 
	}
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
			WriteCSV();
			//ReadCSV();
		}
    }
}
