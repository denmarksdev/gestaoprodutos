using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;

namespace GPApp.Wrapper.Base
{
    public class ChangeTrackingCollection<T> : ObservableCollection<T>, IValdatableTrackingObject where T :
        class, IValdatableTrackingObject
    {
        private IList<T> _originalCollection;

        private ObservableCollection<T> _addedItems;
        private ObservableCollection<T> _removedItems;
        private ObservableCollection<T> _modifiedItems;

        public ReadOnlyObservableCollection<T> ModifiedItems { get; set; }
        public ReadOnlyObservableCollection<T> RemovedItems { get; set; }
        public ReadOnlyObservableCollection<T> AddedItemns { get; private set; }

        public ChangeTrackingCollection(IEnumerable<T> items) : base(items)
        {
            _originalCollection = this.ToList();

            AttachitemPropertyChangedHandler(_originalCollection);

            _addedItems = new ObservableCollection<T>();
            _removedItems = new ObservableCollection<T>();
            _modifiedItems = new ObservableCollection<T>();

            AddedItemns = new ReadOnlyObservableCollection<T>(_addedItems);
            RemovedItems = new ReadOnlyObservableCollection<T>(_removedItems);
            ModifiedItems = new ReadOnlyObservableCollection<T>(_modifiedItems);

        }

        private void AttachitemPropertyChangedHandler(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                item.PropertyChanged += ItemPropertyChanged;
            }
        }

        private void DetachItemPropertyChangedHandler(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                item.PropertyChanged -= ItemPropertyChanged;
            }
        }

        private void ItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(IsValid))
            {
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(IsValid)));
            }
            else
            {
                var item = (T)sender;

                if (_addedItems.Contains(item)) return;

                if (item.IsChanged)
                {
                    if (!ModifiedItems.Contains(item))
                    {
                        _modifiedItems.Add(item);
                    }

                }
                else
                {
                    if (_modifiedItems.Contains(item))
                    {
                        _modifiedItems.Remove(item);
                    }

                }

                OnPropertyChanged(new PropertyChangedEventArgs(nameof(IsChanged)));
            }
        }

        public void AcceptChanges()
        {
            _addedItems.Clear();
            _modifiedItems.Clear();
            _removedItems.Clear();

            foreach (var item in this)
            {
                item.AcceptChanges();
            }

            _originalCollection = this.ToList();
            OnPropertyChanged(new PropertyChangedEventArgs(nameof(IsChanged)));
        }

        public bool IsChanged =>
            AddedItemns.Count > 0 || RemovedItems.Count > 0 || ModifiedItems.Count > 0;

        public void RejectChanges()
        {
            foreach (var addedItem in _addedItems.ToList())
            {
                Remove(addedItem);
            }

            foreach (var removedItem in _removedItems.ToList())
            {
                Add(removedItem);
            }

            foreach (var modfiedItem in _modifiedItems.ToList())
            {
                modfiedItem.RejectChanges();
            }

            OnPropertyChanged(new PropertyChangedEventArgs(nameof(IsChanged)));

        }

        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            var added = this.Where(current => _originalCollection.All(orig => orig != current));
            var removed = _originalCollection.Where(orig => this.All(current => current != orig));

            var modified = this.Except(added).Except(removed).Where(item => item.IsChanged).ToList();

            AttachitemPropertyChangedHandler(added);
            DetachItemPropertyChangedHandler(removed);

            UpdateObservableCollection(_addedItems, added);
            UpdateObservableCollection(_removedItems, removed);
            UpdateObservableCollection(_modifiedItems, modified);

            base.OnCollectionChanged(e);
            OnPropertyChanged(new PropertyChangedEventArgs(nameof(IsChanged)));
            OnPropertyChanged(new PropertyChangedEventArgs(nameof(IsValid)));
        }

        private void UpdateObservableCollection(ObservableCollection<T> collecao, IEnumerable<T> items)
        {
            collecao.Clear();

            foreach (var item in items)
            {
                collecao.Add(item);
            }
        }

        public bool IsValid => this.All(t => t.IsValid);
    }
}