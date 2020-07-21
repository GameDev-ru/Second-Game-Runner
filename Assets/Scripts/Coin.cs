using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public Text coinCount;
    public int _coincount;

    private void Start()
    {
        _coincount = 0;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            _coincount++;
        }

    }
    void Update()
    {
        coinCount.text = $"{_coincount}";
    }
}
