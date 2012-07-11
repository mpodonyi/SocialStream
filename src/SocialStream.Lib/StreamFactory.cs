using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Reflection;
using SocialStream.AddIn;

namespace SocialStream.Lib
{
    internal class Importer
    {
        [ImportMany(typeof(ISocialStreamProvider))]
        internal IEnumerable<Lazy<ISocialStreamProvider, ISocialStreamProviderMetadata>> SocialStreamProviders;


    }

    public interface ISocialStreamProviderMetadata
    {
        string ProviderName { get; }
    }


    public static class StreamFactory
    {


        private static Importer importer = new Importer();

        static StreamFactory()
        {
            Compose();
        }



        private static void Compose()
        {
            CompositionContainer container;

            var pathToAddInns = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "AddInns");

            //if (!Directory.Exists(pathToAddInns))
            //    Directory.CreateDirectory(pathToAddInns);

            IEnumerable<DirectoryCatalog> directoryCatalogs = from i in Directory.EnumerateDirectories(pathToAddInns, "*", SearchOption.TopDirectoryOnly)
                                                              select new DirectoryCatalog(i,"*.dll");

           // var catalog = new DirectoryCatalog(pathToAddInns,"*.dll");


            var aggregateCatalog = new AggregateCatalog(directoryCatalogs);


            container = new CompositionContainer(aggregateCatalog);

            try
            {
                container.ComposeParts(importer);
            }
            catch (CompositionException compositionException)
            {

            }
        }



        public static IEnumerable<string> GetStreamItems()
        {
            foreach (var provider in importer.SocialStreamProviders)
            {
                provider.Value.GetStreamItemCollection();
            }


            return null;

        }

    }
}