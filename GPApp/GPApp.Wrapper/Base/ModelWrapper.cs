using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;

namespace GPApp.Wrapper.Base
{
    public class ModelWrapper<T> : NotifyDataErrorInfoBase, IValdatableTrackingObject, IValidatableObject
    {
        private List<IValdatableTrackingObject> _trackingObjects;

        private Dictionary<string, object> _originalValues;

        public ModelWrapper(T model)
        {
            if (model == null) throw new ArgumentNullException(nameof(Model));

            Model = model;

            _originalValues = new Dictionary<string, object>();
            _trackingObjects = new List<IValdatableTrackingObject>();
            InitializeComplexProperties(Model);
            InitializeCollentionProperties(Model);
            ValidacaoInterna();
        }

        public T Model { get; }


        public bool IsValid => !HasErrors && _trackingObjects.All(t => t.IsValid);

        public bool IsChanged
            => (_originalValues.Count > 0 || _trackingObjects.Any(t => t.IsChanged));

        public void RejectChanges()
        {
            foreach (var originalValueEntry in _originalValues)
            {
                typeof(T).GetProperty(originalValueEntry.Key)
                    .SetValue(Model, originalValueEntry.Value, null);
            }

            _originalValues.Clear();

            foreach (var trackingObject in _trackingObjects)
            {
                trackingObject.RejectChanges();
            }

            ValidacaoInterna();
            OnPropertyChanged("");
        }

        public void AcceptChanges()
        {
            _originalValues.Clear();
            foreach (var trackingObject in _trackingObjects)
            {
                trackingObject.AcceptChanges();
            }
            OnPropertyChanged("");
        }

        protected TValue GetValue<TValue>([CallerMemberName] string propertyName = null)
        {
            var propertyInfo = Model.GetType().GetProperty(propertyName);
            return (TValue)propertyInfo.GetValue(Model, null);
        }

        protected TValue GetOriginalValue<TValue>(string propertyName)
        {
            return _originalValues.ContainsKey(propertyName)
                ? (TValue)_originalValues[propertyName]
                : (TValue)GetValue<TValue>(propertyName);

        }

        protected bool GetIsChanged(string propertyname)
        {
            return _originalValues.ContainsKey(propertyname);
        }

        protected void SetValue<TValue>(TValue newValue, [CallerMemberName] string propertyName = null)
        {
            var propertyInfo = Model.GetType().GetProperty(propertyName);
            var currentValue = propertyInfo.GetValue(Model, null);
            if (!Equals(currentValue, newValue))
            {
                UpdateOriginalValue(currentValue, newValue, propertyName);
                propertyInfo.SetValue(Model, newValue, null);
                ValidacaoInterna();
                OnPropertyChanged(propertyName);
                OnPropertyChanged(propertyName + "IsChanged");
            }
        }

        private static bool CompararValores<TValue>(TValue newValue, object currentValue)
        {
            if (newValue != null && currentValue != null && currentValue.GetType() == typeof(DateTime))
            {
                return !DatasIguais(newValue, currentValue);
            }
            return !Equals(currentValue, newValue);
        }

        private static bool DatasIguais<TValue>(TValue newValue, object currentValue)
        {
            var dataNova = Convert.ToDateTime(newValue);
            var dataAtual = Convert.ToDateTime(currentValue);

            return (dataNova.Year == dataAtual.Year) &&
                     (dataNova.Month == dataAtual.Month) &&
                     (dataNova.Day == dataAtual.Day);
        }

        private void ValidacaoInterna()
        {
            LimparErros();
            var results = new List<ValidationResult>();
            Validator.TryValidateObject(this, CriaContexto(), results, validateAllProperties: true);
            SetErros(results);
            OnPropertyChanged(nameof(IsValid));
        }

        private ValidationContext CriaContexto()
        {
            return new ValidationContext(this, null, null);
        }

        private void SetErros(IEnumerable<ValidationResult> results)
        {
            if (results.Any())
            {

                var propertyNames = results.SelectMany(r => r.MemberNames).Distinct().ToList();

                foreach (var propertyName in propertyNames)
                {
                    Errors[propertyName] = results
                        .Where(r => r.MemberNames.Contains(propertyName))
                        .Select(r => r.ErrorMessage)
                        .Distinct()
                        .ToList();

                    OnErrorChanged(propertyName);
                }
            }
        }

        protected void UpdateOriginalValue(object currentValue, object newValue, string propertyName)
        {
            if (!_originalValues.ContainsKey(propertyName))
            {
                _originalValues.Add(propertyName, currentValue);
                OnPropertyChanged(nameof(IsChanged));
            }
            else
            {
                if (Equals(_originalValues[propertyName], newValue))
                {
                    _originalValues.Remove(propertyName);
                    OnPropertyChanged(nameof(IsChanged));
                }
            }

        }

        protected void RegisterCollection<TWrapper, TModel>(
          ChangeTrackingCollection<TWrapper> wrapperCollection,
          List<TModel> modelCollection) where TWrapper : ModelWrapper<TModel>
        {
            wrapperCollection.CollectionChanged += (s, e) =>
            {
                modelCollection.Clear();
                modelCollection.AddRange(wrapperCollection.Select(w => w.Model));
                ValidacaoInterna();
            };

            RegisterTrackingObject(wrapperCollection);
        }

        protected virtual void InitializeCollentionProperties(T model)
        {
        }

        protected virtual void InitializeComplexProperties(T model)
        {
        }

        protected void RegisterComplex<TModel>(ModelWrapper<TModel> wrapper)
        {
            RegisterTrackingObject(wrapper);
        }

        private void RegisterTrackingObject(IValdatableTrackingObject trackingObject)
        {
            if (_trackingObjects.Contains(trackingObject)) return;

            _trackingObjects.Add(trackingObject);
            trackingObject.PropertyChanged += Wrapper_PropertyChanged;
        }

        private void Wrapper_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(IsChanged))
            {
                OnPropertyChanged(nameof(IsChanged));
            }
            else if (e.PropertyName == nameof(IsValid))
            {
                OnPropertyChanged(nameof(IsValid));
            }
        }

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}