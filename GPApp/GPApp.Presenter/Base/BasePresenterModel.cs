namespace GPApp.Presenter.Base
{
    public class BasePresenterModel<T,I> : BasePresenter<I> where I:IView
    {
        public BasePresenterModel(I view): base(view)
        {
        }

        public T Wrapper { get; set; }
    }
}