using GPApp.Shared.Binding;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace GPApp.Wrapper.Base
{
    public class NotifyDataErrorInfoBase : ViewModelBase, INotifyDataErrorInfo
    {
        protected Dictionary<string, List<string>> Errors;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        protected NotifyDataErrorInfoBase()
        {
            Errors = new Dictionary<string, List<string>>();
        }

        public IEnumerable GetErrors(string propertyName)
        {
            return propertyName != null && Errors.ContainsKey(propertyName)
                ? Errors[propertyName]
                : Enumerable.Empty<string>();
        }

        public Dictionary<string, string> GetPropriedadeComErro()
        {
            var erros = new Dictionary<string, string>();
            if (HasErrors)
            {
                foreach (var erro in Errors)
                {
                    erros.Add(erro.Key, erro.Value.First());
                }
            }
            return erros;
        }
               
        public bool HasErrors => Errors.Any();


        protected virtual void OnErrorChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }
        protected void LimparErros()
        {
            foreach (var propertyName in Errors.Keys.ToList())
            {
                Errors.Remove(propertyName);
                OnErrorChanged(propertyName);
            }
        }
    }
}