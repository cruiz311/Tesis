using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AustinHarris.JsonRpc;
public class ver : MonoBehaviour
{
    class Rpc : JsonRpcService
    {
        [JsonRpcMethod]
        public void Say(string message)
        {
            Debug.Log($"you sent {message}");
        }
    }
    Rpc rpc;
    // Start is called before the first frame update
    void Start()
    {
        rpc = new Rpc();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
