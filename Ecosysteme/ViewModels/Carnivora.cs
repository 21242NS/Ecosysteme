using System;
using Avalonia;
using Avalonia.Animation.Easings;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Pong.ViewModels;

public abstract partial class Carnivora : Animals {
    public Carnivora(Point location) : base(location) {

    }
    public bool type_of_food(GameObject obj) 
    {
        return (obj is Meat);
     }
    public void Tick() {
        
    }
}