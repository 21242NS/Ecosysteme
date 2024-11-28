using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Pong.ViewModels;

public abstract partial class Herbivore : Animals {
    [ObservableProperty]
    private Point velocity = new Point(1.0, 0);

    public Herbivore(Point location) : base(location) {

    }

    public void Tick() {
        Location = Location + Velocity;
    }
}