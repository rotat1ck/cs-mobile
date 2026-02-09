using System;
using System.Collections.Generic;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;

namespace news_app.ViewModels {
    [ObservableObject]
    public abstract partial class ViewModel {
        public INavigate Navigation { get; init; }

        public ViewModel(INavigate navigate) => Navigation = navigate;
    }
}
