
namespace sprint0.Utility
{
    public class Timer
    {
        private int delay;
        private int count;
        private int previousCount;

       public Timer(int timerDelay)
        {
            delay = timerDelay;
            count = 0;
            previousCount = 0;
        }

        public bool Status()
        {
            return count % delay == 0;
        }

        public bool HasStarted()
        {
            return previousCount > 0;
        }
        
        public void Start()
        {
            count = 1;
        }

        public bool UnconditionalUpdate()
        {
            bool result = Status();
            previousCount = count;
            count++;
            return result;
        }

        public bool ConditionalUpdate()
        {
            bool result = Status();
            previousCount = count;
            if (!result) count++;
            return result;
        }

        public bool ConditionalUpdate(bool condition)
        {
            bool result = Status();
            previousCount = count;
            if (condition) count++;
            return result;
        }

        public void Reset()
        {
            count = 0;
            previousCount = 0;
        }
    }
}
