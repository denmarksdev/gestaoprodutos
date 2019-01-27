using System.ComponentModel;

namespace GPApp.Wrapper.Base
{
    public interface IValdatableTrackingObject : IRevertibleChangeTracking, INotifyPropertyChanged
    {
        bool IsValid { get; }
    }
}
