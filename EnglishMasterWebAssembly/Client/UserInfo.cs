using Blazored.LocalStorage;
using EnglishMasterWebAssembly.Shared.Models;
using System.Net.Http.Json;

namespace EnglishMasterWebAssembly.Client
{
    public sealed class UserInfo
    {
        public static async Task<User?> GetUserInfo(ILocalStorageService localStorage, HttpClient http)
        {
            var userId = await localStorage.GetItemAsync<long>("USER_ID");
            return await http.GetFromJsonAsync<User>($"User?id={userId}");
        }
    }
}