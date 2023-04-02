using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automarket.Domain.Entity
{
    public class Laptop
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string ProcessorModel { get; set; }
        public int ProcessorCores { get; set; }
        public float ProcessorSpeed { get; set; }
        public string GraphicsCard { get; set; }
        public string GraphicsCardType { get; set; }
        public float ScreenSize { get; set; }
        public string Resolution { get; set; }
        public string Storage { get; set; }
        public string Memory { get; set; }
        public int Price { get; set; }
        public int Year { get; set; }
    }
}
