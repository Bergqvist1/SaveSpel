using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class SaveGame : MonoBehaviour
{

    private string path = "spara.txt";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("v"))
        {
            Debug.Log("Försök 1");
            SparaSpel();
        }

        if(Input.GetKeyDown("g"))
        {
            LaddaSpel();
        }
    }

    void SparaSpel()
    {
        Debug.Log("Du har tryckt på v  för att spara");
        Vector3 position = transform.position;

        StreamWriter sw = new StreamWriter(path);
        sw.WriteLine(position.x);
        sw.WriteLine(position.y);
        sw.WriteLine(position.z);
        sw.Close();
    }

    void LaddaSpel()
    {
        StreamReader sr = new StreamReader(path);
        string output = sr.ReadLine();
        string[] outputArray = output.Split(' ');
        Vector3 position = Vector3.zero;

        try
        {
            position = new Vector3(float.Parse(outputArray[0]), float.Parse(outputArray[1]), float.Parse(outputArray[2]));

        }

        catch
        {
            Debug.Log("Misslyckades med Parse");
        }

        sr.Close();
        transform.position = position;

    }
}
