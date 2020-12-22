namespace Packt.LearningCS
{
    [System.Flags]
    public enum WondersOfTheAncientWorld : byte
    {
        None = 0,
        GreatPyramidOfGiza = 1,
        HangingGardensOfBabylon = 2,
        StatueOfZeusAtOlympia = 4,
        TempleOfArtemisAtEphesus = 8,
        MausoleumAtHalicarnassus = 16,
        ColossusOfRhodes = 32,
        LighthouseOfAlexandria = 64
    }
}
