using Imc.Models;
using Imc.ViewModels;
using Microsoft.JSInterop;
using System.Net.NetworkInformation;

namespace Imc.Repositories
{
    public class LocalStorageRepository
    {
        private readonly ILocalStorageService _localStorage;

        public LocalStorageRepository(ILocalStorageService localStorage) => _localStorage = localStorage;
        public List<IMCViewModel> Get()
        {
            var result = new List<IMCViewModel>();
            for (var i = _localStorage.Length; i >= 0; i--)
            {
                var key = (i + 1).ToString();
                var item = _localStorage.GetItem<IMCViewModel>(key);

                if (item is not null)
                    result.Add(item);
            }
            return result;
        }

        public void Create(Person person)
        {
            var key = (_localStorage.Length + 1).ToString();
            var imc = new IMC(person);
            var _imc = new IMCViewModel
            {
                Registered = imc.Registered,
                Value = imc.Value,
                Status = imc.Status
            };

            _localStorage.SetItem(key, _imc);
        }
    }
}
