using System;
using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;
using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Pong.ViewModels;

public partial class Meat : Not_a_life {
    [ObservableProperty]
    private int fresh;
    [ObservableProperty]
    private bool is_organic=false;
    [ObservableProperty]
    private int count =1;
    public Meat(Point location):base(location) {
        this.fresh = 100;
    }
    public void turn_in_organique(){
        Is_organic = true;
    }
    
    public Organic now_organic(){
        return new Organic(Location+new Point(15,15));
    }

    public ObservableCollection<GameObject> Tick(ObservableCollection<GameObject>gameobjects){
        if(Fresh<=0){
            turn_in_organique();
        }
        if(Count%100==0){
            Console.WriteLine(Fresh);
            Fresh -=5;
        }
        if(Is_organic){
            Organic organic = now_organic();
            gameobjects.Add(organic);
            gameobjects.Remove(this);
        }
        if(Erased){
            gameobjects.Remove(this);
        }
        Count++;

        return gameobjects;
    }
}