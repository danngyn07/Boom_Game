using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCharacter : MonoBehaviour
{
    public ThietLap _thietlap;

    public void Start()
    {
        _thietlap = FindObjectOfType<ThietLap>();
    }
    public void Default()
    {
        _thietlap.health = 25;
        _thietlap.speed = 2f;
        _thietlap.dam = 9;
    }
    public void Option1()
    {

        _thietlap.health = 28;
        _thietlap.speed = 1.5f;
        _thietlap.dam = 12;
    }
    public void Option2()
    {

        _thietlap.health = 30;
        _thietlap.speed = 2f;
        _thietlap.dam = 8;
    }

    public void Option3()
    {

        _thietlap.health = 22;
        _thietlap.speed = 2.5f;
        _thietlap.dam = 6;
    }




    // Update is called once per frame
}
