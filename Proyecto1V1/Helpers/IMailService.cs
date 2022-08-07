namespace Proyecto1V1.Helpers
{
    public interface IMailService
    {
        public void SendEmail(String receptor, String asunto, String contenido);
    }
}
