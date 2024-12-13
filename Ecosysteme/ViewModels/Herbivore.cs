using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Pong.ViewModels;

public abstract partial class Herbivore : Animals {
    

    public Herbivore(Point location) : base(location) {

    }
     public bool type_of_food(GameObject obj) 
    {
        return (obj is Plants);
     }
    public void Tick() {
    }
}