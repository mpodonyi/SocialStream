using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition;

namespace SocialStream.Lib
{
    public static class StreamFactory
    {
        private static CompositionContainer container;

        private  static void Compose()
        {
        //An aggregate catalog that combines multiple catalogs
            var catalog = new DirectoryCatalog("");
        //Adds all the parts found in the same assembly as the Program class
        

        //Create the CompositionContainer with the parts in the catalog
            container = new CompositionContainer(catalog);

        //Fill the imports of this object
        try
        {
            container.ComposeParts();
        }
        catch (CompositionException compositionException)
        {
            Console.WriteLine(compositionException.ToString());
        }
        }



        private IEnumerable<StreamItem> GetStreamItems()
        {


        }

    }
}