using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebGLSendContractExample : MonoBehaviour
{
    async public void OnSendContract()
    {
        // smart contract method to call
        string method = "";
        // abi in json format
        string abi = "[ { \"inputs\": [ { \"internalType\": \"uint8\", \"name\": \"_myArg\", \"type\": \"uint8\" } ], \"name\": \"addTotal\", \"outputs\": [], \"stateMutability\": \"nonpayable\", \"type\": \"function\" }, { \"inputs\": [], \"name\": \"myTotal\", \"outputs\": [ { \"internalType\": \"uint256\", \"name\": \"\", \"type\": \"uint256\" } ], \"stateMutability\": \"view\", \"type\": \"function\" } ]";
        // address of contract
        string contract = "0xe9e7cea3dedca5984780bafc599bd69add087d56";
        // array of arguments for contract
        string args = "[\"1\"]";
        // value in wei
        string value = "216689648027920";
        // gas limit OPTIONAL
        string gas = "";
        // connects to user's browser wallet (metamask) to update contract state
        try {
            string response = await Web3GL.SendContract(method, abi, contract, args, value, gas);
            Debug.Log(response);
        } catch (Exception e) {
            Debug.LogException(e, this);
        }
    }
}