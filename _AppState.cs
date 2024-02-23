using Blazored.LocalStorage;
using Imc.Models;
using Imc.ViewModels;
using System.Reflection;

namespace Imc
{
    public static class _AppState
    {
		private static ILocalStorageService _localStorage;
		public static async Task Initialize(ILocalStorageService localStorage)
		{
			_localStorage = localStorage;

			var data = await _localStorage.GetItemAsync<List<ImcModel>>("data");
			if (data != null)
			{
				_history = data;
				UpdateHistoryViewModel();
			}
		}
		public static List<ImcModel> _history { get; set; } = new();
		public static List<IMCViewModel> History { get; set; } = new();
		public static event EventHandler<EventArgs> OnChanged;

        public static void NotifyChanges(object? sender, EventArgs args)
        {
            OnChanged.Invoke(sender, args);
        }

		private static void UpdateHistoryViewModel()
		{
			History.Clear();
			foreach (var imc in _history)
			{
				var imcViewModel = new IMCViewModel
				{
					Registered = imc.CreatedAt,
					Value = Math.Round((decimal)imc.Imc, 1),
					Status = imc.Status,
					Weight = imc.Weight,
					Height = imc.Height
				};

				History.Add(imcViewModel);
			}
		}
        public static async Task AddImcAsync(ImcModel model)
        {
            _history.Add(model);
            await _localStorage.SetItemAsync("data", _history);
        }
    }
}
