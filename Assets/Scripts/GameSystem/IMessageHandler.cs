using System.Collections;
using System.Collections.Generic;
using TopDownShooter.GameSystem.Message;
using UnityEngine;
namespace TopDownShooter.GameSystem
{
    public interface IMessageHandler<T> where T : IMessage
    {
        void HandleMessage(T message);
    }
}