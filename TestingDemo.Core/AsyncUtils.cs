using System.Threading.Tasks;

namespace TestingDemo.Core;

public static class AsyncUtils
{
    public static async Task<int> PobierzLiczbePoCzasieAsync(int liczba, int ms)
    {
        await Task.Delay(ms);
        return liczba;
    }
} 