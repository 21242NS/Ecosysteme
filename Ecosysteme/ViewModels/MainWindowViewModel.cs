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
    public int Width { get; } = 800;
    public int Height { get; } = 450;
    private Lions lion1;


    // Liste des objets à afficher
    public ObservableCollection<GameObject> GameObjects { get; } = new();

    public MainWindowViewModel() {
        lion1 = new Lions(new Point(Width/2-32,Height/2-32));
        GameObjects.Add(lion1);
    }

    protected override void Tick()
    {
        foreach(GameObject obj in GameObjects){
            if(obj is Animals) {
                if(obj is Carnivora){
                    Carnivora carnivor = (Carnivora)obj;
                    Type type_of_carnivor = carnivor.GetType();
                    List<GameObject> in_range = carnivor.is_in_Range(GameObjects, carnivor.get_vision_range());
                    List<GameObject> food_possibility = carnivor.sort<Meat,Animals>(in_range);
                    
                }
            }
        }
    }
}
