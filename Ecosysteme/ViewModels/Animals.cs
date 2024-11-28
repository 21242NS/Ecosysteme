using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Pong.ViewModels;

public abstract partial class Animals : Form_of_life {
    [ObservableProperty]
    private float mouvement_range;
    [ObservableProperty]
    private float vision_range;

    public Animals(Point location) : base(location) {

    }

    
}