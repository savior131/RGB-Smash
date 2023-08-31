using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RGBBarsPresenter : MonoBehaviour
{
    [SerializeField] ColorCollector colorCollector;
    [SerializeField] Slider [] RGBBars;

    private void Start()
    {
        colorCollector.onRedCollect += UpdateRedSlider;
        colorCollector.onGreenCollect += UpdateGreenSlider;
        colorCollector .onBlueCollect += UpdateBlueSlider;
    }

    void UpdateRedSlider()
    {
        RGBBars[0].value = colorCollector.getRedCapacitis() / colorCollector.getMaxCapacitis();
    }
    void UpdateGreenSlider() 
    {
        RGBBars[1].value = colorCollector.getGreenCapacitis() / colorCollector.getMaxCapacitis();
    }
    void UpdateBlueSlider()
    {
        RGBBars[2].value = colorCollector.getBlueCapacitis() / colorCollector.getMaxCapacitis();
    }

}
