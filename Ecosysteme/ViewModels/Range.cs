using System.Collections.Generic;
using System.Collections.ObjectModel;
using Pong.ViewModels;

public interface Range{
    List<GameObject> is_in_Range(ObservableCollection<GameObject> gameObjects, int range);
}