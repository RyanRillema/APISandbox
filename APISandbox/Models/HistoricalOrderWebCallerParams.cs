using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APISandbox.Models
{
    public enum Category
    {
        spot,linear
    }
    public class HistoricalOrderWebCallerParams
    {

        public Category Category;

        public HistoricalOrderWebCallerParams(Category setCategory)
        {
            Category = setCategory;
        }

    }
}
