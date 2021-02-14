using NLog.Targets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBookApplication.Sidecar.Nlog
{
    public class NlogConfiguration
    {
        public string FilePath { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string FileName { get; set; }
        public bool KeepFileOpen { get; set; }
        public bool ConcurrentWrites { get; set; }
        public bool ArchiveOldFilesOnStartup { get; set; }
        public string Layout { get; set; }
        public bool CreateDirectory { get; set; }
        public string Level { get; set; }
        public string ArchiveFileName { get; set; }
        public long ArchiveAboveSize { get; set; }
        public FileArchivePeriod ArchiveEvery { get; set; }
        public ArchiveNumberingMode ArchiveNumbering { get; set; }
        public int MaxArchiveFiles { get; set; }
    }
}
