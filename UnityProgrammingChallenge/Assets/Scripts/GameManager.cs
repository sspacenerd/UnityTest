using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class GameManager : MonoBehaviour
{
    public int rows, columns;
    public Transform startPosition, text, container;
    public float space;
    string filePath, jsonString;
    private void Awake()
    {
        filePath = Application.dataPath + "/StreamingAssets/Sample.json";
        jsonString = File.ReadAllText(filePath);
        ListaSample listaSample = JsonUtility.FromJson<ListaSample>(jsonString);
        listaSample.Listar();
    }
    void Start()
    {
        for (int p = 0; p < columns; p++)
        {
            for (int i = 0; i < rows; i++)
            {
                Vector3 startingPos = new Vector3(startPosition.position.x + i * space, startPosition.position.y - p * space / 2, startPosition.position.z);
               Transform instance =  Instantiate(text, startingPos, Quaternion.identity);
                instance.SetParent(container);
            }
        }
    }
}
[System.Serializable]
public class Sample
{
    public string title, id, name, role, nickname;
    public void Return()
    {
        Debug.Log(id + name + role + nickname);
    }
}
[System.Serializable]
public class ListaSample
{
    public Sample sample;
    public List<Sample> Data;
    public List<string> columnHeader;
    public void Listar()
    {
        Debug.Log(sample.title);
        foreach(var sample in columnHeader)
        {
            Debug.Log(sample);
        }
        foreach(var sample in Data)
        {
            sample.Return();
        }
    }
}