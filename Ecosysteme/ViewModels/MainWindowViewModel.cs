using Avalonia;
using Avalonia.Controls;
using Avalonia.Platform;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Pong.ViewModels;

public partial class MainWindowViewModel : GameBase
{
    public int Width { get; } = 1000;
    public int Height { get; } = 1000;
    private Lions lion1;
    private Sheep sheep;


    // Liste des objets à afficher
    public ObservableCollection<GameObject> GameObjects { get; } = new();

    public MainWindowViewModel() {
        lion1 = new Lions(new Point(Width/2-32,Height/2-32));
        sheep = new Sheep(new Point(100,100));
        GameObjects.Add(lion1);
        GameObjects.Add(sheep);
    }

    protected override void Tick()
    {
        foreach(GameObject obj in GameObjects){
            if (obj is Form_of_life){
                Form_of_life form_Of_Life = (Form_of_life)obj;
                form_Of_Life.Tick(GameObjects, Height, Width);
            }
            
        }
    }
}
