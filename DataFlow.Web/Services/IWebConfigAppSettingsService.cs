namespace DataFlow.Web.Services
{
    interface IWebConfigAppSettingsService
    {
        T GetSetting<T>(string name);
        string GetConnectionString(string name);
    }
}
