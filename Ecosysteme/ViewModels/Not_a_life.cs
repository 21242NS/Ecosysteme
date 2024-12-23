using System.Collections.ObjectModel;
using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Pong.ViewModels;

public abstract partial class Not_a_life : GameObject {
    [ObservableProperty]
    private bool erased =false;
    public Not_a_life( Point location):base(location) {
    }
    public void is_erased(){
        Erased = true;
    }
}