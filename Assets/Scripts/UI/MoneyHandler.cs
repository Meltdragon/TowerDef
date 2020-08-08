using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyHandler : Singleton<MoneyHandler>
{
    [SerializeField] private Text moneyText;

    [SerializeField] private int startMoney = 20;

    private int money;

    public static int Money { get => Instance.money;}

    private void Start()
    {
        money = startMoney;
        ShowMoney();
    }

    public static void AddMoney(int amount)
    {
        Instance.money += amount;
        Instance.ShowMoney();
    }

    public static void RemoveMoney(int amount)
    {
        Instance.money -= amount;
        Instance.ShowMoney();
    }

    private void ShowMoney()
    {
        moneyText.text = money.ToString();
    }
}
