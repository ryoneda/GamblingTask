using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour {

    int number;
    string color;
    string shape;
    string name;
    private Image image;
    private Sprite sprite;



    public void Load(CardData _cardData){
        name = _cardData.name;
        number = _cardData.number;
        color = _cardData.color;
        shape = _cardData.shape;

        sprite = Resources.Load < Sprite > (color);
        image = this.GetComponent<Image>();
        image.sprite = sprite;
    }
}
