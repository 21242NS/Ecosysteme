using Avalonia;
using Avalonia.Controls;
using Avalonia.Platform;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Pong.ViewModels;

public partial class MainWindowViewModel : GameBase
{
    public int Width { get; } = 1000;
    public int Height { get; } = 1000;
    private Lions lion1;
    private Lions lion2;
    private Sheep sheep1;
    private Sheep sheep2;
    private Rose rose1;
    private Rose rose2;


    // Liste des objets à afficher
    public ObservableCollection<GameObject> GameObjects { get; } = new();

    public MainWindowViewModel() {
        lion1 = new Lions(new Point(Width/2-32,Height/2-32),"Male");
        sheep1 = new Sheep(new Point(120,120), "Male");
        lion2 = new Lions(new Point(750,750),"Female");
        sheep2 = new Sheep(new Point(200,200), "Female");
        rose1 = new Rose(new Point(200,500));
        rose2 = new Rose(new Point(400,500));
        GameObjects.Add(lion1);
        GameObjects.Add(lion2);
        GameObjects.Add(sheep1);
        GameObjects.Add(sheep2);
        GameObjects.Add(rose1);
        GameObjects.Add(rose2);

        
       
    }

    protected override void Tick()
    {   
       
        foreach(GameObject obj in GameObjects.ToList()){
            if (obj is Form_of_life){
                Form_of_life form_Of_Life = (Form_of_life)obj;
                form_Of_Life.Tick(GameObjects, Height, Width);
            }
            else if(obj is Meat){
                Meat meat=(Meat)obj;
                meat.Tick(GameObjects);
            }
            else if(obj is Organic){
                Organic organic=(Organic)obj;
                organic.Tick(GameObjects);
            }
            
        }
        
        
        
    }
}
