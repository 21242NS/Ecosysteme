using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Pong.ViewModels;

public abstract partial class Animals : Form_of_life, Range {
    [ObservableProperty]
    private float vision_range;
    [ObservableProperty]
    private int attack_point;
    [ObservableProperty]
    private float attack_speed;
    [ObservableProperty]
    private float speed;
    [ObservableProperty]
    private float attack_range;
    [ObservableProperty]
    private Point velocity;

    public Animals(Point location) : base(location) {

    }
    public bool type_of_food<T>(GameObject obj) where T : GameObject 
    {
        return (obj is T);
     }
    public List<GameObject> is_in_Range(ObservableCollection<GameObject> gameObjects, float range) {
        List<GameObject> inrange = new List<GameObject>();
        foreach(GameObject obj in gameObjects)
        {
            double vector_range = Math.Sqrt(Math.Pow(obj.Location.X-this.Location.X, 2)+Math.Pow(obj.Location.Y-this.Location.Y, 2));
            if (vector_range<this.Vision_range){
                inrange.Add(obj);
            }
        }
        return inrange;
    }
    public GameObject find_near(List<GameObject> animal){
        GameObject game_object = null;
        foreach(GameObject obje in animal) {
            double vector_range = Math.Sqrt(Math.Pow(obje.Location.X-this.Location.X, 2)+Math.Pow(obje.Location.Y-this.Location.Y, 2));
            double near = 5;
            if (vector_range<near){
                near = vector_range;
                game_object = obje;
            }
        }
        return game_object;
    }
    public List<GameObject> sort<T,S, H>(List<GameObject> obj) where T : GameObject
    where S : GameObject
    where H : GameObject
    {//essayer de mettre un gameobject pour généraliser
        List<GameObject> animals=new List<GameObject>();
        foreach(GameObject objs in obj) {
            if(objs is S || type_of_food<H>(objs)){ 
                if(objs is not T){
                    animals.Add(objs);
                }
            }
        }
        return animals;
    }
    public List<GameObject> find_partener<T>(List<GameObject> obj) where T: GameObject{
        List<GameObject> another_animal = new List<GameObject>();
        foreach( GameObject objs in obj) {
            if(objs is T){
                another_animal.Add(objs);
            }
        }
        return another_animal;
    }
    public Point move(Point loc){
        double multX = (loc.X-this.Location.X)/this.Speed;
        double multY = (loc.Y-this.Location.Y)/this.Speed;
        double velocity_X = (loc.X-this.Location.X)/multX;
        double velocity_Y = (loc.Y-this.Location.Y)/multY;
        Point velocity = new Point(velocity_X,velocity_Y);
        return velocity;
    }
    

    
}