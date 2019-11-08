using UnityEngine;

namespace TopDownShooter.GameSystem
{
    public class GameContext : Singleton<GameContext>
    {
        private InputData inputData;
        public InputData InputData { get => inputData; }
        private GameObject player;
        public GameObject Player { get => player; set => player = value; }

        private ObjectPool objectPool;
        public ObjectPool ObjectPool { get => objectPool; }

        //private MessageProcessor messageProcessor;

        //public MessageProcessor MessageProcessor { get => messageProcessor; }

        private void Awake()
        {
            inputData = new InputData();
            objectPool = new ObjectPool();
            gameObject.AddComponent<InputSystem>();
            //messageProcessor = new MessageProcessor();
        }
    }
}
