using ThermoFisher.CommonCore.Data.Business;
using MassSpectrometry;

namespace MetaPAL.Resources.ControlledVocabulary
{
    public static class PsiMsTypes
    {
        /// <summary>
        /// id: MS:1000525
        /// name: spectrum representation
        /// comment: can take 2 possible values: Centroid or Profile
        /// def: "Way in which the spectrum is represented, either with regularly spaced data points or with a list of centroided peaks." [PSI: MS]
        /// relationship: part_of MS:1000442 ! spectrum
        /// </summary>
        public enum SpectrumRepresentationType
        {
            // id: MS:1000127
            // name: centroid spectrum
            // def: "Processing of profile data to produce spectra that contains discrete peaks of zero width. Often used to reduce the size of dataset." [PSI: MS]
            // synonym: "Discrete Mass Spectrum" EXACT []
            // is_a: MS:1000525 ! spectrum representation
            Centroid,
            // id: MS:1000128
            // name: profile spectrum
            // def: "A profile mass spectrum is created when data is recorded with ion current (counts per second) on one axis and mass/charge ratio on another axis." [PSI: MS]
            // synonym: "continuous mass spectrum" EXACT []
            // synonym: "Continuum Mass Spectrum" EXACT []
            // is_a: MS:1000525 ! spectrum representation
            Profile
        }

        /// <summary>
        /// id: MS:1000294
        /// name: mass spectrum
        /// def: "A plot of the relative abundance of a beam or other collection of ions as a function of the mass-to-charge ratio (m/z)." [PSI: MS]
        /// is_a: MS:1000524 ! data file content
        /// is_a: MS:1000559 ! spectrum type
        /// </summary>
        public enum MassSpectrumType
        {
            // id: MS:1000579
            // name: MS1 spectrum
            // def: "Mass spectrum created by a single-stage MS experiment or the first stage of a multi-stage experiment." [PSI: MS]
            MS1Spectrum,
            // id: MS:1000580
            // name: MSn spectrum
            // def: "MSn refers to multi-stage MS2 experiments designed to record product ion spectra where n is the number of product ion stages (progeny ions). For ion traps, sequential MS/MS experiments can be undertaken where n > 2 whereas for a simple triple quadrupole system n=2. Use the term ms level (MS:1000511) for specifying n." [PSI: MS]
            MSnSpectrum,
            // id: MS:1000581
            // name: CRM spectrum
            // def: "Spectrum generated from MSn experiment with three or more stages of m/z separation and in which a particular multi-step reaction path is monitored." [PSI: MS]
            CRMSpectrum,
            // id: MS:1000582
            // name: SIM spectrum
            // def: "Spectrum obtained with the operation of a mass spectrometer in which the abundances of one ion or several ions of specific m/z values are recorded rather than the entire mass spectrum (Selected Ion Monitoring)." [PSI: MS]
            SIMSpectrum,
            // id: MS:1000583
            // name: SRM spectrum
            // def: "Spectrum obtained when data are acquired from specific product ions corresponding to m/z values of selected precursor ions a recorded via two or more stages of mass spectrometry. The precursor/product ion pair is called a transition pair. Data can be obtained for a single transition pair or multiple transition pairs. Multiple time segments of different transition pairs can exist in a single file. Single precursor ions can have multiple product ions consitituting multiple transition pairs. Selected reaction monitoring can be performed as tandem mass spectrometry in time or tandem mass spectrometry in space." [PSI: MS]
            SRMSpectrum,
        }

        /// <summary>
        /// id: MS:1000465
        /// name: scan polarity
        /// def: "Relative orientation of the electromagnetic field during the selection and detection of ions in the mass spectrometer." [PSI: MS]
        /// relationship: part_of MS:1000441 ! scan
        /// </summary>
        public enum ScanPolarityType
        {
            //id: MS:1000129
            //name: negative scan
            //def: "Polarity of the scan is negative." [PSI: MS]
            //is_a: MS:1000808 ! chromatogram attribute
            NegativeScan,
            //id: MS:1000130
            //name: positive scan
            //def: "Polarity of the scan is positive." [PSI: MS]
            //is_a: MS:1000808 ! chromatogram attribute
            PositiveScan
        }

        public static MassAnalyzerType ToMassAnalyzerType(this MZAnalyzerType type)
        {
            switch (type)
            {
                case MZAnalyzerType.Orbitrap:
                    return MassAnalyzerType.Orbitrap;
                case MZAnalyzerType.TOF:
                    return MassAnalyzerType.TimeOfFlight;
                case MZAnalyzerType.FTICR:
                    return MassAnalyzerType.FourierTransformIonCyclotronResonanceMassSpectrometer;
                case MZAnalyzerType.Sector:
                    return MassAnalyzerType.MagneticSector;
                case MZAnalyzerType.Quadrupole:
                    return MassAnalyzerType.Quadrupole;
                case MZAnalyzerType.IonTrap2D:
                    return MassAnalyzerType.IonTrap;
                case MZAnalyzerType.IonTrap3D:
                    return MassAnalyzerType.IonTrap;
                default:
                    return MassAnalyzerType.Unknown;
            }
        }

        /// <summary>
        /// id: MS:1000443
        /// name: mass analyzer type
        /// def: "Mass analyzer separates the ions according to their mass-to-charge ratio." [PSI: MS]
        /// relationship: part_of MS:1000451 ! mass analyzer
        /// </summary>
        public enum MassAnalyzerType
        {
            //id: MS:1000484
            //name: orbitrap
            //def: "An ion trapping device that consists of an outer barrel-like electrode and a coaxial inner spindle-like electrode that form an electrostatic field with quadro-logarithmic potential distribution. The frequency of harmonic oscillations of the orbitally trapped ions along the axis of the electrostatic field is independent of the ion velocity and is inversely proportional to the square root of m/z so that the trap can be used as a mass analyzer." [PSI: MS]
            Orbitrap,
            //        id: MS:1000079
            //name: fourier transform ion cyclotron resonance mass spectrometer
            //def: "A mass spectrometer based on the principle of ion cyclotron resonance in which an ion in a magnetic field moves in a circular orbit at a frequency characteristic of its m/z value. Ions are coherently excited to a larger radius orbit using a pulse of radio frequency energy and their image charge is detected on receiver plates as a time domain signal. Fourier transformation of the time domain signal results in a frequency domain signal which is converted to a mass spectrum based in the inverse relationship between frequency and m/z." [PSI: MS]
            //        synonym: "FT_ICR" EXACT []
            FourierTransformIonCyclotronResonanceMassSpectrometer,
            //id: MS:1000080
            //name: magnetic sector
            //def: "A device that produces a magnetic field perpendicular to a charged particle beam that deflects the beam to an extent that is proportional to the particle momentum per unit charge. For a monoenergetic beam, the deflection is proportional to m/z." [PSI: MS]
            MagneticSector,
            //        id: MS:1000081
            //name: quadrupole
            //def: "A mass spectrometer that consists of four parallel rods whose centers form the corners of a square and whose opposing poles are connected. The voltage applied to the rods is a superposition of a static potential and a sinusoidal radio frequency potential. The motion of an ion in the x and y dimensions is described by the Matthieu equation whose solutions show that ions in a particular m/z range can be transmitted along the z axis." [PSI: MS]
            Quadrupole,
            //        id: MS:1000084
            //name: time-of-flight
            //def: "Instrument that separates ions by m/z in a field-free region after acceleration to a fixed acceleration energy." [PSI: MS]
            //        synonym: "TOF" EXACT []
            TimeOfFlight,
            //        id: MS:1000254
            //name: electrostatic energy analyzer
            //def: "A device consisting of conducting parallel plates, concentric cylinders or concentric spheres that separates charged particles according to their kinetic energy by means of an electric field that is constant in time." [PSI: MS]
            //        synonym: "ESA" EXACT []
            ElectrostaticEnergyAnalyzer,
            //        id: MS:1000264
            //name: ion trap
            //def: "A device for spatially confining ions using electric and magnetic fields alone or in combination." [PSI: MS]
            //        synonym: "IT" EXACT []
            IonTrap,
            //        id: MS:1000284
            //name: stored waveform inverse fourier transform
            //def: "A technique to create excitation waveforms for ions in FT-ICR mass spectrometer or Paul ion trap. An excitation waveform in the time-domain is generated by taking the inverse Fourier transform of an appropriate frequency-domain programmed excitation spectrum, in which the resonance frequencies of ions to be excited are included. This technique may be used for selection of precursor ions in MS2 experiments." [PSI: MS]
            //        synonym: "SWIFT" EXACT []
            StoredWaveformInverseFourierTransform,
            //id: MS:1000288
            //name: cyclotron
            //def: "A device that uses an oscillating electric field and magnetic field to accelerate charged particles." [PSI: MS]
            Cyclotron,
            // Not a PSI term, but rather a placeholder for any unknown type
            Unknown
        }

        /// <summary>
        /// Convert mzLib's DissociationType to DissociationMethodType. Most dissociation methods map to a PSI term.
        /// DissociationTypes Unknown, AnyActivationType, Custom, and Autodetect are converted to  DissociationMethodType.Unknown.
        /// Null value in = null value out
        /// </summary>
        public static DissociationMethodType? ToDissociationMethodType(this DissociationType? type)
        {
            switch (type)
            {
                case DissociationType.CID:
                    return DissociationMethodType.CollisionInducedDissociation;
                case DissociationType.PD:
                    return DissociationMethodType.PlasmaDesorption;
                case DissociationType.PSD:
                    return DissociationMethodType.PostSourceDecay;
                case DissociationType.SID:
                    return DissociationMethodType.SurfaceInducedDissociation;
                case DissociationType.BIRD:
                    return DissociationMethodType.BlackbodyInfraredRadiativeDissociation;
                case DissociationType.ECD:
                    return DissociationMethodType.ElectronCaptureDissociation;
                case DissociationType.MPD:
                    return DissociationMethodType.Photodissociation;
                case DissociationType.UVPD:
                    return DissociationMethodType.UltravioletPhotodissociation;
                case DissociationType.ETD:
                    return DissociationMethodType.ElectronTransferDissociation;
                case DissociationType.PQD:
                    return DissociationMethodType.PulsedQDissociation;
                case DissociationType.ISCID:
                    return DissociationMethodType.InSourceCollisionInducedDissociation;
                case DissociationType.HCD:
                    return DissociationMethodType.HCD;
                case DissociationType.EThcD:
                    return DissociationMethodType.EThcD;
                case DissociationType.NETD:
                    return DissociationMethodType.NegativeElectronTransferDissociation;
                case DissociationType.LowCID:
                    return DissociationMethodType.LowEnergyCollisionInducedDissociation;
                case null:
                    return null;
                default:
                    return DissociationMethodType.Unknown;
            }
        }

        /// <summary>
        /// id: MS:1000044
        /// name: dissociation method
        /// def: "Fragmentation method used for dissociation or fragmentation." [PSI: MS]
        /// synonym: "Activation Method" RELATED[]
        /// relationship: part_of MS:1000456 ! precursor activation
        /// </summary>
        public enum DissociationMethodType
        {
            //            id: MS:1000422
            // name: beam-type collision-induced dissociation
            // def: "A collision-induced dissociation process that occurs in a beam-type collision cell." [PSI: MS]
            //            synonym: "HCD" EXACT []
            //            is_a: MS:1000133 ! collision-induced dissociation
            HCD,
            //id: MS:1002631
            //name: electron-transfer/higher-energy collision dissociation
            //def: "Dissociation process combining electron-transfer dissociation and higher-energy collision dissociation. It combines ETD (reaction time) followed by HCD (activation energy)." [PSI: PI]
            //synonym: "EThcD" EXACT []
            //is_a: MS:1003181 ! combined dissociation method
            EThcD,
            //            id: MS:1000133
            //name: collision-induced dissociation
            //def: "The dissociation of an ion after collisional excitation. The term collisional-activated dissociation is not recommended." [PSI: MS]
            //            synonym: "CID" EXACT []
            //            synonym: "CAD" EXACT []
            //            synonym: "collisionally activated dissociation" EXACT []
            CollisionInducedDissociation,
            //            id: MS:1000134
            //name: plasma desorption
            //def: "The ionization of material in a solid sample by bombarding it with ionic or neutral atoms formed as a result of the fission of a suitable nuclide, typically 252Cf. Synonymous with fission fragment ionization." [PSI: MS]
            //synonym: "PD" EXACT []
            PlasmaDesorption,
            //            id: MS:1000135
            //name: post-source decay
            //def: "A technique specific to reflectron time-of-flight mass spectrometers where product ions of metastable transitions or collision-induced dissociations generated in the drift tube prior to entering the reflectron are m/z separated to yield product ion spectra." [PSI: MS]
            //            synonym: "PSD" EXACT []
            PostSourceDecay,
            //            id: MS:1000136
            //name: surface-induced dissociation
            //def: "Fragmentation that results from the collision of an ion with a surface." [PSI: MS]
            //            synonym: "SID" EXACT []
            SurfaceInducedDissociation,
            //            id: MS:1000242
            //name: blackbody infrared radiative dissociation
            //def: "A special case of infrared multiphoton dissociation wherein excitation of the reactant ion is caused by absorption of infrared photons radiating from heated blackbody surroundings, which are usually the walls of a vacuum chamber. See also infrared multiphoton dissociation." [PSI: MS]
            //            synonym: "BIRD" EXACT []
            BlackbodyInfraredRadiativeDissociation,
            //            id: MS:1000250
            //name: electron capture dissociation
            //def: "A process in which a multiply protonated molecules interacts with a low energy electrons. Capture of the electron leads the liberation of energy and a reduction in charge state of the ion with the production of the (M + nH) (n-1)+ odd electron ion, which readily fragments." [PSI: MS]
            //            synonym: "ECD" EXACT []
            ElectronCaptureDissociation,
            //            id: MS:1000282
            //name: sustained off-resonance irradiation
            //def: "A technique associated with Fourier transform ion cyclotron resonance (FT-ICR) mass spectrometry to carry out ion/neutral reactions such as low-energy collision-induced dissociation. A radio-frequency electric field of slightly off-resonance to the cyclotron frequency of the reactant ion cyclically accelerates and decelerates the reactant ion that is confined in the Penning ion trap. The ion's orbit does not exceed the dimensions of ion trap while the ion undergoes an ion/neutral species process that produces a high average translational energy for an extended time." [PSI: MS]
            //            synonym: "SORI" EXACT []
            SustainedOffResonanceIrradiation,
            //            id: MS:1000435
            //name: photodissociation
            //def: "A process wherein the reactant ion is dissociated as a result of absorption of one or more photons." [PSI: MS]
            //            synonym: "multiphoton dissociation" EXACT []
            //            synonym: "MPD" EXACT []
            Photodissociation,
            //id: MS:1003246
            //name: ultraviolet photodissociation
            //def: "Multiphoton ionization where the reactant ion dissociates as a result of the absorption of multiple UV photons." [PSI: MS]
            //synonym: "UVPD" EXACT []
            UltravioletPhotodissociation,
            //            id: MS:1000598
            //name: electron transfer dissociation
            //def: "A process to fragment ions in a mass spectrometer by inducing fragmentation of cations (e.g. peptides or proteins) by transferring electrons from radical-anions." [DOI:10.1073/pnas.0402700101, PMID:15210983, PSI:MS]
            //            synonym: "ETD" EXACT []
            ElectronTransferDissociation,
            //            id: MS:1000599
            //name: pulsed q dissociation
            //def: "A process that involves precursor ion activation at high Q, a time delay to allow the precursor to fragment, then a rapid pulse to low Q where all fragment ions are trapped. The product ions can then be scanned out of the ion trap and detected." [PSI: MS]
            //            synonym: "PQD" EXACT []
            PulsedQDissociation,
            //            id: MS:1001880
            //name: in-source collision-induced dissociation
            //def: "The dissociation of an ion as a result of collisional excitation during ion transfer from an atmospheric pressure ion source and the mass spectrometer vacuum." [PSI: MS]
            InSourceCollisionInducedDissociation,
            //id: MS:1000433
            //name: low-energy collision-induced dissociation
            //def: "A collision-induced dissociation process wherein the precursor ion has the translational energy lower than approximately 1000 eV. This process typically requires multiple collisions and the collisional excitation is cumulative." [PSI: MS]
            LowEnergyCollisionInducedDissociation,
            //            id: MS:1002000
            //name: LIFT
            //def: "A Bruker's proprietary technique where molecular ions are initially accelerated at lower energy, then collide with inert gas in a collision cell that is then 'lifted' to high potential. The use of inert gas is optional, as it could lift also fragments provided by LID." [DOI:10.1007/s00216-003-2057-0 , PMID:12830354]
            LIFT,
            //            id: MS:1003181
            //name: combined dissociation method
            //def: "Combination of two or more dissociation methods that are known by a special term." [PSI: PI]
            CombinedDissociationMethod,
            //            id: MS:1003247
            //name: negative electron transfer dissociation
            //def: "A process to fragment ions in a mass spectrometer by inducing fragmentation of anions (e.g. peptides or proteins) by transferring electrons to a radical-cation." [DOI:10.1016/j.jasms.2005.01.015, PSI:MS]
            //            synonym: "NETD" EXACT []
            NegativeElectronTransferDissociation,
            Unknown
        }
    }
}
