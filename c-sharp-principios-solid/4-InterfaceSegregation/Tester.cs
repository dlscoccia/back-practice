namespace InterfaceSegregation
{
    public class Tester : ITesterActivities
    {
        public Tester()
        {
        }
        public void Test() 
        {
            throw new ArgumentException();
        }
    }
}