using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Pong.ViewModels;

public abstract partial class Animals : Form_of_life {
    [ObservableProperty]
    private Point velocity = new Point(1.0, 0);

    public Animals(Point location) : base(location) {

    }

    public void Tick() {
        Location = Location + Velocity;
    }
}