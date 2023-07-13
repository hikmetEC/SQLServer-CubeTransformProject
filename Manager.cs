using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Globalization;
public class Manager : MonoBehaviour
{
    public GameObject cube;
    private string phpPath = "http://localhost/SQL-CubeProject"; //path to php files

    private void Start() // To initialize the Cube at it's saved position
    {
        StartCoroutine(LoadPositionRoutine());
    }

    //Save Position Information
    public void SaveData() // To Start the Coroutine by "Save" button
    {
        StartCoroutine(SavePositonRoutine());
    }

    public void LoadData()// To Start the Coroutine by "Load" button
    {
        StartCoroutine(LoadPositionRoutine());
    }

    IEnumerator SavePositonRoutine() //Coroutine to save Cube's position to MySQL server
    {
        // Converting Cube's name and position data to a dictionary(necessary to send the data in string dictionary or bytes[] format)
        Dictionary<string, string> cubePos = new Dictionary<string, string>();
        cubePos.Add("objectType", cube.name);
        cubePos.Add("xPos", cube.transform.position.x.ToString());
        cubePos.Add("yPos", cube.transform.position.y.ToString());
        cubePos.Add("zPos", cube.transform.position.z.ToString());
         //dictionary end
        
        var www = UnityWebRequest.Post(phpPath + "/saveData.php", cubePos); // Web request template for sending Cube's data
        yield return www.SendWebRequest(); // For IEnumator functionalty
        if (www.result == UnityWebRequest.Result.Success) //if request is completed show the result message
        {
            Debug.Log("Saved..");
            Debug.Log(www.result);
        }
        else
            Debug.Log("Can't Save!!!");
    }
    //Save Position Information

    //Load Position Information
    
    IEnumerator LoadPositionRoutine()
    {
        
        var www = UnityWebRequest.Get(phpPath + "/loadData.php"); // Web request template for getting Cube's data
        yield return www.SendWebRequest(); // For IEnumator functionalty
        if (www.result == UnityWebRequest.Result.Success) //if request is completed
        {
            Debug.Log("Result: " + www.downloadHandler.text); //to see the position data in console
            

            // string parsing to float
            string[] temp = www.downloadHandler.text.Split("\t"); 
            float[] resultsInFloat = new float[temp.Length];
            for (int i = 0; i<temp.Length;i++)
            {
                resultsInFloat[i] = float.Parse(temp[i], CultureInfo.InvariantCulture.NumberFormat); //culture info is for getting the used float sytnax
            }
            // string parsing to float

            //applying Cube's position data
            cube.transform.position = new Vector3(resultsInFloat[0], resultsInFloat[1], resultsInFloat[2]); 
        }
        else
            Debug.Log("Can't load: "+ www.error);
    }
    
    //Load Position Information
}
