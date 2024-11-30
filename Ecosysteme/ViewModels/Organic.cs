using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Pong.ViewModels;

public partial class Organic : GameObject {
    [ObservableProperty]
    private int quantity_of_energy;
    public Organic(Point location, int fresh, int quantity_of_energy):base(location) {
        this.quantity_of_energy = quantity_of_energy;
    }
    public void Tick(){
        
    }
}