using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardData {
    public string name;
    public int number;
    public string color;
    public string shape;

    public CardData(string _name, int _number, string _color, string _shape){
        name = _name;
        number = _number;
        color = _color;
        shape = _shape;
    }
}