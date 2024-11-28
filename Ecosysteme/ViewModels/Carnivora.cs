using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Pong.ViewModels;

public abstract partial class Carnivora : Animals {
    [ObservableProperty]
    private Point velocity = new Point(1.0, 0);

    public Carnivora(Point location) : base(location) {

    }

    public void Tick() {
        Location = Location + Velocity;
    }
}