using UnityEngine;
using System.Collections;

interface IItem
{
    void Start();
    void Update();
}

public class Item : MonoBehaviour, IItem
{
    public void Start() { }
    public void Update() { }
}

public class TestItem : IItem
{
    public void Start() { }
    public void Update() { }
}
