using GPApp.Shared.Binding;

namespace GPApp.Presenter.Base
{
    public class BasePresenter<I> : ViewModelBase where I : IView
    {
        public  I View { get; private set; }

        public BasePresenter(I view)
        {
            View = view;
        }

        public M GetUI<M>()
        {
            object item = View;
            return (M)item;
        } 
    }
}