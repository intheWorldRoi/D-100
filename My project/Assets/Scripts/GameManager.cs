using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static int Day = 0;

    //stat
    public static int dep = 1;
    public static int str = 1;
    public static int lon = 1;
    public static int anx = 1;
    public static int wil = 1;
    public static int hap = 1;

    //UI
    public GameObject depression;
    public GameObject stress;
    public GameObject lonely;
    public GameObject anxiety;
    public GameObject willingness;
    public GameObject happy;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        depression.GetComponent<TextMeshProUGUI>().text = dep.ToString();
        stress.GetComponent<TextMeshProUGUI>().text = str.ToString();
        lonely.GetComponent<TextMeshProUGUI>().text = lon.ToString();
        anxiety.GetComponent<TextMeshProUGUI>().text = anx.ToString();
        willingness.GetComponent<TextMeshProUGUI>().text = wil.ToString();
        happy.GetComponent<TextMeshProUGUI>().text = hap.ToString();
    }
}
