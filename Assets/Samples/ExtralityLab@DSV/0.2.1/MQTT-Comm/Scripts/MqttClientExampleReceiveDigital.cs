using System.Collections.Generic;
using uPLibrary.Networking.M2Mqtt.Messages;
using M2MqttUnity;
using UnityEngine;

namespace ExtralityLab
{
    public class MqttClientExampleReceiveDigital : M2MqttUnityClient
    {
       
       public GameManager gameManager;
        [Header("Topics Config")]
        public string subscribedTopic = "myUnityApp/digital";
        public bool autoSubscribe = false;

         [Header("UI Config")]
        public GameObject targetCanvas;
        public bool currentState = false;

        private List<string> eventMessages = new List<string>();

        protected override void Start()
        {
            base.Start();

            // Add here your custom Start() below:

        }

        protected override void Update()
        {
            base.Update();

            if (eventMessages.Count > 0)
            {
                foreach (string msg in eventMessages)
                {
                    ProcessMessage(msg);
                }
                eventMessages.Clear();
            }
        }

        protected override void OnConnecting()
        {
            base.OnConnecting();
            Debug.Log($"MQTT: subscription {subscribedTopic} connecting to broker on " + brokerAddress + ":" + brokerPort.ToString() + "...\n");
        }

        protected override void OnConnected()
        {
             base.OnConnected(); // Uncommenting this will autosubscribe to topics
            Debug.Log($"MQTT: subscription {subscribedTopic} connected!");
            if (autoSubscribe)
                SubscribeTopics();
        }

        protected override void SubscribeTopics()
        {
            client.Subscribe(new string[] { subscribedTopic }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
        }

        protected override void UnsubscribeTopics()
        {
            client.Unsubscribe(new string[] { subscribedTopic });
        }

        private void OnDestroy()
        {
            Disconnect();
        }

        protected override void DecodeMessage(string topic, byte[] message)
        {
            string msg = System.Text.Encoding.UTF8.GetString(message);
            // Debug.Log("Received: " + msg);
            eventMessages.Add(msg);
        }

        ////// CALLBACKS from Buttons

        public void SubscribeToMqttTopic()
        {
            SubscribeTopics();
        }

        public void UnsubscribeFromTopic()
        {
            UnsubscribeTopics();
        }

       private void ProcessMessage(string msg)
{
    Debug.Log($"MQTT Subscription {subscribedTopic} received: " + msg);

    // Handle new ESP32 messages
    if (msg == "SHORT")
    {
        // Short press → toggle canvas
        targetCanvas.SetActive(!targetCanvas.activeSelf);
        Debug.Log("Short press — Canvas toggled: " + targetCanvas.activeSelf);
    }
    else if (msg == "LONG")
    {
        // Long press → restart game
        if (gameManager != null)
        {
            gameManager.RestartGame();
            Debug.Log("Long press — Game restarted");
        }
        else
        {
            Debug.LogWarning("GameManager not assigned!");
        }
    }
    else
    {
        Debug.LogWarning($"Unrecognized MQTT message: {msg}");
    }
}

        
    }
}
