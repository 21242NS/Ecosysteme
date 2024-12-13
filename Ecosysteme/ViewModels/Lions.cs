using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml.Serialization;
using Avalonia;
using Avalonia.Animation.Easings;
using CommunityToolkit.Mvvm.ComponentModel;


namespace Pong.ViewModels;
public partial class Lions : Carnivora , Range {   
    public Lions(Point location) : base(location) { 
        this.Point_of_life = 100;
        this.Energy_count= 35;
        this.Defense= 3;
        this.Vision_range = 5;
        this.Speed = 3;
        this.Attack_speed = 100;
        this.Attack_point = 10;
    }
    public List<GameObject> is_in_Range(ObservableCollection<GameObject> gameObjects, int range) {
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
    public Point find_near(List<GameObject> animal){
        Point nearest = this.Location;
        foreach(GameObject obje in animal) {
            double vector_range = Math.Sqrt(Math.Pow(obje.Location.X-this.Location.X, 2)+Math.Pow(obje.Location.Y-this.Location.Y, 2));
            double near = 5;
            Point objects = obje.Location;
            if (vector_range<near){
                near = vector_range;
                nearest = objects;
            }
        }
        return nearest;
    }
    public List<GameObject> sort(List<GameObject> obj){//essayer de mettre un gameobject pour généraliser
        List<GameObject> animals=new List<GameObject>();
        foreach(GameObject objs in obj) {
            if(objs is Animals || type_of_food(objs)){
                if(objs is not Lions){
                    animals.Add(objs);
                }
            }
        }
        return animals;
    }
    public Point move(Point loc){
        double multX = (loc.X-this.Location.X)/this.Speed;
        double multY = (loc.Y-this.Location.Y)/this.Speed;
        double velocity_X = (loc.X-this.Location.X)/multX;
        double velocity_Y = (loc.Y-this.Location.Y)/multY;
        Point velocity = new Point(velocity_X,velocity_Y);
        return velocity;
    }
    public override void eat() {
        
       
    }
    

 
}