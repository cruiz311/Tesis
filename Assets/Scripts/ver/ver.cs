using UnityEngine;
using AustinHarris.JsonRpc;
public class Ver : MonoBehaviour
{
    class Rpc : JsonRpcService
    {
        [JsonRpcMethod]
        public void Say(string message)
        {
            Debug.Log($"you sent {message}");
        }
    }

    private Rpc rpc;
    // Start is called before the first frame update
    void Start()
    {
        rpc = new Rpc();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(rpc.ToString());
    }
}
