using UnityEngine;
using System.Collections;
using TopDownShooter.GameSystem.Message;
using TopDownShooter.GameSystem;

public class Franek : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            TestMessage message = new TestMessage();
            message.text = "Siema Maniek. Tu Franek";
            //GameContext.Instance.MessageProcessor.SendMessage(message);
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            MathMessage message = new MathMessage();
            message.a = 5;
            message.b = 7;
            //GameContext.Instance.MessageProcessor.SendMessage(message);
        }
    }
}
