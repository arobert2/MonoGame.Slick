using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlickEngine.Graphics
{
    public class GraphicsRepostiroy
    {
        public static Dictionary<string, GraphicPackage> GraphicPackages { get; set; }
        public GraphicPackage this[string s] { get { return GraphicPackages[s]; } set { GraphicPackages[s] = value; } }
    }
}
