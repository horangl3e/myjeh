using UnityEngine;
using System.Collections;

interface IXMLReader
{
    void Start();
    void Update();
}

public class XMLReader : MonoBehaviour, IXMLReader
{

	// Use this for initialization
	public void Start () {
	
	}
	
	// Update is called once per frame
    public void Update()
    {
	
	}
}

public class TestXMLReader : IXMLReader
{
    public void Start() { }
    public void Update() { }
}
