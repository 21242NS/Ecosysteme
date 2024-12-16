using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Pong.ViewModels;

// représente un objet affichable sur l'interface
public abstract partial class GameObject : ViewModelBase
{
    [ObservableProperty]
    private Point _location;
    [ObservableProperty]
    private float hit_box;

    protected GameObject(Point location)
    {
        Location = location;
    }
    
}