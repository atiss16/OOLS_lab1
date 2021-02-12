using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Strategy.Domain.Models
{
    public abstract class Cell
    {
        public Cell()
        {

        }
        /// <summary>
        /// Координата x на карте.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Координата y на карте.
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Путь к изображению 
        /// </summary>
        protected string PathToImage { get; set; }

        /// <summary>
        /// Путь к изображению
        /// </summary>
        public ImageSource Image
        {
            get
            {
                return BuildSourceFromPath(PathToImage);
            }
        }

        /// <summary>
        /// Получить изображение по указанному пути.
        /// </summary>
        private static ImageSource BuildSourceFromPath(string path)
        {
            return new BitmapImage(new Uri(path, UriKind.Relative));
        }
    }
}
