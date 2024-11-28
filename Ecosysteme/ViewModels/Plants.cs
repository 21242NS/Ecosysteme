using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Pong.ViewModels;

public abstract partial class Plants : Form_of_life {
    [ObservableProperty]
    private Point velocity = new Point(1.0, 0);

    public Plants(Point location) : base(location) {

    }

    public void Tick() {
        Location = Location + Velocity;
    }
}