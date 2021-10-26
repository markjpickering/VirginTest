using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Virgin.Techtest.Core.Interfaces;
using Virgin.Techtest.Data.Interfaces;

namespace Virgin.Techtest.Data.Repositories
{
    // The datalayer should not be referencing domain entity classes, so some refactoring is needed!!
    public class RepositoryFromXmlFileBase<TDataEntity, TDomainEntity> : IRepository<TDomainEntity>
        where TDataEntity : class
        where TDomainEntity : class
    {
        private readonly IRepositoryXmlFileReader<TDataEntity> _reader;
        private readonly IMap<TDataEntity, TDomainEntity> _mapper;
        private Lazy<List<TDomainEntity>> _data;
        private string _fullFilePathAndName;

        public string FullFilePathAndName
        {
            get => _fullFilePathAndName;
            set
            {
                _fullFilePathAndName = value;
                ClearCachedData();
            }
        }

        public RepositoryFromXmlFileBase(
            IRepositoryXmlFileReader<TDataEntity> reader,
            IMap<TDataEntity, TDomainEntity> mapper)
        {
            _reader = reader;
            _mapper = mapper;
            ClearCachedData();
        }

        private void ClearCachedData()
        {
            _data = new Lazy<List<TDomainEntity>>(
                () =>
                {
                    return ReadAll();
                }
            );
        }

        public IReadOnlyList<TDomainEntity> GetAll() =>
            _data.Value.AsReadOnly();

        private List<TDomainEntity> ReadAll()
        {
            var readData = _reader.ReadAll();
            var mappedData =
                readData
                    .Select(dataEntity => _mapper.Map(dataEntity))
                    .ToList();

            return mappedData;
        }
    }
}
