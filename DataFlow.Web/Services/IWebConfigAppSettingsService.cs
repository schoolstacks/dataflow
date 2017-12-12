namespace DataFlow.Web.Services
{
    public interface IWebConfigAppSettingsService
    {
        T GetSetting<T>(string name);
        string GetConnectionString(string name);
    }
}
