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
    public void move(){
        //Point target = find_near()
        //double velocity_X = 
        //Point velocity
    }
    public override void eat(GameObject obj) {
        List<GameObject> animals=new List<GameObject>();
        foreach(GameObject objs in obj) {
            if(type_of_food(objs)){
                animals.Add(objs);
            }
        }
       
    }
    

 
}