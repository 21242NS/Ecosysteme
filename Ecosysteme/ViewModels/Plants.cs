using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Pong.ViewModels;

public abstract partial class Plants : Form_of_life {
    [ObservableProperty]
    private float range_of_food;

    public Plants(Point location) : base(location) {

    }

}