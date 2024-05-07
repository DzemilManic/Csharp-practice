namespace CHAT
{
    public interface IDeveloper
    {
        event EmployeeManager.MessageEventHandler MessageReceived;

        bool Equals(object obj);
        void SendMessage(int recipientId, string message);
    }
}