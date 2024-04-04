﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MassSpectrometry;

namespace MetaPAL.Models
{
    [Table("Experiments")]
    public class Experiment
    {
        [Key]
        public int Id { get; set; } //autogenerated unique id
        public HostingRepository? HostingRepository { get; set; }
        public string? RepositoryIdentifier { get; set; }
        public string? DatasetFtpLocation { get; set; }
        public string? HostRepositoryUrl { get; set; }
        public ExperimentMetaData? ExperimentMetaData { get; set; }
        public virtual List<DataFile> DataFiles { get; set; }

        public List<ProteomicsSearchResult> ProteomicsSearchResults { get; set; }
        public List<ProteomicsQuantificationResult> ProteomicsQuantificationResults { get; set; }
        public List<SpectrumMatch> SpectrumMatches { get; set; }
        public List<MsDataFile> MsDataFiles { get; set; }


    }

    public enum HostingRepository
    {
        PRIDE,
        MassIVE,
        jPOST,
        Panorama,
        PeptideAtlas,
        GNPS,
        MetabolomicsWorkbench,
        Metabolights,
        Other
    }
}