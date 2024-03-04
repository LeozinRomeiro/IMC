using Blazored.LocalStorage;
using Imc.Models;
using Imc.ViewModels;
using System.Reflection;

namespace Imc
{
    public static class AppState
    {
        public static List<ImcModel> History { get; set; } = new();
        public static List<IMCViewModel> ViewHistory { get; set; } = new();
        public static event EventHandler<EventArgs>? OnChanged;

        public static void NotifyChanges(object? sender, EventArgs args)
        {
            OnChanged?.Invoke(sender, args);
            UpdateView();
        }

        public static async Task UpdateHistoryAsync(ILocalStorageService localStorage)
        {
            var data = await localStorage.GetItemAsync<List<ImcModel>?>("data");
            if (data is not null)
                History = data;
            UpdateView();
        }

        public static void UpdateView()
        {
            ViewHistory.Clear();
            foreach (var imc in History)
            {
                var imcViewModel = new IMCViewModel
                {
                    Registered = imc.CreatedAt,
                    Value = Math.Round((decimal)imc.Imc, 1),
                    Status = imc.Status,
                    Weight = imc.Weight,
                    Height = imc.Height
                };

                ViewHistory.Add(imcViewModel);
            }
        }
    }
}
