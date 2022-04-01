using Blazored.SessionStorage;

namespace ProjectsManager.App.Services;

internal class CacheService<T> where T : class
{
    private readonly ISessionStorageService _sessionStorage;
    private readonly string nameOfObject;

    public CacheService(ISessionStorageService sessionStorage)
    {
        (_sessionStorage, nameOfObject) = (sessionStorage, GetNameOfObject());
    }

    public async Task<T> GetAsync()
    {
        return await _sessionStorage.GetItemAsync<T>(nameOfObject);
    }

    public async Task SetAsync(T item)
    {
        await _sessionStorage.SetItemAsync(nameOfObject, item);
    }

    public async Task ClearAsync()
    {
        await _sessionStorage.RemoveItemAsync(nameOfObject);
    }

    private string GetNameOfObject()
    {
        if (!string.IsNullOrWhiteSpace(nameOfObject))
            return nameOfObject;

        var type = typeof(T);

        if (type.IsGenericType && type.GenericTypeArguments is {Length: > 0} genericTypes)
            return $"{genericTypes.First().Name.ToLower()}s-list";

        return type.Name;
    }
}