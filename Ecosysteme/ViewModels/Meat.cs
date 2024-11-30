using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Pong.ViewModels;

public partial class Meat : GameObject {
    [ObservableProperty]
    private int fresh;
    [ObservableProperty]
    private int quantity_of_energy;
    public Meat(Point location, int fresh, int quantity_of_energy):base(location) {
        this.fresh = fresh;
        this.quantity_of_energy = quantity_of_energy;
    }
    public void turn_in_organique(){

    }
    public void Tick(){
        
    }
}