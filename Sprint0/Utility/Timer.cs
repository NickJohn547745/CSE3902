
namespace sprint0.Utility
{
    public class Timer
    {
        private int delay;
        private int count;

       public Timer(int timerDelay)
        {
            delay = timerDelay;
            count = 0;
        }

        public bool Status()
        {
            return count % delay == 0;
        }

        public void Start()
        {
            count = 1;
        }

        public bool UnconditionalUpdate()
        {
            bool result = Status();
            count++;
            return result;
        }

        public bool ConditionalUpdate()
        {
            bool result = Status();
            if (!result) count++;
            return result;
        }

        public void Reset()
        {
            count = 0;
        }
    }
}
