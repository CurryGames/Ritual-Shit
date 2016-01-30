using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Click : MonoBehaviour {

    public Text goldDisplay;
    public Text gpcDisplay;
    public Text hpDisplay;
    public Slider healthSlider;
    
    public float gold = 0;
    public float dmg = 1;
    public float maxhp = 15;
    public float hp;

    void Start() 
    {
        hp = maxhp;
        healthSlider.maxValue = maxhp;
    }

	// Update is called once per frame
	void Update () {

        goldDisplay.text = "Gold: " + gold;
        gpcDisplay.text = "DMG: " + dmg;
        hpDisplay.text = "Gold Mine\n" + hp + "/" + maxhp;
        healthSlider.value = hp;

        if (hp <= 0)
        {
            gold += 20;
            hp = maxhp;
        }
	}

    public void Clicked()
    {
        hp -= dmg;   
    }
}
