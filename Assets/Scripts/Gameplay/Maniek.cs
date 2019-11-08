//using UnityEngine;
//using System.Collections;
//using TopDownShooter.GameSystem;
//using TopDownShooter.GameSystem.Message;

//public class Maniek : MonoBehaviour, IMessageHandler
//{
//    private void Start()
//    {
//        GameContext.Instance.MessageProcessor.RegisterHandler(typeof(TestMessage).ToString(), this);
//        GameContext.Instance.MessageProcessor.RegisterHandler(typeof(MathMessage).ToString(), this);
//    }

//    public void HandleMessage(TestMessage message)
//    {
//        Debug.Log(message.text);
//    }

//    public void HandleMessage(MathMessage message)
//    {
//        Debug.Log("Wynik: " + (message.a + message.b));
//    }
//}
