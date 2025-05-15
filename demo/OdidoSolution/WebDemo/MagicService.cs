namespace WebDemo
{
    public class MagicService : IMagicService
    {
        private int _counter = 0;
        public int GetMagicNumber()
        {
            return ++_counter;
        }
    }
}
