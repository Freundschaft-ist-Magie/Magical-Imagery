using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public uint Price { get; set; }
        public string? Category { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Pixel => $"{Width}X{Height}";
        public int LicenceId { get; set; }
        public Licence? Licence { get; set; }
    }
}
