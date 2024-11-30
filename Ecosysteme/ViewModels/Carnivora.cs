using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Pong.ViewModels;

public abstract partial class Carnivora : Animals {
    [ObservableProperty]
    private string type_of_food = "Animals";

    public Carnivora(Point location) : base(location) {

    }

    public void Tick() {
        
    }
}