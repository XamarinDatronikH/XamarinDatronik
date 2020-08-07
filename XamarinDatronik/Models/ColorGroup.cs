using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace XamarinDatronik.Models
{
    public class ColorGroup : ObservableCollection<string>
    {
        public ColorGroup(string name, ICollection<string> colors) : base(colors) 
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
