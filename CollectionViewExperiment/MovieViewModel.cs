using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionViewExperiment
{
    public class MovieViewModel:BindableBase
    {
        public string Name { get; set; }

        public int Rating { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int ReleaseYear { get => ReleaseDate.Year; }
    }
}
