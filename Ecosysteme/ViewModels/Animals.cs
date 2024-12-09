using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Pong.ViewModels;

public abstract partial class Animals : Form_of_life {
    [ObservableProperty]
    private float vision_range;
    [ObservableProperty]
    private int attack_point;
    [ObservableProperty]
    private float attack_speed;
    [ObservableProperty]
    private float speed;

    public Animals(Point location) : base(location) {

    }
    

    
}