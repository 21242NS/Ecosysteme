using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Pong.ViewModels;

public abstract partial class GameObject : ViewModelBase
{
    [ObservableProperty]
    private Point _location;

    protected GameObject(Point location)
    {
        Location = location;
    }
}