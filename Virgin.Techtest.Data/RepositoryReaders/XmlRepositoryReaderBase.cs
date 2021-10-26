using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Virgin.Techtest.Data.Interfaces;
using Virgin.Techtest.Domain.Model;

namespace Virgin.Techtest.Data.RepositoryReaders
{
    public class XmlRepositoryReaderBase<TEntity> : IRepositoryXmlFileReader<TEntity>
        where TEntity : class
    {
        private readonly IFileSystem _fileSystem;

        public XmlRepositoryReaderBase(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public string FullFilePathAndName { get; set; }

        public IReadOnlyList<TEntity> ReadAll()
        {
            var result = new ScenarioDataFile();

            using (var reader = XmlReader.Create(_fileSystem.File.OpenText(FullFilePathAndName)))
            {
                var serializer =
                        new XmlSerializer(typeof(ScenarioDataFile));

                var answer = serializer.Deserialize(reader);
                result = answer as ScenarioDataFile;
            }

            return result?.Scenario.ToList() as IReadOnlyList<TEntity>;
        }
    }
}
