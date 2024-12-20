﻿using Avalonia;
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


    // Liste des objets à afficher
    public ObservableCollection<GameObject> GameObjects { get; } = new();

    public MainWindowViewModel() {
        lion1 = new Lions(new Point(Width/2-32,Height/2-32),"Male");
        lion2 = new Lions(new Point(150,150),"Female");
        GameObjects.Add(lion1);
        GameObjects.Add(lion2);
       
    }

    protected override void Tick()
    {   
        ObservableCollection<GameObject> new_gameobjects=new();
        foreach(GameObject obj in GameObjects){
            if (obj is Form_of_life){
                Form_of_life form_Of_Life = (Form_of_life)obj;
                new_gameobjects = form_Of_Life.Tick(GameObjects, Height, Width);
                foreach(GameObject obje in new_gameobjects){
                    if(GameObjects.Contains(obje)){
                        GameObjects.Add(obje);
                    }
                }
            } 
            
        }
        Console.WriteLine(GameObjects.Count);
        
        
    }
}
