using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public float coinCount;
    public Text coinText;

    void Update()
    {
        coinText.text = coinCount.ToString();
    }
}
