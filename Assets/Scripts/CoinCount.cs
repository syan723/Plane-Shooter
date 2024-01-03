using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinCount : MonoBehaviour
{
    
    public TMP_Text cointext;
    public TMP_Text text;
    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cointext.text = count.ToString();
        text.text = "COINS : "+ cointext.text;
    }
    public void AddCount()
    {
        count++;
    }
}
