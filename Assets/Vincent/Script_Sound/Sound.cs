using UnityEngine;

public enum TYPE_AUDIO
{
    MusiqueMenuDemarrageDuJeu,
    MusiqueQuandOnCliqueSurUnBouton,
    BruitsAmbiance,
    BruitDesMonstres,
    RugissementMonstre1,
    RugissementMonstre2,
    RugissementMonstre3,
    RugissementMonstre4,
    RugissementMonstre5,
    BruitOmbre,
    ParquetQuiGrince,
    GrelottementPeurEnfant,
    GemissementEnfant,
    Horloge,
    ChangementDuModeLampe,
    ClicLampeOnOff,
    BruitQuandLaLampeEstDecharger,
    BruitVieuxBoisMeubleQuiGrincent,
    BruitAllumageProjecteur,
    BruitMortMonstreEtOmbre,
    BruitAttaqueMonstre,
    BruitMortEnfant,
    Defaite,
    ChangementDeJour,
    ClacDuPiegeActiver,
    BruitDePreactivationPiege,
    BruitMonstreToucher,
    BruitExplosionMonstre
}

[System.Serializable]
public class Sound
{
    public TYPE_AUDIO audioFor;
    public AudioClip audio;
    public bool loop;
    public bool playOnAwake;
}