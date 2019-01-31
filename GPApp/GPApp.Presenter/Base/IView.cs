using System;

namespace GPApp.Presenter.Base
{
    public interface IView
    {
        Action LoadAction { get; set; }
    }
}
