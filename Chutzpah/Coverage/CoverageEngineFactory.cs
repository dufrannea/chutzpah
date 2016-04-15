using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chutzpah.FileProcessors;
using Chutzpah.Wrappers;

namespace Chutzpah.Coverage
{
    public interface ICoverageEngineFactory
    {
        ICoverageEngine CreateCoverageEngine();
    }

    public class CoverageEngineFactory : ICoverageEngineFactory
    {
        private readonly IFileSystemWrapper fileSystem;
        private readonly IJsonSerializer jsonSerializer;
        private readonly ILineCoverageMapper lineCoverageMapper;
        private ISourceMapDiscoverer sourceMapDiscoverer;

        public CoverageEngineFactory(
            IJsonSerializer jsonSerializer, 
            IFileSystemWrapper fileSystem, 
            ILineCoverageMapper lineCoverageMapper, 
            ISourceMapDiscoverer sourceMapDiscoverer)
        {
            this.jsonSerializer = jsonSerializer;
            this.fileSystem = fileSystem;
            this.lineCoverageMapper = lineCoverageMapper;
            this.sourceMapDiscoverer = sourceMapDiscoverer;
        }

        public ICoverageEngine CreateCoverageEngine()
        {
            return new BlanketJsCoverageEngine(jsonSerializer, fileSystem, lineCoverageMapper, sourceMapDiscoverer);
        }
    }
}
