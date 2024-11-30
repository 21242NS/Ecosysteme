using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Pong.ViewModels;

public abstract partial class Herbivore : Animals {
    [ObservableProperty]
    private string type_of_food = "Plants";

    public Herbivore(Point location) : base(location) {
        
    }

    public void Tick() {
    }
}