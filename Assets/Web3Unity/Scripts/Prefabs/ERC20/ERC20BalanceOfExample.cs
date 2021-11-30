using System.Collections;
using System.Numerics;
using System.Collections.Generic;
using UnityEngine;

public class ERC20BalanceOfExample : MonoBehaviour
{
    async void Start()
    {
        string chain = "binance";
        string network = "testnet";
        string contract = "0x92Bb9C1BC9CcF82436de0039C54021A3A4b0B154";
        string account = "0x92Bb9C1BC9CcF82436de0039C54021A3A4b0B154";

        BigInteger balanceOf = await ERC20.BalanceOf(chain, network, contract, account);
        print(balanceOf); 
    }
}
