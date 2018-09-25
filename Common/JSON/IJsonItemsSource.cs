using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Itlezy.Common.JSON
{
    public interface IJsonItemsSource
    {
        IList<JsonItem> JsonItems { get; }
    }
}
