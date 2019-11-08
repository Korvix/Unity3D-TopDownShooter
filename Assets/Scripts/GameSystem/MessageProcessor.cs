//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Reflection;
//using TopDownShooter.GameSystem.Message;
//using UnityEngine;

//namespace TopDownShooter.GameSystem
//{
//    public class MessageProcessor
//    {
//        private Dictionary<string, List<IMessageHandler>> handlersDictionary;
//        private List<IMessageHandler> actualRecipients;
//        private string actualMessageClassName;

//        public MessageProcessor()
//        {
//            handlersDictionary = new Dictionary<string, List<IMessageHandler>>();
//        }

//        public void RegisterHandler(string messageClassName, IMessageHandler messageHandler)
//        {
//            if (!handlersDictionary.ContainsKey(messageClassName))
//            {
//                handlersDictionary.Add(messageClassName, new List<IMessageHandler>());
//            }
//            handlersDictionary[messageClassName].Add(messageHandler);
//        }

//        public void SendMessage(IMessage message)
//        {
//            actualMessageClassName = message.GetType().ToString();
//            if (handlersDictionary.ContainsKey(actualMessageClassName))
//            {
//                actualRecipients = handlersDictionary[actualMessageClassName];
//                //MethodInfo methodInfo = actualRecipients[0].GetType().GetMethod("HandleMessage", new Type[] { message.GetType() });
//                for (int i = 0; i < actualRecipients.Count; i++)
//                {
//                    //methodInfo.Invoke(actualRecipients[i], new object[] { message });
//                    actualRecipients[i].HandleMessage(message);
//                }
//            }
            
//        }
//    }
//}

