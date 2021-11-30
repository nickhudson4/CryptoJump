using System.Collections;
using System.Numerics;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{
    // public string account = "0x0a1697bc7920f9408afa672dd4eec2ccca3ffff4";
    // // Start is called before the first frame update
    async void Start()
    {
    //     string chain = "xdai";
    //     string network = "mainnet";
    //     string contract = "0x92Bb9C1BC9CcF82436de0039C54021A3A4b0B154";

    //     BigInteger balanceOf = await ERC20.BalanceOf(chain, network, contract, account);
    //     print(balanceOf);   





            // string chain = "binance";
            // string network = "testnet"; // mainnet ropsten kovan rinkeby goerli
            // string account = "0x92Bb9C1BC9CcF82436de0039C54021A3A4b0B154";

            // string balance = await EVM.BalanceOf(chain, network, account);
            // print(balance);


        string chain = "binance";
        string network = "mainnet";
        string contract = "0xe9e7cea3dedca5984780bafc599bd69add087d56";
        string account = "0x92Bb9C1BC9CcF82436de0039C54021A3A4b0B154";

        BigInteger balanceOf = await ERC20.BalanceOf(chain, network, contract, account);
        print(balanceOf); 
    }

    public async void OnClickSend()
    {
        string to = "0xd589CCEC4066Af4d2ffb0fcAFcF7d1d9C602F874";
        // amount in wei to send
        string value = "216689648027920";
        // gas limit OPTIONAL
        string gas = "";
        // connects to user's browser wallet (metamask) to send a transaction
        try {
            string response = await Web3GL.SendTransaction(to, value, gas);
            Debug.Log(response);
        } catch (System.Exception e) {
            Debug.LogException(e, this);
        }
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    // account to send to
    

}
