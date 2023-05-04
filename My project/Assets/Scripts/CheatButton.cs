using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void healthyPlus()
    {
        StatusManager.healthy += 10;
    }

    public void healthyMinus()
    {
        StatusManager.healthy -= 10;
    }

    public void moneyPlus()
    {
        GameManager.money += 10;
    }

    public void moneyMinus()
    {
        GameManager.money -= 10;
    }

    public void EngPlus()
    {
        StatusManager.Engknowledge += 10;
    }

    public void EngMinus()
    {
        StatusManager.Engknowledge -= 10;
    }

    public void innerPlus()
    {
        StatusManager.innerpeace += 10;
    }

    public void innerMinus()
    {
        StatusManager.innerpeace -= 10;
    }

    public void WeekPlus()
    {
        GameManager.Day += 7;
        GameManager.week += 1;
    }

    public void WeekMinus()
    {
        GameManager.Day -= 7;
        GameManager.week -= 1;
    }

}
