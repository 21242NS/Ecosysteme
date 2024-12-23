using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Pong.ViewModels;

public abstract partial class Plants : Form_of_life, Range {
    [ObservableProperty]
    private float range_of_food;
    [ObservableProperty]
    private bool dead = false;
    [ObservableProperty]
    private int range_of_reproduction;

    public Plants(Point location) : base(location) {

    }
    public void is_dead(){
        Dead = true;
    }
    public List<GameObject> is_in_Range(ObservableCollection<GameObject> gameObjects) {
        List<GameObject> inrange = new List<GameObject>();
        foreach(GameObject obj in gameObjects)
        {
            double vector_range = Math.Sqrt(Math.Pow(obj.Location.X-this.Location.X, 2)+Math.Pow(obj.Location.Y-this.Location.Y, 2));
            if (vector_range<this.Range_of_food){
                inrange.Add(obj);
            }
        }
        return inrange;
    }
    public GameObject find_near(List<GameObject> animal){
        GameObject game_object = null;
        foreach(GameObject obje in animal) {
            double vector_range = Math.Sqrt(Math.Pow(obje.Location.X-this.Location.X, 2)+Math.Pow(obje.Location.Y-this.Location.Y, 2));
            double near = this.Range_of_food;
            if (vector_range<near){
                near = vector_range;
                game_object = obje;
            }
        }
        
        return game_object;
    }
    public List<GameObject> is_food(List<GameObject> objects){
        List<GameObject> organics = new List<GameObject>();
        foreach(GameObject obj in objects){
            if(obj is Organic){
                organics.Add(obj);
            }
        }
        return organics;
    }
    public override void eat(GameObject obj)
    {
       if (obj is Organic){
            Organic plants = (Organic)obj;
            if (this.Point_of_life==this.Maximum_point_of_life&& this.Energy_count< this.Maximum_energy){
                this.Energy_count += 5;
            }
            else {
                this.Point_of_life += 5;
                if (this.Point_of_life>this.Maximum_point_of_life){
                    this.Point_of_life = this.Maximum_point_of_life;
                }
            }
            plants.is_erased();
        }
    }
    public Organic turn_organic(){
        return new Organic(Location+new Point(10,10));
    }
}