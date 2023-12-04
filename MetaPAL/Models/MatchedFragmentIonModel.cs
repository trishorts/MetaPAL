using Omics.Fragmentation;

namespace MetaPAL.Models
{
    public class MatchedFragmentIonModel : MatchedFragmentIon
    {
        public MatchedFragmentIonModel(Product neutralTheoreticalProduct, double experMz, double experIntensity, int charge) 
            : base(neutralTheoreticalProduct, experMz, experIntensity, charge)
        {

        }
    }
}
